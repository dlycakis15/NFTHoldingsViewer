using System.Text.Json;
using NFTHoldingsViewer.Infrastructure.Alchemy;
using NFTHoldingsViewer.Infrastructure.Alchemy.Models;
namespace NFTHoldingsViewer.API.UnitTests;
using Xunit;
using NSubstitute;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class AlchemyApiClientTests
{
    private readonly IConfiguration _mockConfiguration;
    
    public AlchemyApiClientTests()
    {
        _mockConfiguration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
        {
            { "Alchemy:GetNFTsForOwnerRouteName", "RouteName" }
        }!).Build(); 
    }
    
    [Fact]
    public async Task GetNFTsByAddress_OwnerAddress_ReturnsNFTs()
    {
        // Arrange
        var okResponse = await File.ReadAllTextAsync(Path.GetFullPath("alchemy_success_response.json"));
        
        const HttpStatusCode expectedStatusCode = HttpStatusCode.OK;

        var expectedNFTs = JsonSerializer.Deserialize<OwnedNFTs>(okResponse);

        var responseMessage = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(okResponse, System.Text.Encoding.UTF8, "application/json")
        };

        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        var httpClient = new HttpClient(new FakeHttpMessageHandler(responseMessage));
        httpClient.BaseAddress = new Uri("http://test.com");

        httpClientFactory.CreateClient("AlchemyApi").Returns(httpClient);



        var alchemyApiClient = new AlchemyApiClient(httpClientFactory, _mockConfiguration);
        var ownerAddress = "TestOwnerAddress";

        // Act
        var result = await alchemyApiClient.GetNFTsByAddress(ownerAddress);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(expectedStatusCode, result.StatusCode);
        Assert.NotEmpty(result.Data.OwnedNfts);
        
        // TODO: test against expectedNFTS and result.Data.OwnedNfts
    }
    
    // TODO: create test for Failure modes
}

public class FakeHttpMessageHandler : DelegatingHandler
{
    private readonly HttpResponseMessage _fakeResponse;

    public FakeHttpMessageHandler(HttpResponseMessage responseMessage)
    {
        _fakeResponse = responseMessage;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_fakeResponse);
    }
}