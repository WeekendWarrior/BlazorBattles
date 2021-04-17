using BlazorBattles.Server.Data;
using BlazorBattles.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UtilityService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> GetUser()
        {
            var claimNameId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (claimNameId == null) 
                throw new AuthenticationException($"Could not find claim '{ClaimTypes.NameIdentifier}' for user: {_httpContextAccessor.HttpContext.User.Identity.Name}");

            var userId = int.Parse(claimNameId);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            
            return user;
        }
    }
}
