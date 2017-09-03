using System;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.FaceSet
{
    public class CreateFaceSetResponse : BaseResponse
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

        /// <summary>
        /// 本次操作成功加入FaceSet的face_token数量
        /// </summary>
        [JsonProperty("face_added")]
        public int FaceAdded { get; set; }

        /// <summary>
        /// 操作结束后FaceSet中的face_token总数量
        /// </summary>
        [JsonProperty("face_count")]
        public int FaceCount { get; set; }

        /// <summary>
        /// 无法被加入FaceSet的face_token以及原因
        /// </summary>
        [JsonProperty("failure_detail")]
        public FailureDetail[] Failures { get; set; }
    }

    public class FailureDetail
    {
        /// <summary>
        /// 人脸标识
        /// </summary>
        [JsonProperty("face_token")]
        public string FaceToken { get; set; }

        /// <summary>
        /// 不能被添加的原因，包括 INVALID_FACE_TOKEN 人脸表示不存在 ，QUOTA_EXCEEDED 已达到FaceSet存储上限
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
