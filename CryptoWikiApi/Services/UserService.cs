using Microsoft.EntityFrameworkCore;
using CryptoWikiApi.Data;
using CryptoWikiApi.Models.Entities;

namespace CryptoWikiApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetOne(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user;
        }

        public async Task<User> Add(User user)
        {
            user.DateCreated = DateTime.Now;
            user.IsDeleted = false;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> Update(User user)
        {
            var userToBeUpdated = await GetOne(user.UserId);

            if (userToBeUpdated == null) return null;

            userToBeUpdated.FirstName = user.FirstName;
            userToBeUpdated.LastName = user.LastName;
            userToBeUpdated.Email = user.Email;
            userToBeUpdated.IsActive = user.IsActive;
            userToBeUpdated.IsDeleted = user.IsDeleted;
            userToBeUpdated.DateCreated = user.DateCreated;

            await _context.SaveChangesAsync();

            return userToBeUpdated;
        }

        public async Task<User?> Delete(int userId)
        {
            var userToBeDeleted = await GetOne(userId);

            if (userToBeDeleted == null) return null;

            userToBeDeleted.IsDeleted = true;

            await _context.SaveChangesAsync();

            return userToBeDeleted;
        }
    }
}
