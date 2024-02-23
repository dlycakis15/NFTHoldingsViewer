namespace NFTHoldingsViewer.Infrastructure.Alchemy.Models;

public class OwnedNFTs
{
    public List<OwnedNFT> OwnedNfts { get; set; }
}

public class OwnedNFT
{
    public Id Id { get; set; }
    public Metadata Metadata { get; set; }
    public string Balance { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }
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