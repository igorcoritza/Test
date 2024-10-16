using Ich.Test.Codere.Domain.InfraContracts;
using Ich.Test.Codere.Domain.Models;

namespace Ich.Test.Codere.HotChocolate.Infrastructure.Implementations;

public class Mutation
{
    private readonly IStoreDataService _storeDataService;

    public Mutation(IStoreDataService storeDataService)
    {
        _storeDataService = storeDataService;
    }
    
    public async Task<TvInformationDetail> AddTvInformation(string name)
    {
        var getMainInformationResponse = new TvInformationDetail { Name = name };
        await _storeDataService.PersistData<TvInformationDetail>(getMainInformationResponse);
        return getMainInformationResponse;
    }
}