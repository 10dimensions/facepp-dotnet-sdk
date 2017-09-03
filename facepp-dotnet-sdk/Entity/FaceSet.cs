using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    public class FaceSet
    {
        [JsonProperty("faceset_token")]
        public string FaceSetToken { get; set; }

        [JsonProperty("outer_id")]
        public string OuterId { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("tags")]
        public string TagString { get; set; }

        public List<string> Tags
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.TagString))
                    return null;
                return this.TagString.Split(',').ToList();
            }
        }
    }
}
