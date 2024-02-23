using NFTHoldingsViewer.Infrastructure.Alchemy;
using NFTHoldingsViewer.Infrastructure.Alchemy.DTOs;

namespace NFTHoldingsViewer.Application.Services.NFTs;

public interface INFTService
{
    Task<Response<OwnedNFTs>> GetOwnedNFTsByAddress(string ownerAddress);
}