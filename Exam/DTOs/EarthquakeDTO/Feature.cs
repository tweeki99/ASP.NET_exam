﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.DTOs.EarthquakeDTO
{
    public class Feature
    {
        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }
}
