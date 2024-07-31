using CryptoWikiApi.Models.Dtos;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using CryptoWikiApi.Models.Mappers;
using CryptoWikiApi.Models.Entities;

namespace CryptoWikiApi.Models.Mappers
{
    public class BlockchainMapper
    {

        public static BlockchainDto ToDto(Blockchain blockchain)
        {
            if (blockchain == null)
            {
                throw new ArgumentNullException(nameof(blockchain));
            }
            var dto = new BlockchainDto
            {
                BlockchainId = blockchain.BlockchainId,
                Name = blockchain.Name,
                IsDeleted= blockchain.IsDeleted,
                CreatedDate = blockchain.CreatedDate,
            };
            return dto;
        }
        public static List<BlockchainDto> ToDtos(List<Blockchain> blochains)
        {
            var blockchainDtos = new List<BlockchainDto>();
            foreach (var  blochain in blochains)
            {
                var dto = ToDto(blochain);
                if(dto != null)
                {
                    blockchainDtos.Add(dto);
                }

            }
            return blockchainDtos;
        }

        public static Blockchain ToEntity(BlockchainDto blockchain)
        {
            if (blockchain == null)
            {
                throw new ArgumentNullException(nameof(blockchain));
            }

            var entity = new Blockchain
            {
                BlockchainId = blockchain.BlockchainId,
                Name = blockchain.Name,
                IsDeleted = blockchain.IsDeleted,
                CreatedDate = blockchain.CreatedDate,

            };

            return entity;
        }
    }
}
