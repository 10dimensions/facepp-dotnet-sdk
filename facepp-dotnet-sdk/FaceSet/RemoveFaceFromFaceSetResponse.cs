using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.FaceSet
{
    public class RemoveFaceFromFaceSetResponse : AddFaceToFaceSetResponse
    {
        [JsonProperty("face_removed")]
        public int FaceRemoved { get; set; }
    }
}
