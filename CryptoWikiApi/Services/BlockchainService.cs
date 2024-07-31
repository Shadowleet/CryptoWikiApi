using Microsoft.EntityFrameworkCore;
using CryptoWikiApi.Data;
using CryptoWikiApi.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CryptoWikiApi.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly ApplicationDbContext _context;

        public BlockchainService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blockchain>> GetAll()
        {
            var blockchains = await _context.Blockchains.ToListAsync();
            return blockchains;
        }

        public async Task<Blockchain?> GetOne(int id)
        {
            var blockchain = await _context.Blockchains.FindAsync(id);
            return blockchain;
        }

        public async Task<Blockchain> Add(Blockchain blockchain)
        {
            blockchain.CreatedDate = DateTime.Now;
            blockchain.IsDeleted = false;

            _context.Blockchains.Add(blockchain);
            await _context.SaveChangesAsync();

            return blockchain;
        }

        public async Task<Blockchain?> Update(Blockchain blockchain)
        {
            var blockchainToBeUpdated = await GetOne(blockchain.BlockchainId);

            if (blockchainToBeUpdated == null) return null;

            blockchainToBeUpdated.Name = blockchain.Name;
            await _context.SaveChangesAsync();

            return blockchainToBeUpdated;
        }

        public async Task<Blockchain?> Delete(int id)
        {
            var blockchainToBeDeleted = await GetOne(id);

            if (blockchainToBeDeleted == null) return null;

            blockchainToBeDeleted.IsDeleted = true;
            await _context.SaveChangesAsync();

            return blockchainToBeDeleted;
        }
    }
}

