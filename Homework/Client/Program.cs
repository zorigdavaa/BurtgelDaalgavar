global using Homework.Client.Services;
using Homework.Client;
using Homework.Client.Services;
using Homework.Client.Services.BaraaService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBaraaService, BaraaService>();
builder.Services.AddScoped<JsInterop>();

await builder.Build().RunAsync();
