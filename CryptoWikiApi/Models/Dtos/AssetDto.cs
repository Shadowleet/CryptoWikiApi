using CryptoWikiApi.Models.Entities;
using System.Text.Json.Serialization;

namespace CryptoWikiApi.Models.Dtos

{
    public class AssetDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
              
        public string SymbolUrl { get; set; }
        public int MarketCap { get; set; }
        public string Website { get; set; }
        public DateTime? LaunchDate { get; set; }

        
        public int BlockchainId { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
