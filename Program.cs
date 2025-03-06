using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ModuleManagement.Web.Client.Services;
using ModuleManagement.Web.Client;
//using Microsoft.AspNetCore.ResponseCompression;
//using ModuleManagement.Web.Client.Hubs;
//using Microsoft.AspNetCore.Builder;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddSignalRCore();

//builder.Services.AddResponseCompression(opts =>
//{
//    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
//        ["application/octet-stream"]);
//});

// Registrar HttpClient para la aplicación Blazor (puede ser el predeterminado)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registrar HttpClient para la API en localhost:7290
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7290/")
});

builder.Services.AddSingleton<ColorSchemeStateService>();
builder.Services.AddScoped<IClientService, ClientService>();

// Registrar el servicio de configuración
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();

// Registrar otros servicios
builder.Services.AddScoped<LanguageService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ValidationMessageService>();

await builder.Build().RunAsync();