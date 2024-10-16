using Ich.Test.Codere.Domain.InfraContracts;
using Ich.Test.Codere.Infrastructure.Implementations;
using Ich.Test.Codere.Infrastructure.Models;
using Ich.Test.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ich.Test.Codere.Infrastructure.Core
{
    public class DependencyInjectionModule : IDependencyInjectionModule
    {
        public void AddModule(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITvDataProviderService, TvmazeWebApiService>();
            services.AddHttpClient(Constants.TvMazeEndpoint, client =>
            {
                client.BaseAddress = new Uri("https://api.tvmaze.com/");
            });
        }
    }
}