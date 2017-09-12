using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    /// <summary>
    /// 眼球位置与视线方向信息
    /// </summary>
    public class EyeGazeItem
    {
        /// <summary>
        /// 眼球中心位置的 X 轴坐标
        /// </summary>
        [JsonProperty("position_x_coordinate")]
        public decimal Position_X_Coordinate { get; set; }

        /// <summary>
        /// 眼球中心位置的 Y 轴坐标
        /// </summary>
        [JsonProperty("position_y_coordinate")]
        public decimal Position_Y_Coordinate { get; set; }

        /// <summary>
        /// 眼球视线方向向量的 X 轴分量
        /// </summary>
        [JsonProperty("vector_x_component")]
        public decimal Vector_X_Component { get; set; }

        /// <summary>
        /// 眼球视线方向向量的 Y 轴分量
        /// </summary>
        [JsonProperty("vector_y_component")]
        public decimal Vector_Y_Component { get; set; }

        /// <summary>
        /// 眼球视线方向向量的 Z 轴分量
        /// </summary>
        [JsonProperty("vector_z_component")]
        public decimal Vector_Z_Component { get; set; }
    }
}
