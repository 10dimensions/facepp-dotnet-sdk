using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    /// <summary>
    /// 嘴部状态信息，包括以下字段。每个字段的值都是一个浮点数，范围 [0,100]，小数点后 3 位有效数字。字段值的总和等于 100。
    /// </summary>
    public class MouthStatus
    {
        /// <summary>
        /// 嘴部被医用口罩或呼吸面罩遮挡的置信度
        /// </summary>
        [JsonProperty("surgical_mask_or_respirator")]
        public decimal SurgicalMaskOrRespirator { get; set; }

        /// <summary>
        /// 嘴部被其他物体遮挡的置信度
        /// </summary>
        [JsonProperty("other_occlusion")]
        public decimal OtherOcclusion { get; set; }

        /// <summary>
        /// 嘴部没有遮挡且闭上的置信度
        /// </summary>
        [JsonProperty("close")]
        public decimal Close { get; set; }

        /// <summary>
        /// 嘴部没有遮挡且张开的置信度
        /// </summary>
        [JsonProperty("open")]
        public decimal Open { get; set; }
    }
}
