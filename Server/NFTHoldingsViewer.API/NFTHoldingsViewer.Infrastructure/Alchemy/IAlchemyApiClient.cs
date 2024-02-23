using System.Net;
using NFTHoldingsViewer.Infrastructure.Alchemy.Models;

namespace NFTHoldingsViewer.Infrastructure.Alchemy;


public class Response<T>
{
    public T Data { get; set; }
    
    public string Error { get; set; }
    
    public HttpStatusCode StatusCode { get; set; }
}

public interface IAlchemyApiClient
{
    Task<Response<OwnedNFTs>> GetNFTsByAddress(string ownerAddress);
}