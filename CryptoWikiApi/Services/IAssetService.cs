using CryptoWikiApi.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoWikiApi.Services
{
    public interface IAssetService
    {
        Task<List<Asset>> GetAll();
        Task<Asset?> GetOne(string id);
        Task<Asset> Add(Asset asset);
        Task<Asset?> Update(Asset asset);
        Task<Asset?> Delete(string id);
    }
}
