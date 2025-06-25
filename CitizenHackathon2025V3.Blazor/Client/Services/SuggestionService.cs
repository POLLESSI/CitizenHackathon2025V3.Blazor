using System.Net.Http.Json;
using CitizenHackathon2025V3.Blazor.Client.Models;

namespace CitizenHackathon2025V2.Blazor.Services
{
    public class SuggestionService
    {
#nullable disable
        private readonly HttpClient _httpClient;

        public SuggestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<SuggestionModel>> GetSuggestionsByUserAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"api/suggestions/user/{userId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SuggestionModel>>();
            }
            return Enumerable.Empty<SuggestionModel>();
        }
        public async Task<bool> SoftDeleteSuggestionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/suggestions/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<SuggestionModel?>> GetLatestSuggestionAsync()
        {
            var response = await _httpClient.GetAsync("api/suggestions/latest");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SuggestionModel?>>();
            }
            return Enumerable.Empty<SuggestionModel?>();
        }
        public async Task<SuggestionModel> SaveSuggestionAsync(SuggestionModel @suggestion)
        {
            var response = await _httpClient.PostAsJsonAsync("api/suggestions", @suggestion);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<SuggestionModel>();
            }
            throw new Exception("Failed to save suggestion");
        }
        //public async SuggestionModel? UpdateSuggestion(SuggestionModel @suggestion)
        //{
        //                var response = await _httpClient.PutAsJsonAsync($"api/suggestions/update", @suggestion);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await response.Content.ReadFromJsonAsync<SuggestionModel>();
        //    }
        //    throw new Exception("Failed to update suggestion");
        //    return null; // Placeholder for actual update logic
        //}
    }
}
