using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    /// <summary>
    /// 人脸姿势分析结果。返回值包含以下属性，每个属性的值为一个 [-180, 180] 的浮点数，小数点后 6 位有效数字。单位为角度。
    /// </summary>
    public class HeadPose
    {
        /// <summary>
        /// 抬头
        /// </summary>
        [JsonProperty("pitch_angle")]
        public decimal PitchAngle { get; set; }

        /// <summary>
        /// 旋转（平面旋转）
        /// </summary>
        [JsonProperty("roll_angle")]
        public decimal RollAngle { get; set; }

        /// <summary>
        /// 摇头
        /// </summary>
        [JsonProperty("yaw_angle")]
        public decimal YawAngle { get; set; }
    }
}
