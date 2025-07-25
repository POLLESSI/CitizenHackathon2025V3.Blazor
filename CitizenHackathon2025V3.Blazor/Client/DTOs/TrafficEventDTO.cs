﻿using CitizenHackathon2025V3.Blazor.Client.Enums;
using System.ComponentModel;
using System.Diagnostics;

namespace CitizenHackathon2025V3.Blazor.Client.DTOs
{
    public class TrafficEventDTO
    {
    #nullable disable
        
        public string Id { get; set; } = default!;
        [DisplayName("Type")]
        public string Type { get; set; } = default!;
        [DisplayName("Description")]
        public string Description { get; set; } = default!;
        [DisplayName("Latitude")]
        public double Latitude { get; set; }
        [DisplayName("Longitude")]
        public double Longitude { get; set; }
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }
        [DisplayName("End Time")]
        public int DelayInSeconds { get; set; } // If applicable
        [DisplayName("Severity Level")]
        public TrafficLevel Level { get; set; } // ex: 1=light, 2=moderate, 3=severe
    }
}
























































































// Copyrigtht (c) 2025 Citizen Hackathon https://github.com/POLLESSI/Citizenhackathon2025V3.Blazor.Client. All rights reserved.