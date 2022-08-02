using KjellBlazorDemo.App;
using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IPlayer, Player>();
builder.Services.AddSingleton<IControls, Controls>();
builder.Services.AddSingleton<Settings>();

await builder.Build().RunAsync();
