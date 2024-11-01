using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Pizzeria.Frontend.AuthenticationProviders
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var anonimous = new ClaimsIdentity();
            var user = new ClaimsIdentity(authenticationType: "test");
            await Task.Delay(3000);
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimous)));
        }
    }
}


