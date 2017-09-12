using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    /// <summary>
    /// 颜值识别结果。返回值包含以下两个字段。每个字段的值是一个浮点数，范围 [0,100]，小数点后 3 位有效数字。
    /// </summary>
    public class Beauty
    {
        [JsonProperty("male_score")]
        public decimal MaleScore { get; set; }

        [JsonProperty("female_score")]
        public decimal FemaleScore { get; set; }
    }
}
