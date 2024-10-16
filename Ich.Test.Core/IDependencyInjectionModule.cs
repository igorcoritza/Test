using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ich.Test.Core;

public interface IDependencyInjectionModule
{
    void AddModule(IServiceCollection services, IConfiguration configuration);
}