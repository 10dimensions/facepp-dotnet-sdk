using System;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.HumanBody
{
    public class HumanBodyDetectResponse : BaseResponse
    {
        [JsonProperty("humanbodies")]
        public Entity.HumanBody[] HumanBodies { get; set; }

        [JsonProperty("image_id")]
        public string ImageId { get; set; }
    }
}
