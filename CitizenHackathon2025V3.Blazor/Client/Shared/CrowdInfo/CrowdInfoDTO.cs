namespace CitizenHackathon2025V3.Blazor.Client.Shared.CrowdInfo
{
    public class CrowdInfoDTO
    {
    #nullable disable
        public string LocationName { get; set; }
        public int CrowdLevel { get; set; } // 0-5
        public DateTime Timestamp { get; set; }
    }
}
