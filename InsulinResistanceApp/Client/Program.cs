global using InsulinResistanceApp.Shared;
global using InsulinResistanceApp.Client.Services;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Http;
global using Blazored.LocalStorage;
global using System.Net.Http.Json;
using InsulinResistanceApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IKategoriaService, KategoriaService>();
builder.Services.AddScoped<IProduktService, ProduktService>();
builder.Services.AddScoped<IPosilekService, PosilekService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
await builder.Build().RunAsync();
