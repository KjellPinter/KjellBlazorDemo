using KjellBlazorDemo.App;
using KjellBlazorDemo.App.Logic;
using KjellBlazorDemo.App.Repositories;
using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.GameLogic;
using KjellBlazorDemo.Engine.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IPlayerManager, PlayerManager>();
builder.Services.AddSingleton<IControls, Controls>();
builder.Services.AddSingleton<Settings>();
builder.Services.AddSingleton<SettingsRepository>();
builder.Services.AddSingleton<ILogic, Logic>();
builder.Services.AddSingleton<Interactions>();
builder.Services.AddSingleton<AssetManager>();


await builder.Build().RunAsync();
