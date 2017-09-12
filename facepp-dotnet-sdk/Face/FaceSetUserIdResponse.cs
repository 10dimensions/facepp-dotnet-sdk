using System;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Face
{
    public class FaceSetUserIdResponse : BaseResponse
    {
        [JsonProperty("face_token")]
        public string FaceToken { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
