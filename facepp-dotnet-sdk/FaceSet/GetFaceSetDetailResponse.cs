using System;
using System.Collections.Generic;
using System.Linq;
using Cody.FacePP.Core;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.FaceSet
{
    public class GetFaceSetDetailResponse : BaseResponse
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

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("user_data")]
        public string UserData { get; set; }

        [JsonProperty("tags")]
        public string Tagtring { get; set; }

        public List<string> Tags
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.Tagtring))
                    return this.Tagtring.Split(',').ToList();
                return null;
            }
        }

        [JsonProperty("face_count")]
        public int FaceCount { get; set; }

        [JsonProperty("face_tokens")]
        public string[] FaceTokens { get; set; }

        /// <summary>
        /// 用于进行下一次请求。返回值表示排在此次返回的所有 face_token 之后的下一个 face_token 的序号。
        /// 如果返回此字段，则说明未返回完此 FaceSet 下的所有 face_token。可以将此字段的返回值，在下一次调用时传入 start 字段中，获取接下来的 face_token。
        /// 如果没有返回该字段，则说明已经返回此 FaceSet 下的所有 face_token。
        /// </summary>
        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
