using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class UserContextAccessorService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextAccessorService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUser()
        {
            return _httpContextAccessor.HttpContext.User?.Identity?.Name;
        }
    }
}
