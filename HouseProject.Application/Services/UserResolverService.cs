using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserResolverService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUser()
        {
            return _httpContextAccessor.HttpContext.User?.Identity?.Name;
        }
    }
}
