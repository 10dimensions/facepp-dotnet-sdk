using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    /// <summary>
    /// 眼睛状态信息
    /// </summary>
    public class EyeStatusResult
    {
        [JsonProperty("left_eye_status")]
        public EyeStatus LeftEyeStatus { get; set; }

        [JsonProperty("right_eye_status")]
        public EyeStatus RightEyeStatus { get; set; }
    }
}
