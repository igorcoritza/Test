using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Ich.Test.Core.Host
{
    public abstract class WebHost
    {
        public static List<Task> BaseMain<TStartup>(string[] args, Func<IServiceProvider, Task> postBuildActions)
            where TStartup : class
        {
            var build = CreateHostBuilder<TStartup>(args).Build();
            return [build.RunAsync(), postBuildActions(build.Services)];
        }

        private static IHostBuilder CreateHostBuilder<TStartup>(string[] args)
            where TStartup : class
        {
            return Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    _ = config
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json", false, true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args)
                        .AddUserSecrets<TStartup>();
                })
                .ConfigureServices(services => { })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TStartup>();
                });
        }
    }
}