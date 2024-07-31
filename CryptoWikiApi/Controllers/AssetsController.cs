using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CryptoWikiApi.Data;
using CryptoWikiApi.Models.Entities;
using CryptoWikiApi.Models.Dtos;

namespace CryptoWikiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AssetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Assets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetDto>>> GetAssets()
        {
            try
            {
                var assets = await _context.Assets.ToListAsync();
                if (assets == null || assets.Count == 0)
                {
                    return NotFound();
                }
                return assets;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving assets: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDto>> GetAsset(string id)
        {
            try
            {
                var asset = await _context.Assets.FindAsync(id);

                if (asset == null)
                {
                    return NotFound();
                }

                return asset;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving asset with id {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Assets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsset(string id, AssetDto asset)
        {
            try
            {
                if (id != asset.Id)
                {
                    return BadRequest();
                }

                var assetToBeUpdated = await _context.Assets.FindAsync(id);

                if (assetToBeUpdated == null)
                {
                    return NotFound();
                }

                assetToBeUpdated.Name = asset.Name;

                _context.Entry(assetToBeUpdated).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating asset with id {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Assets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssetDto>> PostAsset(AssetDto asset)
        {
            try
            {
                if (_context.Assets == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Assets'  is null.");
                }

                asset.Id = Guid.NewGuid().ToString();
                asset.CreatedDate = DateTime.Now;
                asset.IsDeleted = false;

                _context.Assets.Add(asset);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAsset", new { id = asset.Id }, asset);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating asset: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(string id)
        {
            try
            {
                var asset = await _context.Assets.FindAsync(id);

                if (asset == null)
                {
                    return NotFound();
                }

                // Soft delete (mark as deleted)
                asset.IsDeleted = true;
                _context.Entry(asset).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting asset with id {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        private bool AssetExists(string id)
        {
            return _context.Assets.Any(e => e.Id == id);
        }
    }
}
