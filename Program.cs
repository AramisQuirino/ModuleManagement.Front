using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ModuleManagement.Front;
using ModuleManagement.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registrar HttpClient para la aplicación Blazor (puede ser el predeterminado)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registrar HttpClient para la API en localhost:7290
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7290/")
});

// Registrar LanguageService
builder.Services.AddScoped<LanguageService>();

// Registrar ICompanyService y su implementación
builder.Services.AddScoped<ICompanyService, CompanyService>();

await builder.Build().RunAsync();