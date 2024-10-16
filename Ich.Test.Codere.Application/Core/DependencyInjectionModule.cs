using Ich.Test.Codere.Application.Implementations;
using Ich.Test.Codere.Domain.ApplicationContratcs;
using Ich.Test.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ich.Test.Codere.Application.Core
{
    public class DependencyInjectionModule : IDependencyInjectionModule
    {
        public void AddModule(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISaveApiResponseService, SaveApiResponseService>();
        }
    }
}