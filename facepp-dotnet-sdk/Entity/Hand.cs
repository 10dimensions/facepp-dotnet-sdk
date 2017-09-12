using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    public class Hand
    {
        [JsonProperty("hand_rectangle")]
        public HandRectangle HandRectangle { get; set; }

        [JsonProperty("gesture")]
        public Gesture Gesture { get; set; }
    }
}
