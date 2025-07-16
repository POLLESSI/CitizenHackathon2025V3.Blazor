using CitizenHackathon2025V3.Blazor.Client.Services;
using CitizenHackathon2025V3.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using CitizenHackathon2025V3.Blazor.Client.Common.SignalR;

namespace CitizenHackathon2025V3.Blazor.Client.Pages.TrafficConditions
{
    public partial class TrafficCondition : SignalRComponentBase<TrafficConditionModel>
    {
    #nullable disable   
        [Inject] public TrafficConditionService TrafficService { get; set; }

        protected override string HubUrl => "/hubs/traffichub";
        protected override string HubEventName => "notifyNewTraffic";
        protected override Task<List<TrafficConditionModel>> LoadDataAsync()
            => TrafficService.GetLatestTrafficConditionAsync().ContinueWith(t => t.Result.ToList());

        private int SelectedId { get; set; } = -1;
        private void ClickInfo(int id) => SelectedId = id;
    }
}































































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.