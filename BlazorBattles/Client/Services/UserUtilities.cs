using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class UserUtilities : IUserUtilities
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public UserUtilities(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<int> GetCurrentUserIdAsync()
        {
            var id = -1;

            var authState = await _authStateProvider.GetAuthenticationStateAsync();

            var claimNameId = authState.User.FindFirst(ClaimTypes.NameIdentifier);

            var userId = claimNameId?.Value;

            if (string.IsNullOrEmpty(userId)) return id;

            int.TryParse(userId, out id);

            return id;
        }
    }
}
