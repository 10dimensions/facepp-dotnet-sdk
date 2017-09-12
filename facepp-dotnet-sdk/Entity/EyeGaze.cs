using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    /// <summary>
    /// 眼球位置与视线方向信息
    /// </summary>
    public class EyeGaze
    {
        /// <summary>
        /// 左眼的位置与视线状态
        /// </summary>
        [JsonProperty("left_eye_gaze")]
        public EyeGazeItem LeftEyeGaze { get; set; }

        /// <summary>
        /// 右眼的位置与视线状态
        /// </summary>
        [JsonProperty("right_eye_gaze")]
        public EyeGazeItem RightEyeGaze { get; set; }
    }
}
