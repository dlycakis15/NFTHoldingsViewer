using NFTHoldingsViewer.Infrastructure.Alchemy.Models;

namespace NFTHoldingsViewer.Application.Services.NFTs.DTOs;

public class OwnedNFTsDto
{
    public IEnumerable<OwnedNFTDto> OwnedNfts { get; set; }

    public static OwnedNFTsDto ToDtos(IEnumerable<OwnedNFT> models)
    {
        return new OwnedNFTsDto()
        {
            OwnedNfts = models.Select(OwnedNFTDto.ToDto).DistinctBy(e => e.Id)
        };
    }
}

public class OwnedNFTDto
{
    public string Id { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public string TokenType { get; set; }


    public static OwnedNFTDto ToDto(OwnedNFT model)
    {
        return new OwnedNFTDto()
        {
            Id = model.Id.TokenId,
            Image = model.Metadata.Image,
            Name = model.Metadata.Name,
            TokenType = model.Id.TokenMetadata.TokenType
        };
    }
}

