using Domain.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class UserResolverService : IUserResolverService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public UserResolverService(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

        public string? GetUserId() => _httpContextAccessor.HttpContext.User?.Identity?.Name;        
    }
}
