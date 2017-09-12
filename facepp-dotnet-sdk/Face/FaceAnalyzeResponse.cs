using System;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Face
{
    public class FaceAnalyzeResponse : BaseResponse
    {
        [JsonProperty("faces")]
        public Entity.Face[] Faces { get; set; }
    }
}
