
using Microsoft.EntityFrameworkCore;
using CryptoWikiApi.Models;
using System;
using CryptoWikiApi.Models.Entities;
using CryptoWikiApi.Models.Dtos;

namespace CryptoWikiApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<AssetDto> Assets { get; set; }
        public DbSet<Blockchain> Blockchains{ get; set; }
        public DbSet<User> Users { get; set; }
    }
}
