using CitizenHackathon2025V3.Blazor.Client.Models;
using CitizenHackathon2025V3.Blazor.Client.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;
using Microsoft.AspNet.SignalR.Client;

namespace CitizenHackathon2025V3.Blazor.Client.Pages.Events
{
    public partial class Event
    {
#nullable disable
        [Inject]
        public HttpClient Client { get; set; }  // Injection HttpClient
        [Inject] public EventService EventService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        public List<EventModel> Events { get; set; } = new();
        public int SelectedId { get; set; }
        public Microsoft.AspNetCore.SignalR.Client.HubConnection hubConnection { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (hubConnection == null)
            {
                hubConnection = new HubConnectionBuilder()
                    .WithUrl(Navigation.ToAbsoluteUri("/hubs/eventHub"))
                    .WithAutomaticReconnect()
                    .Build();

                hubConnection.On<string>("ReceiveEvent", HandleEvent);

                await hubConnection.StartAsync();
            }
        }
        private void ClickInfo(int id) => SelectedId = id;
        
        private void HandleEvent(string message)
        {
            Console.WriteLine($"Event received : {message}");

            // Deserialize the incoming message to an EventModel object
            var eventModel = JsonConvert.DeserializeObject<EventModel>(message);

            if (eventModel != null)
            {
                Events.Add(eventModel); // Add the deserialized object to the Events list
                InvokeAsync(StateHasChanged);
            }
            else
            {
                Console.WriteLine("Failed to deserialize the event message.");
            }
        }
        //HubConnection.On<string>("ReceiveEvent", async(message) => await HandleEventAsync(message));

        private async Task HandleEventAsync(string message)
        {
            Console.WriteLine($"Événement reçu : {message}");

            await Task.CompletedTask;
        }
    }
}


























































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.