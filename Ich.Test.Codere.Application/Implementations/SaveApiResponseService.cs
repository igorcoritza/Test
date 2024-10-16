using Ich.Test.Codere.Domain.ApplicationContratcs;
using Ich.Test.Codere.Domain.InfraContracts;
using Ich.Test.Codere.Domain.Models;

namespace Ich.Test.Codere.Application.Implementations;

public class SaveApiResponseService : ISaveApiResponseService
{
    private readonly ITvDataProviderService _dataProviderService;
    private readonly IStoreDataService _storeDataService;

    public SaveApiResponseService(ITvDataProviderService dataProviderService, IStoreDataService storeDataService)
    {
        _dataProviderService = dataProviderService;
        _storeDataService = storeDataService;
    }
    
    public async Task Execute(int id, CancellationToken cancellationToken)
    {
        var getMainInformationResponse = await _dataProviderService.GetMainInformation(id,cancellationToken);
        await _storeDataService.PersistData<TvInformationDetail>(getMainInformationResponse);
    }
}