using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.DTOs.EarthquakeDTO
{
    public class FeatureCollection
    {
        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }
}
