using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValhallaAPI.Options;

namespace ValhallaAPI.Types
{
    public class RouteRequest(List<VPoint> locations, string costing = Costing.Auto, string units = Units.Kilometers)
    {
        public List<VPoint> Locations { get; set; } = locations;
        public string Costing { get; set; } = costing;
        public string Units { get; set; } = units;
        public string Language { get; set; } = "ru-RU";
    }
}
