using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Entity
{
    public class HumanBodyAttributes
    {
        [JsonProperty("gender")]
        public HumanGender Gender { get; set; }

        [JsonProperty("upper_body_cloth_color")]
        public string UpperBodyClothColorValue { get; set; }

        private static Dictionary<int, string> _colors = typeof(ClothColor).ToDictionary();

        public ClothColor UpperBodyClothColor
        {
            get
            {
                foreach(var d in _colors)
                {
                    if (d.Value.Equals(this.UpperBodyClothColorValue))
                        return (ClothColor)d.Key;
                }

                return ClothColor.UnKnown;
            }
        }

        [JsonProperty("upper_body_cloth_color_rgb")]
        public BodyClothColor UpperBodyClothColorRgb { get; set; }

        [JsonProperty("lower_body_cloth_color")]
        public string LowerBodyClothColorValue { get; set; }

        public ClothColor LowerBodyClothColor
        {
            get
            {
                foreach (var d in _colors)
                {
                    if (d.Value.Equals(this.LowerBodyClothColorValue))
                        return (ClothColor)d.Key;
                }

                return ClothColor.UnKnown;
            }
        }

        [JsonProperty("lower_body_cloth_color_rgb")]
        public BodyClothColor LowerBodyClothColorRgb { get; set; }
    }
}
