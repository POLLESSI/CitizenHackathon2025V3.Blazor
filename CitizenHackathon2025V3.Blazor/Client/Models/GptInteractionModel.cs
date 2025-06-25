namespace CitizenHackathon2025V3.Blazor.Client.Models
{
    public class GptInteractionModel
    {
    #nullable disable
        public int Id { get; set; }
        public string Prompt { get; set; }
        public string promptHash { get; set; }
        public string Response { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
