using LibraryAPI.Areas.Identity.Data;
using LibraryAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class UserService(UserManager<User> _usermanager)
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> users = await _usermanager.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetUser(string id)
        {
            User? user = await _usermanager.FindByIdAsync(id);
            return user;
        }

        public async Task CreateUser(User user)
        {
            await _usermanager.CreateAsync(user);
        }
    }
}
