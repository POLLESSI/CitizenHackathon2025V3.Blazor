using CitizenHackathon2025V3.Blazor.Client.DTOs;
using CitizenHackathon2025V3.Blazor.Client.Shared.TrafficCondition;
using CitizenHackathon2025V3.Blazor.Client.Shared.WeatherForecast;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Blazored.Toast.Services;
using Microsoft.JSInterop;

namespace CitizenHackathon2025V3.Blazor.Client.Services
{
    public class OutZenSignalRService
    {
        private readonly HubConnection _connection;
        private readonly IToastService _toast;
        private readonly IJSRuntime _jsRuntime;

        public event Action<CrowdInfoUIDTO>? OnCrowdInfoUpdated;
        public event Action<WeatherForecastDTO>? OnWeatherUpdated;
        public event Action<TrafficConditionDTO>? OnTrafficUpdated;

        public bool IsConnected => _connection.State == HubConnectionState.Connected;

        public OutZenSignalRService(NavigationManager navManager, IToastService toast, IJSRuntime jsRuntime)
        {
            _toast = toast;
            _jsRuntime = jsRuntime;

            _connection = new HubConnectionBuilder()
                .WithUrl(navManager.ToAbsoluteUri("/hub/outzen"))
                .WithAutomaticReconnect()
                .Build();

            _connection.On<CrowdInfoUIDTO>("CrowdInfoUpdated", data => OnCrowdInfoUpdated?.Invoke(data));
            _connection.On<WeatherForecastDTO>("WeatherUpdated", data => OnWeatherUpdated?.Invoke(data));
            _connection.On<TrafficConditionDTO>("TrafficUpdated", data => OnTrafficUpdated?.Invoke(data));

            _connection.Reconnecting += async (ex) =>
            {
                await _jsRuntime.InvokeVoidAsync("console.warn", "🔄 Reconnecting to SignalR...");
                _toast.ShowWarning("Reconnexion en cours à OutZen...");
            };

            _connection.Reconnected += async (connectionId) =>
            {
                await _jsRuntime.InvokeVoidAsync("console.info", "✅ Reconnected to SignalR.");
                _toast.ShowSuccess("Reconnexion réussie à OutZen");
            };

            _connection.Closed += async (ex) =>
            {
                await _jsRuntime.InvokeVoidAsync("console.error", "❌ SignalR connection closed.");
                _toast.ShowError("Connexion à OutZen perdue.");
                // Optional: Wait before attempting to reconnect
                await Task.Delay(3000);
                await TryStartAsync();
            };
        }

        public async Task StartAsync()
        {
            try
            {
                if (_connection.State == HubConnectionState.Disconnected)
                {
                    await _connection.StartAsync();
                    _toast.ShowSuccess("Connecté à OutZen (temps réel)");
                    await _jsRuntime.InvokeVoidAsync("console.log", "📡 SignalR started");
                }
            }
            catch (Exception ex)
            {
                _toast.ShowError("Erreur lors de la connexion à OutZen");
                await _jsRuntime.InvokeVoidAsync("console.error", "SignalR failed to start", ex.Message);
            }
        }

        public async Task TryStartAsync()
        {
            if (_connection.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await _connection.StartAsync();
                    _toast.ShowSuccess("Successfully reconnected to OutZen");
                }
                catch
                {
                    _toast.ShowWarning("Unable to reconnect to OutZen");
                }
            }
        }
    }
}




















































































/*// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.*/