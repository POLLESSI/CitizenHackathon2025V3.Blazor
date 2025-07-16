using CitizenHackathon2025V3.Blazor.Client.Services;
using CitizenHackathon2025V3.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using CitizenHackathon2025V3.Blazor.Client.Common.SignalR;

namespace CitizenHackathon2025V3.Blazor.Client.Pages.Events
{
    public partial class Event : SignalRComponentBase<EventModel>
    {
    #nullable disable
        [Inject] public EventService EventService { get; set; }

        protected override string HubUrl => "/hubs/eventhub";
        protected override string HubEventName => "notifyNewEvent";
        protected override Task<List<EventModel>> LoadDataAsync()
            => EventService.GetLatestEventAsync().ContinueWith(t => t.Result.ToList());
        private int SelectedId { get; set; } = -1;
        private void ClickInfo(int id) => SelectedId = id;
    }
}


























































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.