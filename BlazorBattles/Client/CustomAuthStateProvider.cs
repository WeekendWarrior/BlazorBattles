using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorBattles.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public CustomAuthStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Default the state to empty / unauthorized.
            var state = new AuthenticationState(new ClaimsPrincipal());

            // Check local storage for item "isAuthenticated" (this will be changed later to use tokens).
            if (await _localStorageService.GetItemAsync<bool>("isAuthenticated"))
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "Steve") }, "test authentication type");

                var user = new ClaimsPrincipal(identity);

                state = new AuthenticationState(user);
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return new AuthenticationState(new ClaimsPrincipal());
        }
    }
}
