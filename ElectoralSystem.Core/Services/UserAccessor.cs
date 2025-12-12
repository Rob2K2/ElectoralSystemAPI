using ElectoralSystem.API.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ElectoralSystem.API.Core.Services
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid? GetUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

            if(userIdClaim != null && Guid.TryParse(userIdClaim.Value, out Guid userId))
                return userId;

            return null;
        }
    }
}
