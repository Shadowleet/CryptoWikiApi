using CryptoWikiApi.Models.Dtos;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace CryptoWikiApi.Models.Entities
{
    public class Blockchain : Base
    {

        public int BlockchainId { get; set; }
        public string Name { get; set; }

        // Navigation Property
        [JsonIgnore]
        public ICollection<AssetDto>? Assets { get; set; }

    }
}
