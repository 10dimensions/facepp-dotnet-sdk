using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Face
{
    public class FaceDetectResponse : Cody.FacePP.Core.BaseResponse
    {
        [JsonProperty("faces")]
        public Entity.Face[] Faces { get; set; }

        [JsonProperty("image_id")]
        public string ImageId { get; set; }
    }
}
