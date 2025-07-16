using CitizenHackathon2025V3.Blazor.Client.Services;
using CitizenHackathon2025V3.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using CitizenHackathon2025V3.Blazor.Client.Common.SignalR;

namespace CitizenHackathon2025V3.Blazor.Client.Pages.CrowdInfos
{
    public partial class CrowdInfo : SignalRComponentBase<CrowdInfoModel>
    {
    #nullable disable
        [Inject] public CrowdInfoService CrowdInfoService { get; set; }

        protected override string HubUrl => "/hubs/crowdhub";
        protected override string HubEventName => "notifynewCrowd";
        protected override Task<List<CrowdInfoModel>> LoadDataAsync()
            => CrowdInfoService.GetAllCrowdInfoAsync().ContinueWith(t => t.Result.ToList());
        private int SelectedId { get; set; } = -1;
        private void ClickInfo(int id) => SelectedId = id;
    }
}







































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.