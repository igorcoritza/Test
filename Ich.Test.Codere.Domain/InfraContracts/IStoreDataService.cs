namespace Ich.Test.Codere.Domain.InfraContracts;

public interface IStoreDataService
{
    Task PersistData<T>(T getMainInformationResponse)  where T : class;
}