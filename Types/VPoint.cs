using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ValhallaAPI.Types
{
    public class VPoint(double latitude, double longitude)
    {
        [JsonPropertyName("lat")] public double Latitude { get; set; } = latitude;
        [JsonPropertyName("lon")] public double Longitude { get; set; } = longitude;
    }
}
