using Microsoft.AspNetCore.Components.Authorization;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pizzeria.Frontend;
using Pizzeria.Frontend.AuthenticationProviders;
using Pizzeria.Frontend.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSweetAlert2();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//Agregamos el proyecto backend
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7000") });
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddAuthorizationCore();
//Agregamos la Seguridad
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderTest>();

await builder.Build().RunAsync();
