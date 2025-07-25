﻿using CitizenHackathon2025V3.Blazor.Client.DTOs;
using CitizenHackathon2025V3.Blazor.Client.Models;
using CitizenHackathon2025V3.Blazor.Client.Shared.Suggestion;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace CitizenHackathon2025V3.Blazor.Client.Services
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
            var response = await _httpClient.GetAsync($"api/suggestion/user/{userId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SuggestionModel>>();
            }
            return Enumerable.Empty<SuggestionModel>();
        }
        public async Task<List<SuggestionDTO>> GetSuggestionsNearbyAsync(double lat, double lng)
        {
            return await _httpClient.GetFromJsonAsync<List<SuggestionDTO>>($"/api/suggestions?lat={lat}&lng={lng}")
                   ?? new List<SuggestionDTO>();
        }
        public async Task<bool> SoftDeleteSuggestionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/suggestion/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<SuggestionModel?>> GetLatestSuggestionAsync()
        {
            var response = await _httpClient.GetAsync("api/suggestion/latest");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SuggestionModel?>>();
            }
            return Enumerable.Empty<SuggestionModel?>();
        }
        public async Task<SuggestionModel> SaveSuggestionAsync(SuggestionModel @suggestion)
        {
            var response = await _httpClient.PostAsJsonAsync("api/suggestion", @suggestion);
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


















































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.