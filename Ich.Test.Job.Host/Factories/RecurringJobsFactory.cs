using Ich.Test.Codere.SqlServer.Infrastructure.Core;

namespace Ich.Test.Factories
{
    public class RecurringJobsFactory
    {
        public static async Task Setup(IServiceProvider serviceProvider)
        {   
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await context.Database.EnsureCreatedAsync();
            }
        }
    }
}