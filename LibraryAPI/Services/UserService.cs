using LibraryAPI.Areas.Identity.Data;
using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class UserService(AuthContext dbcontext)
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> users = await dbcontext.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetUser(string id)
        {
            User? user = await dbcontext.Users.FindAsync(id);
            return user;
        }

        public async Task CreateUser(User user)
        {
            await dbcontext.Users.AddAsync(user);
            await dbcontext.SaveChangesAsync();
        }
    }
}
