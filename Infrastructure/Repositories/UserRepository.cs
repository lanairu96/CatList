using Infrastructure.Contexts;
using Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<IdentityUser, string>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public IdentityUser GetUserByUsername(string username) => _context.Users.FirstOrDefault(c => c.UserName == username);
    }
}
