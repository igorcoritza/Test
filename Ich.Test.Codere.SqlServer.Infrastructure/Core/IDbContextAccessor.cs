using Microsoft.EntityFrameworkCore;

namespace Ich.Test.Codere.SqlServer.Infrastructure.Core
{
     public interface IDbContextAccessor
     {
          DbContext GetCurrentContext();
     }
}