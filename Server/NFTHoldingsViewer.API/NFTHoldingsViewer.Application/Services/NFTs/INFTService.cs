using NFTHoldingsViewer.Application.Services.NFTs.DTOs;
using NFTHoldingsViewer.Infrastructure.Alchemy;

namespace NFTHoldingsViewer.Application.Services.NFTs;

public interface INFTService
{
    Task<Response<OwnedNFTsDto>> GetOwnedNFTsByAddress(string ownerAddress);
}