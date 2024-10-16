using Ich.Test.Codere.Domain.Models;

namespace Ich.Test.Codere.Domain.InfraContracts;

public interface ITvDataProviderService
{
    Task<TvInformationDetail> GetMainInformation(int id, CancellationToken cancellationToken);
}