using CitizenHackathon2025V3.Blazor.Client.DTOs;
using CitizenHackathon2025V3.Blazor.Client.Models;

namespace CitizenHackathon2025V3.Blazor.Client.Services
{
    public interface ISignalRService
    {
        event Func<object, Task> OnNotify;
        event Func<CrowdInfoUIDTO, Task> OnCrowdInfoUpdated;
        event Func<TrafficConditionModel, Task> OnTrafficUpdated;

        Task StartAsync(string hubUrl, string hubEventName);
        Task StopAsync();
    }
}
