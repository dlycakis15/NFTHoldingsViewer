using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using NFTHoldingsViewer.Infrastructure.Alchemy.Models;

namespace NFTHoldingsViewer.Infrastructure.Alchemy;

public class AlchemyApiClient : IAlchemyApiClient
{
    private readonly HttpClient _httpClient;

    private readonly string _getOwnedNFTsRouteName;
    
    public AlchemyApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient("AlchemyApi");

        _getOwnedNFTsRouteName = configuration["Alchemy:GetNFTsForOwnerRouteName"]!;
    }

    public async Task<Response<OwnedNFTs>> GetNFTsByAddress(string ownerAddress)
    {
        var httpRequestMessage =
            new HttpRequestMessage(HttpMethod.Get,
                $"{_httpClient.BaseAddress}/{_getOwnedNFTsRouteName}?owner={ownerAddress}&pageSize=20");

        var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
        
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            return new Response<OwnedNFTs>()
            {
                StatusCode = httpResponseMessage.StatusCode,
                Error = await httpResponseMessage.Content.ReadAsStringAsync(),
            };
        }
        
        await using var contentStream =
            await httpResponseMessage.Content.ReadAsStreamAsync();

        return new Response<OwnedNFTs>()
        {
            StatusCode = httpResponseMessage.StatusCode,
            Data = JsonSerializer.Deserialize<OwnedNFTs>(contentStream, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true
            })
        };
    }
}