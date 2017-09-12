using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    public class BodyClothColor
    {
        [JsonProperty("r")]
        public int R { get; set; }

        [JsonProperty("g")]
        public int G { get; set; }

        [JsonProperty("b")]
        public int B { get; set; }
    }
}
