using CitizenHackathon2025V3.Blazor.Client.Services;
using CitizenHackathon2025V3.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace CitizenHackathon2025V3.Blazor.Client.Pages.WeatherForecasts
{
    public partial class WeatherForecast
    {
    #nullable disable
        public HttpClient Client { get; set; }  // Injection HttpClient
        [Inject] public WeatherForecastService WeatherForecastService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }

        public List<WeatherForecastModel> WeatherForecasts { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            WeatherForecasts = (await WeatherForecastService.GetLatestWeatherForecastAsync()).ToList();
            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7254/Hubs/Hubs/WeatherForecastHub"))
                .Build();

            hubConnection.On("NewWeatherForecast", async () =>
            {
                WeatherForecasts = (await WeatherForecastService.GetLatestWeatherForecastAsync()).ToList();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }
        private void ClickInfo(int id) => SelectedId = id;
    }
}






































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.