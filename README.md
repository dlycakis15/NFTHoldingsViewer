# NFTHoldingsViewer

## Setup

### UI

- [UI setup instructions](https://github.com/dlycakis15/NFTHoldingsViewer/blob/master/UI/nft-holdings-viewer-app/README.md).

### Server

- [Server setup instructions](https://github.com/dlycakis15/NFTHoldingsViewer/blob/master/Server/NFTHoldingsViewer.API/README.md).

## Technologies Used

- Next.js
- .NET 7
- Alchemy API
- Digitalocean

## Challenges

### UI
1. Struggled to get anything going for UI so decided to use **next.js** to bootstrap the UI to get me to a point where I could make the changes I needed. 

### Server
1. Structuring the project/class: Even though its a simple project, I wanted to have the ability to switch parts out quickly e.g. Switching to a new NFT API or using a database, this can be done super easy. - Followed layer architecture.

## Assumptions

1. API Rate Limits
- Assumption: The external services and APIs (Alchemy) used for blockchain interaction will not exceed their rate limits under normal operation.
- Risk: High traffic or intensive data requests could exceed API rate limits, causing service disruptions.
- Mitigation: Introduce API rate limiting on APIs.
  
2. Blockchain NFT API (Alchemy)
- Assumption: The external services and APIs (Alchemy) used for blockchain interaction will handle blockchain stability, availability and validity of nodes.
- Risk: Relient on alchemy, disruption to service due to the service being unavailable.
- Mitigation: Introduce fallback options like data caching.
  
3. Data Consistency and Accuracy
- Assumption: The data retrieved from the third-party APIs is accurate and up-to-date.
- Risk: Blockchain data, especially regarding NFT ownership and metadata, can change frequently. Implementing mechanisms to refresh and validate data regularly can help maintain accuracy.
- Mitigation: This is an issue when caching data from the Alchemy API, introducing webhook endpoints to clear data from cache.


## Infrastructure Diagram

- https://excalidraw.com/#room=ea2917e472762c703f97,G71Owt51F2D5oX6zWcWWoQ

## Deployment

https://nft-holdings-viewier-app-n5aua.ondigitalocean.app/

- For the above to work, you will need the Server to be running through http://localhost:5085/.
- The backend is also deployed on digitalocean, however, I had problems with setting up the DNS. Might be a propergation issue?

