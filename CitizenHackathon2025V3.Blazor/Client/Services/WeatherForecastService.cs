﻿using System.Net.Http.Json;
using CitizenHackathon2025V3.Blazor.Client.Models;

namespace CitizenHackathon2025V3.Blazor.Client.Services
{
    public class WeatherForecastService
    {
    #nullable disable
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddAsync(WeatherForecastModel weatherForecast)
        {
            var response = await _httpClient.PostAsJsonAsync("api/weatherforecast", weatherForecast);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to add weather forecast");
            }
        }
        public async Task<IEnumerable<WeatherForecastModel?>> GetLatestWeatherForecastAsync()
        {
            var response = await _httpClient.GetAsync("api/weatherforecast/current");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecastModel?>>();
            }
            return Enumerable.Empty<WeatherForecastModel?>();
        }
        public async Task<WeatherForecastModel> SaveWeatherForecastAsync(WeatherForecastModel @weatherForecast)
        {
            var response = await _httpClient.PostAsJsonAsync("api/weatherforecast", @weatherForecast);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<WeatherForecastModel>();
            }
            throw new Exception("Failed to save weather forecast");
        }
        public async Task<WeatherForecastModel> GenerateNewForecastAsync()
        {
            var response = await _httpClient.GetAsync("api/weatherforecast/generate");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<WeatherForecastModel>();
            }
            throw new Exception("Failed to generate new weather forecast");
        }
        public async Task<List<WeatherForecastModel>> GetHistoryAsync(int limit = 128)
        {
            var response = await _httpClient.GetAsync($"api/weatherforecast/history?limit={limit}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<WeatherForecastModel>>();
            }
            return new List<WeatherForecastModel>();
        }
        public async Task<List<WeatherForecastModel>> GetAllAsync(WeatherForecastModel forecast)
        {
            var response = await _httpClient.GetAsync("api/weatherforecast/all");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<WeatherForecastModel>>();
            }
            return new List<WeatherForecastModel>();
        }
        public async Task SendWeatherToAllClientsAsync()
        {
            var response = await _httpClient.PostAsync("api/weatherforecast/send", null);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to send weather forecast to all clients");
            }
        }
    }
}















































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.