using CryptoWikiApi.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoWikiApi.Services
{
    public interface IBlockchainService
    {
        Task<List<Blockchain>> GetAll();
        Task<Blockchain?> GetOne(int id);
        Task<Blockchain> Add(Blockchain blockchain);
        Task<Blockchain?> Update(Blockchain blockchain);
        Task<Blockchain?> Delete(int id);
    }
}
