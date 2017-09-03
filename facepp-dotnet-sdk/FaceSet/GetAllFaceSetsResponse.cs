using System;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.FaceSet
{
    public class GetAllFaceSetsResponse : BaseResponse
    {
        [JsonProperty("facesets")]
        public Entity.FaceSet[] FaceSets { get; set; }

        /// <summary>
        /// 用于进行下一次请求。返回值表示排在此次返回的所有 faceset_token 之后的下一个 faceset_token 的序号。
        /// 如果返回此字段，则说明未返回完此 API Key 下的所有 faceset_token。可以将此字段的返回值，在下一次调用时传入 start 字段中，获取接下来的 faceset_token。
        /// 如果没有返回该字段，则说明已经返回此 API Key 下的所有 faceset_token。
        /// </summary>
        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
