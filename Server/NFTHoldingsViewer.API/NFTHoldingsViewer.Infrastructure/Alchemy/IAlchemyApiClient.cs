using System.Net;
using NFTHoldingsViewer.Infrastructure.Alchemy.DTOs;

namespace NFTHoldingsViewer.Infrastructure.Alchemy;


public class Response<T>
{
    public T Value { get; set; }
    
    public string Error { get; set; }
    
    public HttpStatusCode StatusCode { get; set; }
}

public interface IAlchemyApiClient
{
    Task<Response<OwnedNFTs>> GetNFTsByAddress(string ownerAddress);
}