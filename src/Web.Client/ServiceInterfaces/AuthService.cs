using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Web.Shared;

namespace Web.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            var result = await _httpClient.PostJsonAsync<RegisterResult>("api/accounts", registerModel);

            return result;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var result = await _httpClient.PostJsonAsync<LoginResult>("api/Login", loginModel);

            if (result.Successful)
            {
                await _localStorage.SetItemAsync("authToken", result.Token);
                ((ApiAuthenticationStateProvider) _authenticationStateProvider).MarkUserAsAuthenticated(result.Token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                return result;
            }

            return result;
        }


        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider) _authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

      

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out var roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles) claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }
            keyValuePairs.TryGetValue(ClaimTypes.NameIdentifier, out var visitoekey);
            claims.Add(new Claim(ClaimTypes.NameIdentifier, visitoekey.ToString()));
            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }


        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;
                case 3:
                    base64 += "=";
                    break;
            }

            return Convert.FromBase64String(base64);
        }
    }
}