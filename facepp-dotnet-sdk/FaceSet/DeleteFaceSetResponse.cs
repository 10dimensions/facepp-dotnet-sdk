using System;
using Cody.FacePP.Core;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.FaceSet
{
    public class DeleteFaceSetResponse : BaseResponse
    {
        /// <summary>
        /// FaceSet的标识
        /// </summary>
        [JsonProperty("faceset_token")]
        public string FaceSetToken { get; set; }

        /// <summary>
        /// 用户自定义的FaceSet标识，如果未定义则返回值为空
        /// </summary>
        [JsonProperty("outer_id")]
        public string OuterId { get; set; }
    }
}
