using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using CitizenHackathon2025V3.Blazor.Client.DTOs;

namespace CitizenHackathon2025V3.Blazor.Client.Services
{
    public class TrafficServiceBlazor
    {
        private readonly HubConnection _hubConnection;
        public event Action<List<TrafficEventDTO>>? OnTrafficReceived;

        public TrafficServiceBlazor(NavigationManager nav)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(nav.ToAbsoluteUri("/trafficHub"))
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<List<TrafficEventDTO>>("ReceiveTraffic", (trafficEvents) =>
            {
                OnTrafficReceived?.Invoke(trafficEvents);
            });
        }

        public async Task StartAsync()
        {
            if (_hubConnection.State == HubConnectionState.Disconnected)
                await _hubConnection.StartAsync();
        }

        public async Task RequestTraffic()
        {
            await _hubConnection.SendAsync("SendTrafficUpdate");
        }
    }
}


















































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.