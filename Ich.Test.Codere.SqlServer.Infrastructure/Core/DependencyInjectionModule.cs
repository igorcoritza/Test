using Ich.Test.Codere.Domain.InfraContracts;
using Ich.Test.Codere.SqlServer.Infrastructure.Implementations;
using Ich.Test.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ich.Test.Codere.SqlServer.Infrastructure.Core
{
    public class DependencyInjectionModule : IDependencyInjectionModule
    {
        public void AddModule(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRetrieveDataService, RetrieveDataFromDatabaseService>();
            services.AddScoped<IDbContextAccessor, DbContextAccessor<ApplicationDbContext>>();
            services.AddScoped<IStoreDataService, StoreDataOnDataBaseService>();
            services.AddDbContext<ApplicationDbContext>(builder =>
            {
                builder.UseSqlite("Data Source=main.db");
            });
        }
    }
}