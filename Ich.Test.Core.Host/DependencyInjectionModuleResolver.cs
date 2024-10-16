using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ich.Test.Core.Host
{
    public static class DependencyInjectionModuleResolver
    {
        public static void AddDependencies(this IServiceCollection serviceCollection, IConfiguration configuration, params Assembly[] optionalParams)
        {
            var interfaceType = typeof(IDependencyInjectionModule);
            foreach (var assembly in optionalParams)
            {
                var types = assembly.GetTypes().Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass);
                foreach (var type in types)
                {
                    var instance = Activator.CreateInstance(type) ?? throw new Exception($"Could not activate {type.FullName}");
                    var specificInstance = (IDependencyInjectionModule)instance;
                    specificInstance.AddModule(serviceCollection, configuration);
                }
            }
        }
    }
}