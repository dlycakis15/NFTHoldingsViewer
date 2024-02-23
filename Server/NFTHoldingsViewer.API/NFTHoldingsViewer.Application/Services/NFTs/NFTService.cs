using NFTHoldingsViewer.Infrastructure.Alchemy;
using NFTHoldingsViewer.Infrastructure.Alchemy.DTOs;

namespace NFTHoldingsViewer.Application.Services.NFTs;

public class NFTService : INFTService
{
    private readonly IAlchemyApiClient _alchemyApiClient;

    public NFTService(IAlchemyApiClient alchemyApiClient)
    {
        _alchemyApiClient = alchemyApiClient;
    }
    
    public async Task<Response<OwnedNFTs>> GetOwnedNFTsByAddress(string ownerAddress)
    {
        // add caching capabilities here
        return await _alchemyApiClient.GetNFTsByAddress(ownerAddress);
    }
}