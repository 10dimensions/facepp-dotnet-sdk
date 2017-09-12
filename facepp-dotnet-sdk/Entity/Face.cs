using System;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Entity
{
    public class Face
    {
        [JsonProperty("face_token")]
        public string FaceToken { get; set; }

        [JsonProperty("face_rectangle")]
        public FaceRectangle FaceRectangle { get; set; }

        [JsonProperty("landmark")]
        public LandMark LandMark { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class GenderValue
    {
        [JsonProperty("value")]
        public virtual string Value { get; set; }
    }

    public class AgeValue
    {
        [JsonProperty("value")]
        public virtual int Value { get; set; }
    }

    public class EthnicityValue
    {
        [JsonProperty("value")]
        public virtual string Value { get; set; }
    }

    /// <summary>
    /// 笑容分析结果
    /// </summary>
    public class Smiling : ValueThreshold
    {
        /// <summary>
        /// 值为一个 [0,100] 的浮点数，小数点后3位有效数字。数值越大表示笑程度高。
        /// </summary>
        [JsonProperty("value")]
        public override decimal Value { get; set; }

        /// <summary>
        /// 代表笑容的阈值，超过该阈值认为有笑容。
        /// </summary>
        [JsonProperty("threshold")]
        public override decimal Threshold { get; set; }
    }

    public class Blur
    {
        /// <summary>
        /// 人脸模糊分析结果
        /// </summary>
        [JsonProperty("blurness")]
        public ValueThreshold Blurness { get; set; }
    }

    public class FaceQuality : ValueThreshold
    {
        /// <summary>
        /// 表示人脸质量基本合格的一个阈值，超过该阈值的人脸适合用于人脸比对。
        /// </summary>
        public override decimal Threshold { get; set; }

        /// <summary>
        /// 值为人脸的质量判断的分数，是一个浮点数，范围 [0,100]，小数点后 3 位有效数字。
        /// </summary>
        public override decimal Value { get; set; }
    }

    public class ValueThreshold
    {
        /// <summary>
        /// 值为一个 [0,100] 的浮点数，小数点后3位有效数字。
        /// </summary>
        [JsonProperty("value")]
        public virtual decimal Value { get; set; }

        /// <summary>
        /// 阈值
        /// </summary>
        [JsonProperty("threshold")]
        public virtual decimal Threshold { get; set; }
    }
}
