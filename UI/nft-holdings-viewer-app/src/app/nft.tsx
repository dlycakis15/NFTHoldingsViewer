'use client'
import { SetStateAction, useEffect, useState } from 'react';

export default function NftPage() {

  const [walletAddress, setWalletAddress] = useState('');
  const [nfts, setNFTs] = useState([]);

  const handleInputChange = (e: { target: { value: SetStateAction<string>; }; }) => {
    setWalletAddress(e.target.value);
  };


  const fetchNFTs = async () => {
    try {

      const res = await fetch(`http://localhost:5085/api/addresses/${walletAddress}/nfts`);
      const data = await res.json();
      setNFTs(data?.data?.ownedNfts || []);
    } catch (error) {
      console.error('Error fetching NFTs:', error);
    }
  };

  
  useEffect(() => {

      if (walletAddress) {
        fetchNFTs();
      } else {
        setNFTs([]);
      }
  }, [walletAddress]);

  return (
    <div>
      <h1>NFT Wallet Viewer</h1>
      <div>
        <label>
          Enter Ethereum Wallet Address:
          <input style={{color: 'black'}} type="text" value={walletAddress} onChange={handleInputChange} />
        </label>
      </div>
      <div>
        {nfts.length > 0 ? (
          <>
          <h2>NFTs Owned:</h2>
          <div style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fill, minmax(250px, 1fr))', gap: '20px' }}>
            {nfts.map((nft: any) => (
              <div key={nft.id} style={{ border: '1px solid #ccc', borderRadius: '8px', padding: '10px', boxSizing: 'border-box' }}>
                <div style={{ marginTop: '10px' }}>
                  <p style={{ wordWrap: 'break-word' }}>Id: {nft.id}</p>
                  <p style={{ wordWrap: 'break-word' }}>Name: {nft.name}</p>
                </div>
                <img src={nft.image} alt={nft.name} style={{ width: '100%', height: 'auto', objectFit: 'cover', borderRadius: '8px' }} />
              </div>
            ))}
          </div>    
          </>
        ) : (
          <p>No NFTs found for the given wallet address.</p>
        )}
      </div>
    </div>
  );
};