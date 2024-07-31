using CryptoWikiApi.Models.Dtos;
using NuGet.ContentModel;
using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using CryptoWikiApi.Models.Entities;
using Asset = CryptoWikiApi.Models.Entities.Asset;




namespace CryptoWikiApi.Models.Mappers
{
    public class AssetMapper
    {
        public static AssetDto ToDto(Asset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }

            var dto = new AssetDto
            {
                Id = asset.Id,
                Name = asset.Name,
                Description = asset.Description,
                SymbolUrl = asset.SymbolUrl,
                MarketCap = asset.MarketCap,
                Website = asset.Website,
                LaunchDate = asset.LaunchDate,
                BlockchainId = asset.BlockchainId,
                CreatedDate = asset.CreatedDate,
                IsDeleted = asset.IsDeleted
            };

            return dto;
        }

        public static List<AssetDto> ToDtos(List<Asset> assets)
        {
            var assetDtos = new List<AssetDto>();

            foreach (var asset in assets)
            {
                var dto = ToDto(asset);
                if (dto != null)
                {
                    assetDtos.Add(dto);
                }
            }

            return assetDtos;
        }

        public static Asset ToEntity(AssetDto asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }

            var entity = new Asset
            {
                Id = asset.Id,
                Name = asset.Name,
                Description = asset.Description,
                SymbolUrl = asset.SymbolUrl,
                MarketCap = asset.MarketCap,
                Website = asset.Website,
                LaunchDate = asset.LaunchDate,
                BlockchainId = asset.BlockchainId,
                CreatedDate = asset.CreatedDate,
                IsDeleted = asset.IsDeleted
            };

            return entity;
        }
    }
}
