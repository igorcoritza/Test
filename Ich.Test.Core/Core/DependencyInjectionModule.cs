using Ich.Test.Core.Serializations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ich.Test.Core.Core;

public class DependencyInjectionModule : IDependencyInjectionModule
{
    public void AddModule(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IJsonSerializer, JsonSerializer>();
    }
}