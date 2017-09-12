using System;
using System.Linq;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Entity
{
    public class Attributes
    {
        private static System.Collections.Generic.Dictionary<int, string> _genders = typeof(Gender).ToDictionary();

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender
        {
            get
            {
                if (this.GenderValue != null)
                    return (Gender)_genders.FirstOrDefault(p => p.Value.Equals(this.GenderValue.Value)).Key;
                return Gender.UnKnown;
            }
        }

        [JsonProperty("gender")]
        public GenderValue GenderValue { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age
        {
            get
            {
                if (this.AgeValue != null)
                    return this.AgeValue.Value;
                return 0;
            }
        }

        [JsonProperty("age")]
        public AgeValue AgeValue { get; set; }

        /// <summary>
        /// 笑容分析结果
        /// </summary>
        [JsonProperty("smiling")]
        public Smiling Smiling { get; set; }

        /// <summary>
        /// 人脸姿势分析结果
        /// </summary>
        [JsonProperty("headpose")]
        public HeadPose Headpose { get; set; }

        /// <summary>
        /// 人脸模糊分析结果
        /// </summary>
        [JsonProperty("blur")]
        public Blur Blur { get; set; }

        /// <summary>
        /// 眼睛状态信息
        /// </summary>
        [JsonProperty("eyestatus")]
        public EyeStatusResult EyeStatus { get; set; }

        /// <summary>
        /// 情绪识别结果
        /// </summary>
        [JsonProperty("emotion")]
        public Emotion Emotion { get; set; }

        /// <summary>
        /// 人脸质量判断结果
        /// </summary>
        [JsonProperty("facequality")]
        public FaceQuality FaceQuality { get; set; }

        /// <summary>
        /// 人种分析结果
        /// </summary>
        [JsonProperty("ethnicity")]
        public EthnicityValue EthnicityValue { get; set; }

        private static System.Collections.Generic.Dictionary<int, string> _ethnicity = typeof(Ethnicity).ToDictionary();

        /// <summary>
        /// 人种
        /// </summary>
        public Ethnicity EthnicityType
        {
            get
            {
                if (this.EthnicityValue == null || string.IsNullOrEmpty(this.EthnicityValue.Value))
                    return Core.Ethnicity.UnKnown;

                return (Ethnicity)_ethnicity.FirstOrDefault(p => p.Value.Equals(this.EthnicityValue.Value)).Key;
            }
        }

        [JsonProperty("beauty")]
        public Beauty Beauty { get; set; }

        /// <summary>
        /// 嘴部状态信息
        /// </summary>
        [JsonProperty("mouthstatus")]
        public MouthStatus MouthStatus { get; set; }

        /// <summary>
        /// 眼球位置与视线方向信息
        /// </summary>
        [JsonProperty("eyegaze")]
        public EyeGaze EyeGaze { get; set; }
    }
}
