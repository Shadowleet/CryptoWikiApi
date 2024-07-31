using CryptoWikiApi.Models.Dtos;
using CryptoWikiApi.Models.Entities;
using System;
using System.Collections.Generic;

namespace CryptoWikiApi.Models.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var dto = new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsActive = user.IsActive,
                IsDeleted = user.IsDeleted,
                DateCreated = user.DateCreated
            };

            return dto;
        }

        public static List<UserDto> ToDtos(List<User> users)
        {
            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var dto = ToDto(user);
                if (dto != null)
                {
                    userDtos.Add(dto);
                }
            }

            return userDtos;
        }

        public static User ToEntity(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            var entity = new User
            {
                UserId = userDto.UserId,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                IsActive = userDto.IsActive,
                IsDeleted = userDto.IsDeleted,
                DateCreated = userDto.DateCreated
            };

            return entity;
        }
    }
}
