using CitizenHackathon2025V3.Blazor.Client.Services;
using CitizenHackathon2025V3.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using CitizenHackathon2025V3.Blazor.Client.Common.SignalR;

namespace CitizenHackathon2025V3.Blazor.Client.Pages.Users
{
    public partial class User : SignalRComponentBase<UserModel>
    {
        [Inject] public UserService UserService { get; set; }

        protected override string HubUrl => "/hubs/userhub";
        protected override string HubEventName => "notifyNewUser";
        protected override Task<List<UserModel>> LoadDataAsync()
            => UserService.GetAllActiveUsersAsync().ContinueWith(t => t.Result.ToList());
        private int SelectedId { get; set; } = -1;
        private void ClickInfo(int id) => SelectedId = id;
    }
}
















































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.