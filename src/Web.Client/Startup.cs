using Blazor.Extensions;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Web.Client.Services;

namespace Web.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddTransient<HubConnectionBuilder>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}