using NFTHoldingsViewer.Application.Services.NFTs.DTOs;
using NFTHoldingsViewer.Infrastructure.Alchemy;

namespace NFTHoldingsViewer.Application.Services.NFTs;

public class NFTService : INFTService
{
    private readonly IAlchemyApiClient _alchemyApiClient;

    public NFTService(IAlchemyApiClient alchemyApiClient)
    {
        _alchemyApiClient = alchemyApiClient;
    }
    
    public async Task<Response<OwnedNFTsDto>> GetOwnedNFTsByAddress(string ownerAddress)
    {
        // add caching capabilities here
        var response = await _alchemyApiClient.GetNFTsByAddress(ownerAddress);

        if (response.Data == null)
        {
            return new Response<OwnedNFTsDto>()
            {
                Error = response.Error,
                StatusCode = response.StatusCode
            };
        }

        return new Response<OwnedNFTsDto>()
        {
            Data = OwnedNFTsDto.ToDtos(response.Data.OwnedNfts),
            StatusCode = response.StatusCode
        };
    }
}