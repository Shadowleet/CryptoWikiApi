using System.Text.Json.Serialization;

namespace CryptoWikiApi.Models.Entities
{
    public class Asset : Base
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
              
        public string SymbolUrl { get; set; }
        public int MarketCap { get; set; }
        public string Website { get; set; }
        public DateTime? LaunchDate { get; set; }

        //Foreign Key
        public int BlockchainId { get; set; }

        // Navigation Properties
        [JsonIgnore]
        public Blockchain? Blockchain { get; set; }
    }
}
