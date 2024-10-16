using Ich.Test.Codere.Domain.InfraContracts;
using Ich.Test.Codere.SqlServer.Infrastructure.Core;

namespace Ich.Test.Codere.SqlServer.Infrastructure.Implementations;

public class StoreDataOnDataBaseService : IStoreDataService
{
    private readonly IDbContextAccessor _dbContextAccessor;

    public StoreDataOnDataBaseService(IDbContextAccessor dbContextAccessor)
    {
        _dbContextAccessor = dbContextAccessor;
    }
    
    public async Task PersistData<T>(T getMainInformationResponse) where T : class
    {
        var currentContext = _dbContextAccessor.GetCurrentContext();
        var dbSet = currentContext.Set<T>();
        dbSet.Add(getMainInformationResponse);
        await currentContext.SaveChangesAsync();
    }
}