using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CryptoWikiApi.Models.Dtos
{
    public class BlockchainDto
    {

        public int BlockchainId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10)]
        public string Name { get; set; }
        

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
