using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    /// <summary>
    /// 坐标
    /// </summary>
    public class Coord
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }
}
