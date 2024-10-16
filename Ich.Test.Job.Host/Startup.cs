using Hangfire;
using Ich.Test.Core.Host;
using Microsoft.OpenApi.Models;

namespace Ich.Test;

public class Startup
{
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _configuration;
    private const string Pattern = "/dashboard";

    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
        _env = env;
        _configuration = configuration;
    }

    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //swagger
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseResponseCaching();
        app.UseRouting();
        
        Action<IEndpointRouteBuilder> configureEndpoints = endpoints =>
        {
            endpoints.MapHangfireDashboard(Pattern, new DashboardOptions());
        };
        //Hnagifire
        app.UseHangfireServer(() => new BackgroundJobServer());
        app.UseEndpoints(endpoints =>
        {
           endpoints.MapDefaultControllerRoute();
           configureEndpoints?.Invoke(endpoints);
        });
        //Graph-QL
        app.MapGraphQL("/graphql", "AddGraphQLServer");
    }

    public virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddDependencies(this._configuration, 
            typeof(Ich.Test.Core.Pointer).Assembly, 
            typeof(Ich.Test.Codere.Infrastructure.Pointer).Assembly, 
            typeof(Ich.Test.Codere.HotChocolate.Infrastructure.Pointer).Assembly, 
            typeof(Ich.Test.Codere.Application.Pointer).Assembly, 
            typeof(Ich.Test.Codere.SqlServer.Infrastructure.Pointer).Assembly
            );
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseInMemoryStorage());
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "API Key needed to access the endpoints. X-API-KEY: Your_API_Key",
                In = ParameterLocation.Header,
                Name = "X-API-KEY",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "ApiKeyScheme"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        },
                        Scheme = "ApiKeyScheme",
                        Name = "ApiKey",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });

    }
}