using LibraryAPI.Areas.Identity.Data;
using LibraryAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class UserService(UserManager<User> usermanager)
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await usermanager.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetUser(string id)
        {
            var user = await usermanager.FindByIdAsync(id);
            return user;
        }

        public async Task CreateUser(User user)
        {
            await usermanager.CreateAsync(user);
        }

        public async Task UpdateUser(User user)
        {
            await usermanager.UpdateAsync(user);
        }

        public async Task DeleteUser(User user)
        {
            await usermanager.DeleteAsync(user);
        }
    }
}
