using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NFTHoldingsViewer.Application.Services.NFTs;

namespace NFTHoldingsViewer.API.Controllers;

[ApiController]
[Route("api/addresses/{ownerAddress}/nfts")]
public class NFTViewerController : ControllerBase
{
    private readonly INFTService _nftService;

    public NFTViewerController(INFTService nftService)
    {
        _nftService = nftService;
    }

    [HttpGet]
    public async Task<ActionResult> GetOwnedNftsByAddress(string ownerAddress)
    {
        var response = await _nftService.GetOwnedNFTsByAddress(ownerAddress);

        if (string.IsNullOrWhiteSpace(response.Error))
        {
            return StatusCode((int)response.StatusCode, response);
        }

        return Ok(response);
    }
}