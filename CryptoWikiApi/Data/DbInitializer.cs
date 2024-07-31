using CryptoWikiApi.Data;
using CryptoWikiApi.Models.Entities;
using System;
using System.Linq;

namespace CryptoWiki.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            _ = context.Database.EnsureCreated();

            // Seed Blockchains
            if (!context.Blockchains.Any())
            {
                Blockchain[] blockchains = new Blockchain[]
                {
                    new Blockchain { Name = "Salana", CreatedDate = DateTime.Now, IsDeleted = false },
                    new Blockchain { Name = "Ethereum", CreatedDate = DateTime.Now, IsDeleted = false },
                };

                foreach (Blockchain blockchain in blockchains)
                {
                    _ = context.Blockchains.Add(blockchain);
                }

                _ = context.SaveChanges();
            }

            // Retrieve Blockchain IDs after saving
            var blockchainIds = context.Blockchains.ToDictionary(b => b.Name, b => b.BlockchainId);

            // Seed Assets
            if (!context.Assets.Any())
            {
                Asset[] assets = new Asset[]
                {
                    new Asset
                    {
                        Id = "ad8d14e1-3ace-4453-9d5b-ecd5bfc212ed",
                        Name = "Bitcoin",
                        Description = "Bitcoin it is",
                        CreatedDate = DateTime.Now.AddYears(-4),
                        SymbolUrl = "https://www.bitcoin.com",
                        LaunchDate = DateTime.Now.AddYears(-1),
                        Website = "https://www.bitcoin.com",
                        IsDeleted = false,
                        MarketCap = 2000000000,
                        BlockchainId = blockchainIds["Salana"]
                    },
                    new Asset
                    {
                        Id = "31296702-bbd1-4f8a-9629-4209f9238ae2",
                        Name = "Ethereum",
                        Description = "Ethereum it is not",
                        CreatedDate = DateTime.Now.AddYears(-3),
                        SymbolUrl = "https://www.ethereum.org",
                        LaunchDate = DateTime.Now.AddYears(-2),
                        Website = "https://www.ethereum.org",
                        IsDeleted = false,
                        MarketCap = 1234567890,
                        BlockchainId = blockchainIds["Ethereum"]
                    }
                };

                //foreach (Asset asset in assets)
                //{
                //    _ = context.Assets.Add(asset);
                //}

                _ = context.SaveChanges();
            }

            // Seed Users
            if (!context.Users.Any())
            {
                User[] users = new User[]
                {
                    new User
                    {
                        UserId = 5,
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "john.doe@example.com",
                        IsActive = true,
                        IsDeleted = false,
                        DateCreated = DateTime.Now
                    },
                    new User
                    {
                        UserId = 6,
                        FirstName = "Jane",
                        LastName = "Doe",
                        Email = "jane.doe@example.com",
                        IsActive = true,
                        IsDeleted = false,
                        DateCreated = DateTime.Now
                    }
                };

                foreach (User user in users)
                {
                    _ = context.Users.Add(user);
                }

                _ = context.SaveChanges();
            }
        }
    }
}
