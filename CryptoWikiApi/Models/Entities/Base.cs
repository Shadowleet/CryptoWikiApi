namespace CryptoWikiApi.Models.Entities
{
    public class Base
    {
        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
