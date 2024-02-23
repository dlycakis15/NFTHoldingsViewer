namespace NFTHoldingsViewer.Infrastructure.Alchemy.DTOs;

public class OwnedNFTs
{
    public List<OwnedNFT> OwnedNfts { get; set; }
}

public class OwnedNFT
{
    public Contract Contract { get; set; }
    public Id Id { get; set; }
    public Metadata Metadata { get; set; }
}

public class Contract
{
    public string Address { get; set; }
}

public class Id
{
    public string TokenId { get; set; }
    public TokenMetadata TokenMetadata { get; set; }
}

public class TokenMetadata
{
    public string TokenType { get; set; }
}

public class Metadata
{
    public string Image { get; set; }
    public string Name { get; set; }
}