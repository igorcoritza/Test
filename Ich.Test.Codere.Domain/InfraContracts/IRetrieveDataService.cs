namespace Ich.Test.Codere.Domain.InfraContracts;

public interface IRetrieveDataService
{
    IQueryable<T> GetData<T>() where T : class;
}