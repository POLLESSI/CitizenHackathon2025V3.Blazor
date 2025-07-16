using CitizenHackathon2025V3.Blazor.Client.Services;
using CitizenHackathon2025V3.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using CitizenHackathon2025V3.Blazor.Client.Common.SignalR;

namespace CitizenHackathon2025V3.Blazor.Client.Pages.Places
{
    public partial class Place : SignalRComponentBase<PlaceModel>
    {
    #nullable disable
        [Inject] public PlaceService PlaceService { get; set; }

        protected override string HubUrl => "/hubs/placehub";
        protected override string HubEventName => "notifyNewPlace";
        protected override Task<List<PlaceModel>> LoadDataAsync()
            => PlaceService.GetLatestPlaceAsync().ContinueWith(t => t.Result.ToList());
        private int SelectedId { get; set; } = -1;
        private void ClickInfo(int id) => SelectedId = id;
    }
}































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.