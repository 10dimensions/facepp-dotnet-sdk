using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    public class EyeStatus
    {
        /// <summary>
        /// 眼睛被遮挡的置信度
        /// </summary>
        [JsonProperty("occlusion")]
        public decimal Occlusion { get; set; }

        /// <summary>
        /// 眼睛被遮挡的置信度
        /// </summary>
        [JsonProperty("no_glass_eye_open")]
        public decimal NoGlassEyeOpen { get; set; }

        /// <summary>
        /// 佩戴普通眼镜且闭眼的置信度
        /// </summary>
        [JsonProperty("normal_glass_eye_close")]
        public decimal NormalGlassEyeClose { get; set; }

        /// <summary>
        /// 佩戴普通眼镜且睁眼的置信度
        /// </summary>
        [JsonProperty("normal_glass_eye_open")]
        public decimal NormalGlassEyeOpen { get; set; }

        /// <summary>
        /// 佩戴墨镜的置信度
        /// </summary>
        [JsonProperty("dark_glasses")]
        public decimal DarkGlasses { get; set; }

        /// <summary>
        /// 不戴眼镜且闭眼的置信度
        /// </summary>
        [JsonProperty("no_glass_eye_close")]
        public decimal NoGlassEyeClose { get; set; }
    }
}
