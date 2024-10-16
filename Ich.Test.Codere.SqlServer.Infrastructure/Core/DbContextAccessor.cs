

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ich.Test.Codere.SqlServer.Infrastructure.Core
{
  public class DbContextAccessor<T> : IDbContextAccessor
  {
    private readonly IServiceScopeFactory  _serviceProvider;

    public DbContextAccessor(IServiceScopeFactory serviceProvider)
    {
      this._serviceProvider = serviceProvider;
    }

    public DbContext GetCurrentContext()
    {
      var serviceScope = _serviceProvider.CreateScope();
      return serviceScope.ServiceProvider.GetRequiredService<T>() as DbContext;
    }
  }
}