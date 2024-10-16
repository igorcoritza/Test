using Ich.Test.Codere.Domain.InfraContracts;
using Ich.Test.Codere.Domain.Models;
using Ich.Test.Codere.Infrastructure.Models;
using Ich.Test.Core.Serializations;

namespace Ich.Test.Codere.Infrastructure.Implementations
{
    public class TvmazeWebApiService : ITvDataProviderService
    {
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IHttpClientFactory _httpClientFactory;

        public TvmazeWebApiService(IJsonSerializer jsonSerializer, IHttpClientFactory httpClientFactory)
        {
            _jsonSerializer = jsonSerializer;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TvInformationDetail> GetMainInformation(int id, CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateClient(Constants.TvMazeEndpoint);
            var httpResponseMessage = await httpClient.GetAsync($"/shows/{id}", cancellationToken);
            httpResponseMessage.EnsureSuccessStatusCode();
            var contentJson = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
            var getMainInformationResponse = this._jsonSerializer.Deserialize<GetMainInformationResponse>(contentJson);
            return new TvInformationDetail()
            {
                Name = getMainInformationResponse.Name,
                Language = getMainInformationResponse.Language,
                Type = getMainInformationResponse.Type
            };
        }

    
    }
}