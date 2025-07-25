using Blazored.Toast.Services;
using CitizenHackathon2025V3.Blazor.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CitizenHackathon2025V3.Blazor.Client
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject] private IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] private IToastService ToastService { get; set; } = default!;
        [Inject] private OutZenSignalRService SignalRService { get; set; } = default!;

        private string GetBackgroundImage()
        {
            var hour = DateTime.Now.Hour;

            return hour switch
            {
                < 8 => "/images/dawn.jpg",
                < 17 => "/images/day.jpg",
                < 20 => "/images/sunset.jpg",
                _ => "/images/night.jpg"
            };
        }

        protected override async Task OnInitializedAsync()
        {
            await SignalRService.StartAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender) return;

            try
            {
                var module = await JSRuntime.InvokeAsync<IJSObjectReference>(
                    "import",
                    "./js/layoutCanvas.js"
                );

                await module.InvokeVoidAsync("startBackgroundCanvas");

                // Appels initiaux JS après le rendu
                await JSRuntime.InvokeVoidAsync("GeometryCanvas.init");
                await JSRuntime.InvokeVoidAsync("initializeLeafletMap");
                await JSRuntime.InvokeVoidAsync("initScrollAnimations");
                await JSRuntime.InvokeVoidAsync("signalrInterop.startConnection", "/crowdHub");
                await Task.Delay(100); // Laisse du temps à la connection
                await JSRuntime.InvokeVoidAsync("initParallax");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ JS error in MainLayout: {ex.Message}");
            }
        }

        private void ShowTestToast()
        {
            ToastService.ShowSuccess("It works!");
        }
        private string GetTimeClass()
        {
            var hour = DateTime.Now.Hour;
            if (hour < 8) return "dawn";
            if (hour < 17) return "day";
            if (hour < 20) return "sunset";
            return "night";
        }
    }
}





































































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.