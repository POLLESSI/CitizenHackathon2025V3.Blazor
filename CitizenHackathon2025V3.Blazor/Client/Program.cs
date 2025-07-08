using Blazored.Toast;
using CitizenHackathon2025V3.Blazor.Client;
using CitizenHackathon2025V3.Blazor.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7254/")
});
builder.Services.AddScoped<CrowdInfoService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<GptInteractionService>();
builder.Services.AddScoped<PlaceService>();
builder.Services.AddScoped<SuggestionService>();
builder.Services.AddScoped<TrafficConditionService>();
builder.Services.AddSingleton<TrafficServiceBlazor>();
builder.Services.AddSingleton<TrafficSignalRService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddBlazoredToast();



await builder.Build().RunAsync();




















































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.