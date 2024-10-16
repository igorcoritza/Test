using Hangfire;
using Ich.Test.Core.Host;
using Ich.Test.Factories;

namespace Ich.Test
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var baseMain = WebHost.BaseMain<Startup>(args, RecurringJobsFactory.Setup);
            Task.WaitAll(baseMain.ToArray());
        }
    }
}