namespace CitizenHackathon2025V3.Blazor.Client.Shared.TrafficCondition
{
    public class TrafficConditionDTO
    {
    #nullable disable
        public string IncidentType { get; set; }
        public string CongestionLevel { get; set; } // eg. "Severe", "Moderate"
        public DateTime DateCondition { get; set; }
    }
}
