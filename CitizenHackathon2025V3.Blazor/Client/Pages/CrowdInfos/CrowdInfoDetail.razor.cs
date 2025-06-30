using CitizenHackathon2025V3.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CitizenHackathon2025V3.Blazor.Client.Pages.CrowdInfos
{
    public partial class CrowdInfoDetail
    {
    #nullable disable
        [Inject]
        public HttpClient? Client { get; set; }
        public CrowdInfoModel? CurrentCrowdInfo { get; set; }
        [Parameter]
        public int Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetCertifications();
        }

        private async Task GetCertifications()
        {
            if (Id <= 0) return;

            using (HttpResponseMessage message = await Client.GetAsync($"api/certifications/{Id}"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentCrowdInfo = JsonConvert.DeserializeObject<CrowdInfoModel>(json);
                }
            }
        }
    }
}





































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.