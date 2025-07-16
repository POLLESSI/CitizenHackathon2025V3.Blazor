using CitizenHackathon2025V3.Blazor.Client.Services;
using CitizenHackathon2025V3.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using CitizenHackathon2025V3.Blazor.Client.Common.SignalR;

namespace CitizenHackathon2025V3.Blazor.Client.Pages.Suggestions
{
    public partial class Suggestion : SignalRComponentBase<SuggestionModel>
    {
    #nullable disable
        [Inject] public SuggestionService SuggestionService { get; set; }

        protected override string HubUrl => "/hubs/suggestionhub";
        protected override string HubEventName => "notifyNewSuggestion";
        protected override Task<List<SuggestionModel>> LoadDataAsync()
            => SuggestionService.GetLatestSuggestionAsync().ContinueWith(t => t.Result.ToList());
        private int SelectedId { get; set; } = -1;
        private void ClickInfo(int id) => SelectedId = id;
    }
}


























































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.