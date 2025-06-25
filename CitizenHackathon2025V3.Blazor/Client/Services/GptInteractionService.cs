using System.Net.Http.Json;
using CitizenHackathon2025V3.Blazor.Client.Models;

namespace CitizenHackathon2025V2.Blazor.Services
{
    public class GptInteractionService
    {
    #nullable disable
        private readonly HttpClient _httpClient;

        public GptInteractionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<SuggestionModel>> GetAllSuggestionsAsync()
        {
            var response = await _httpClient.GetAsync("api/suggestions");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SuggestionModel>>();
            }
            return Enumerable.Empty<SuggestionModel>();
        }
        public async Task<IEnumerable<SuggestionModel>> GetSuggestionsByEventIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/suggestions/event/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SuggestionModel>>();
            }
            return Enumerable.Empty<SuggestionModel>();
        }
        public async Task<IEnumerable<SuggestionModel>> GetSuggestionsByForecastIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/suggestions/forecast/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SuggestionModel>>();
            }
            return Enumerable.Empty<SuggestionModel>();
        }
        public async Task<IEnumerable<SuggestionModel>> GetSuggestionsByTrafficIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/suggestions/traffic/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SuggestionModel>>();
            }
            return Enumerable.Empty<SuggestionModel>();
        }
        public async Task SaveSuggestionAsync(SuggestionModel suggestion)
        {
            var response = await _httpClient.PostAsJsonAsync("api/suggestions", suggestion);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to save suggestion");
            }
        }
        public async Task DeleteSuggestionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/suggestions/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete suggestion");
            }
        }
    }
}
