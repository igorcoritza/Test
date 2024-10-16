using Ich.Test.Codere.Application.Implementations;
using Ich.Test.Codere.Domain.InfraContracts;
using Ich.Test.Codere.Domain.Models;
using Moq;
using Xunit;

namespace Ich.Test.Codere.Application.UnitTest;

public class SaveApiResponseServiceTest
{
    [Fact]
    public async Task When_SaveApiResponseService_Execute_And_Succedd()
    {
        //Arrange
        var id = 4;
        var tvInformationDetail = new TvInformationDetail()
        {
            Name = "name"
        };
        var tvDataProviderService = new Mock<ITvDataProviderService>(MockBehavior.Strict);
        var storeDataService = new Mock<IStoreDataService>(MockBehavior.Strict);
        var saveApiResponseService = new SaveApiResponseService(tvDataProviderService.Object, storeDataService.Object);
        tvDataProviderService.Setup(service => service.GetMainInformation(id, It.IsAny<CancellationToken>())).ReturnsAsync(() => tvInformationDetail);
        storeDataService.Setup(service => service.PersistData(tvInformationDetail)).Returns(() => Task.CompletedTask);
        //Act
        await saveApiResponseService.Execute(4, CancellationToken.None);
        //Assert
        tvDataProviderService.Verify(service => service.GetMainInformation(id, It.IsAny<CancellationToken>()), Times.Once);
        storeDataService.Verify(service => service.PersistData(tvInformationDetail), Times.Once );
    }
}