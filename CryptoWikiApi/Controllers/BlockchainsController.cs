using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CryptoWikiApi.Data;
using CryptoWikiApi.Models.Entities;

namespace CryptoWikiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockchainsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlockchainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Blockchains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blockchain>>> GetBlockchains()
        {
            var blockchains = await _context.Blockchains.ToListAsync();
            if (blockchains == null || blockchains.Count == 0)
            {
                return NotFound();
            }
            return blockchains;
        }

        // GET: api/Blockchains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blockchain>> GetBlockchain(int id)
        {
            var blockchain = await _context.Blockchains.FindAsync(id);

            if (blockchain == null)
            {
                return NotFound();
            }

            return blockchain;
        }

        // PUT: api/Blockchains/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlockchain(int id, Blockchain blockchain)
        {
            if (id != blockchain.BlockchainId)
            {
                return BadRequest();
            }

            var blockchainToBeUpdated = await _context.Blockchains.FindAsync(id);

            if (blockchainToBeUpdated == null)
            {
                return NotFound();
            }

            blockchainToBeUpdated.Name = blockchain.Name;

            _context.Entry(blockchainToBeUpdated).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Blockchains
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Blockchain>> PostBlockchain(Blockchain blockchain)
        {
            if (_context.Blockchains == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Blockchains'  is null.");
            }

            blockchain.CreatedDate = DateTime.Now;
            blockchain.IsDeleted = false;

            _context.Blockchains.Add(blockchain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlockchain", new { id = blockchain.BlockchainId }, blockchain);
        }

        // DELETE: api/Blockchains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlockchain(int id)
        {
            var blockchain = await _context.Blockchains.FindAsync(id);

            if (blockchain == null)
            {
                return NotFound();
            }

            blockchain.IsDeleted = true;

            _context.Entry(blockchain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        private bool BlockchainExists(int id)
        {
            return (_context.Blockchains?.Any(e => e.BlockchainId == id)).GetValueOrDefault();
        }
    }
}
