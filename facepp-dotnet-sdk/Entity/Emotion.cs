using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    /// <summary>
    /// 情绪识别结果。返回值包含以下字段。每个字段的值都是一个浮点数，范围 [0,100]，小数点后 3 位有效数字。字段值的总和等于 100。
    /// </summary>
    public class Emotion
    {
        [JsonProperty("anger")]
        public decimal Anger { get; set; }

        [JsonProperty("disgust")]
        public decimal Disgust { get; set; }

        [JsonProperty("fear")]
        public decimal Fear { get; set; }

        [JsonProperty("happiness")]
        public decimal Happiness { get; set; }

        [JsonProperty("neutral")]
        public decimal Neutral { get; set; }

        [JsonProperty("sadness")]
        public decimal Sadness { get; set; }

        [JsonProperty("surprise")]
        public decimal Surprise { get; set; }
    }
}
