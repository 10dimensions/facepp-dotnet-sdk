using System;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.HumanBody
{
    public class GestureDetectResponse : BaseResponse
    {
        [JsonProperty("hands")]
        public Entity.Hand[] Hands { get; set; }

        [JsonProperty("image_id")]
        public string ImageId { get; set; }
    }
}
