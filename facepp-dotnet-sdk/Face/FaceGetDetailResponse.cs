using System;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Face
{
    public class FaceGetDetailResponse : BaseResponse
    {
        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        [JsonProperty("face_token")]
        public string FaceToken { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("face_rectangle")]
        public Entity.FaceRectangle FaceRectangle { get; set; }

        [JsonProperty("facesets")]
        public Entity.FaceSet[] FaceSets { get; set; }
    }
}
