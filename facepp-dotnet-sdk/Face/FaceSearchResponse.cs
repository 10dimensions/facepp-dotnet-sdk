using System;
using Cody.FacePP.Core;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Face
{
    public class FaceSearchResponse : BaseResponse
    {
        [JsonProperty("results")]
        public FaceSearchResult Results { get; set; }

        /// <summary>
        /// 一组用于参考的置信度阈值，包含以下三个字段。每个字段的值为一个 [0,100] 的浮点数，小数点后 3 位有效数字
        /// 如果置信值低于“千分之一”阈值则不建议认为是同一个人；如果置信值超过“十万分之一”阈值，则是同一个人的几率非常高。
        /// 请注意：阈值不是静态的，每次返回的阈值不保证相同，所以没有持久化保存阈值的必要，更不要将当前调用返回的 confidence 与之前调用返回的阈值比较。
        /// 注：如果传入图片但图片中未检测到人脸，则无法进行人脸搜索，本字段不返回。
        /// </summary>
        [JsonProperty("thresholds")]
        public Thresholds Thresholds { get; set; }

        /// <summary>
        /// 传入的图片在系统中的标识
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        /// <summary>
        /// 传入的图片中检测出的人脸数组，采用数组中的第一个人脸进行人脸搜索
        /// </summary>
        [JsonProperty("faces")]
        public FaceCompareResult[] Faces { get; set; }
    }

    public class FaceSearchResult
    {
        /// <summary>
        /// 从 FaceSet 中搜索出的一个人脸标识 face_token。
        /// </summary>
        [JsonProperty("face_token")]
        public string FaceToken { get; set; }

        /// <summary>
        /// 比对结果置信度，范围 [0,100]，小数点后3位有效数字，数字越大表示两个人脸越可能是同一个人。
        /// </summary>
        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }

        /// <summary>
        /// 用户提供的人脸标识，如果未提供则为空。
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
