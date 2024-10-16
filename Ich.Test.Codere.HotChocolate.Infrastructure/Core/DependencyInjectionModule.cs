using Ich.Test.Codere.HotChocolate.Infrastructure.Implementations;
using Ich.Test.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ich.Test.Codere.HotChocolate.Infrastructure.Core
{
    public class DependencyInjectionModule : IDependencyInjectionModule
    {
        public void AddModule(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddGraphQLServer("AddGraphQLServer")
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();
        }
    }
}