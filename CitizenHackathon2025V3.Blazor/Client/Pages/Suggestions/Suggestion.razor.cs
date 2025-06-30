using CitizenHackathon2025V3.Blazor.Client.Services;
using CitizenHackathon2025V3.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;

namespace CitizenHackathon2025V3.Blazor.Client.Pages.Suggestions
{
    public partial class Suggestion
    {
    #nullable disable
        public HttpClient Client { get; set; }  // Injection HttpClient
        [Inject] public SuggestionService SuggestionService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }

        public List<SuggestionModel> Suggestions { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Suggestions = (await SuggestionService.GetLatestSuggestionAsync()).ToList();
            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7254/hubs/suggestionHub"))
                .Build();

            hubConnection.On("notifysuggestion", async () =>
            {
                Suggestions = (await SuggestionService.GetLatestSuggestionAsync()).ToList();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }
        private void ClickInfo(int id) => SelectedId = id;
    }
}


























































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.