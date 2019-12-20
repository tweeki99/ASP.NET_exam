﻿using Exam.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.DTOs
{
    public class Properties
    {
        [JsonProperty("mag")]
        public double Mag { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime Time { get; set; }
    }
}
