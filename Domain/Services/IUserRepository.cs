using Microsoft.AspNetCore.Identity;

namespace Domain.Services
{
    public interface IUserRepository : IRepository<IdentityUser, string>
    {
        public IdentityUser GetUserByUsername(string username);
    }
}
