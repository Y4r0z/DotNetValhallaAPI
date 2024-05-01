using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace ValhallaAPI.Types
{
    public class RouteTripLocation()
    {
        public required string Type { get; set; }
        [JsonPropertyName("lat")] public required double Latitude { get;set; }
        [JsonPropertyName("lon")] public double Longitude { get;set; }
        public string? SideOfStreet { get; set; }
        public required int OriginalIndex { get; set; }
    }

    public class RouteTripManeuver
    {
        public required int Type { get; set; }
        public string? Instruction { get; set; }
        public string? VerbalTransitionAlertInstruction { get; set; }
        public string? VerbalPreTransitionInstruction { get; set; }
        public string? VerbalSuccinctTransitionInstruction { get; set; }
        public string? VerbalPostTransitionInstruction { get; set; }
        public List<string>? StreetNames { get; set; } = [];
        public required double Time { get; set; }
        public required double Length { get; set; }
        public required double Cost { get; set; }
        public required int BeginShapeIndex { get; set; }
        public required int EndShapeIndex { get; set; }
        public bool? VerbalMultiCue { get; set; }
        public required string TravelMode { get; set; }
        public required string TravelType { get; set; }
    }

    public class RouteTripSummary
    {
        public bool HasTimeRestrictions { get; set; }
        public bool HasToll { get; set; }
        public bool HasHighway { get; set; }
        public bool HasFerry { get; set; }
        [JsonPropertyName("min_lat")] public double MinLatitude { get; set; }
        [JsonPropertyName("min_lon")] public double MinLongitude { get; set; }
        [JsonPropertyName("max_lat")] public double MaxLatitude { get; set; }
        [JsonPropertyName("max_lon")] public double MaximumLongitude { get; set; }
        public double Time { get; set; }
        public double Length { get; set; }
        public double Cost { get; set; }
    }

    public class RouteTripLeg
    {
        public List<RouteTripManeuver> Maneuvers { get; set; } = [];
        public required RouteTripSummary Summary { get; set; }
        public required string Shape { get; set; }
    }

    public class RouteTrip
    {
        public required List<RouteTripLocation> Locations { get; set; } = [];
        public required List<RouteTripLeg> Legs { get; set; } = [];
        public required RouteTripSummary Summary { get; set;}
        public required string StatusMessage { get; set; }
        public required int Status { get; set; }
        public required string Units { get; set; }
        public required string Language { get; set; }
    }

    internal class RouteTripWrapper
    {
        public required RouteTrip Trip { get; set; }
    }
}
