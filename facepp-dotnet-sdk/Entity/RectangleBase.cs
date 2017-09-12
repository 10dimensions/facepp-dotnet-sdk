using System;
using System.Drawing;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    public abstract class RectangleBase
    {
        /// <summary>
        /// 矩形框左上角像素点的纵坐标
        /// </summary>
        [JsonProperty("top")]
        public int Top { get; set; }

        /// <summary>
        /// 矩形框左上角像素点的横坐标
        /// </summary>
        [JsonProperty("left")]
        public int Left { get; set; }

        /// <summary>
        /// 矩形框的宽度
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// 矩形框的高度
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        public override string ToString()
        {
            return string.Format("x:\t{0}\ty:\t{1}\twidth:\t{2}\theight:\t{3}", this.Left, this.Top, this.Width, this.Height);
        }

        /// <summary>
        /// 左 - 上 顶点坐标
        /// </summary>
        public Point TopLeft
        {
            get
            {
                return new Point(this.Left, this.Top);
            }
        }

        /// <summary>
        /// 右 - 上 顶点坐标
        /// </summary>
        public Point TopRight
        {
            get
            {
                return new Point(this.Left + this.Width, this.Top);
            }
        }

        /// <summary>
        /// 左 - 下 顶点坐标
        /// </summary>
        public Point BottomLeft
        {
            get
            {
                return new Point(this.Left, this.Top + this.Height);
            }
        }

        /// <summary>
        /// 右 - 下 顶点坐标
        /// </summary>
        public Point BottomRight
        {
            get
            {
                return new Point(this.Left + this.Width, this.Top + this.Height);
            }
        }
    }
}
