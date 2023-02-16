using Homework.Client;
using Homework.Client.Services.BaraaService;
using Homework.Client.Services.WareHouseSerive;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBaraaService, BaraaService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();

await builder.Build().RunAsync();
