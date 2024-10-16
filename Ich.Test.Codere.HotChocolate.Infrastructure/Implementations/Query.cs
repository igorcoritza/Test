using Ich.Test.Codere.Domain.InfraContracts;
using Ich.Test.Codere.Domain.Models;

namespace Ich.Test.Codere.HotChocolate.Infrastructure.Implementations;

public class Query
{
    private readonly IRetrieveDataService _retrieveDataService;

    public Query(IRetrieveDataService retrieveDataService)
    {
        _retrieveDataService = retrieveDataService;
    }

    [UseFiltering]
    public IQueryable<TvInformationDetail> GetTvInformation()
    {
        return _retrieveDataService.GetData<TvInformationDetail>();
    }
}