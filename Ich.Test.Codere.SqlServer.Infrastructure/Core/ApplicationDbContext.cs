using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Ich.Test.Codere.SqlServer.Infrastructure.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var configurations = this.GetType()
                                        .GetTypeInfo()
                                        .Assembly.ExportedTypes
                                        .Where(x => typeof(IEntityTypeConfiguration).IsAssignableFrom(x) && !x.GetTypeInfo().IsAbstract);

            foreach (var configuration in configurations)
            {
                var config = Activator.CreateInstance(configuration) as IEntityTypeConfiguration;
                config?.Configure(modelBuilder);
            }
        }
    }
}