using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoWikiApi.Models.Entities;

namespace CryptoWikiApi.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User?> GetOne(int userId);
        Task<User> Add(User user);
        Task<User?> Update(User user);
        Task<User?> Delete(int userId);
    }
}
