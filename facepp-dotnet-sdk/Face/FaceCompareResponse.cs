using System;
using Cody.FacePP.Core;
using Cody.FacePP.Api.Entity;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Face
{
    public class FaceCompareResponse : BaseResponse
    {
        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }

        [JsonProperty("thresholds")]
        public Thresholds Thresholds { get; set; }

        /// <summary>
        /// 通过 image_url1、image_file1 或 image_base64_1 传入的图片在系统中的标识
        /// </summary>
        [JsonProperty("image_id1")]
        public string ImageId1 { get; set; }

        /// <summary>
        /// 通过 image_url2、image_file2 或 image_base64_2 传入的图片在系统中的标识
        /// </summary>
        [JsonProperty("image_id2")]
        public string ImageId2 { get; set; }

        /// <summary>
        /// 通过 image_url1、image_file1 或 image_base64_1 传入的图片中检测出的人脸数组，采用数组中的第一个人脸进行人脸比对。
        /// </summary>
        [JsonProperty("faces1")]
        public FaceCompareResult[] Faces1 { get; set; }

        /// <summary>
        /// 通过 image_url2、image_file2 或 image_base64_2 传入的图片中检测出的人脸数组，采用数组中的第一个人脸进行人脸比对。
        /// </summary>
        [JsonProperty("faces2")]
        public FaceCompareResult[] Faces2 { get; set; }
    }

    /// <summary>
    /// 一组用于参考的置信度阈值，包含以下三个字段。每个字段的值为一个 [0,100] 的浮点数，小数点后 3 位有效数字。
    /// 如果置信值低于“千分之一”阈值则不建议认为是同一个人；如果置信值超过“十万分之一”阈值，则是同一个人的几率非常高。
    /// 请注意：阈值不是静态的，每次比对返回的阈值不保证相同，所以没有持久化保存阈值的必要，更不要将当前调用返回的 confidence 与之前调用返回的阈值比较。
    /// 注：如果传入图片但图片中未检测到人脸，则无法进行比对，本字段不返回。
    /// </summary>
    public class Thresholds
    {
        /// <summary>
        /// 误识率为千分之一的置信度阈值
        /// </summary>
        [JsonProperty("1e-3")]
        public decimal OneE3 { get; set; }

        /// <summary>
        /// 误识率为万分之一的置信度阈值
        /// </summary>
        [JsonProperty("1e-4")]
        public decimal OneE4 { get; set; }

        /// <summary>
        /// 误识率为十万分之一的置信度阈值
        /// </summary>
        [JsonProperty("1e-5")]
        public decimal OneE5 { get; set; }
    }

    public class FaceCompareResult
    {
        [JsonProperty("face_token")]
        public string FaceToken { get; set; }

        [JsonProperty("face_rectangle")]
        public FaceRectangle FaceRectangle { get; set; }
    }
}
