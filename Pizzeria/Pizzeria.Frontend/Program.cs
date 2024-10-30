using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pizzeria.Frontend;
using Pizzeria.Frontend.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSweetAlert2();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//Agregamos el proyecto backend
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7000") });
builder.Services.AddScoped<IRepository, Repository>();
await builder.Build().RunAsync();
