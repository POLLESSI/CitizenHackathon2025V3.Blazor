using System.Net.Http.Json;
using CitizenHackathon2025V3.Blazor.Client.Models;

namespace CitizenHackathon2025V2.Blazor.Services
{
    public class TrafficConditionService
    {
#nullable disable
        private readonly HttpClient _httpClient;

        public TrafficConditionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<TrafficConditionModel?>> GetLatestTrafficConditionAsync()
        {
            var response = await _httpClient.GetAsync("api/trafficconditions/latest");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<TrafficConditionModel?>>();
            }
            return Enumerable.Empty<TrafficConditionModel?>();
        }
        public async Task<TrafficConditionModel> SaveTrafficConditionAsync(TrafficConditionModel @trafficCondition)
        {
            var response = await _httpClient.PostAsJsonAsync("api/trafficconditions", @trafficCondition);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TrafficConditionModel>();
            }
            throw new Exception("Failed to save traffic condition");
        }
        public TrafficConditionModel? UpdateTrafficCondition(TrafficConditionModel @trafficCondition)
        {
            // This method is not implemented in the original code.
            // You can implement it based on your requirements.
            throw new NotImplementedException("UpdateTrafficCondition method is not implemented.");
        }
    }
}
