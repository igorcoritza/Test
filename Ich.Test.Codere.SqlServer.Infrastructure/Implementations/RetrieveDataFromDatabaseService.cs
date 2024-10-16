using Ich.Test.Codere.Domain.InfraContracts;
using Ich.Test.Codere.SqlServer.Infrastructure.Core;

namespace Ich.Test.Codere.SqlServer.Infrastructure.Implementations
{
    public class RetrieveDataFromDatabaseService : IRetrieveDataService
    {
        private readonly IDbContextAccessor _dbContextAccessor;

        public RetrieveDataFromDatabaseService(IDbContextAccessor dbContextAccessor)
        {
            _dbContextAccessor = dbContextAccessor;
        }
        public IQueryable<T> GetData<T>() where T : class
        {
            var currentContext = _dbContextAccessor.GetCurrentContext();
            var dbSet = currentContext.Set<T>();
            return dbSet.AsQueryable();
        }
    }
}