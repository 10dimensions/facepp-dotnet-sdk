using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.HumanBody
{
    public class HumanBodySegmentResponse : BaseResponse
    {
        /// <summary>
        /// 一个通过Base64编码的字符串，解码后得到一个JPG格式的灰度图片。灰度图的像素点与原图像素点一一对应。灰度图中的每个像素点的灰度值等于原图对应像素点是否位于人体轮廓内的置信度乘以255。
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }

        /// <summary>
        /// 被检测的图片在系统中的标识
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        /// <summary>
        /// 灰度图中的每个像素点的灰度值等于原图对应像素点是否位于人体轮廓内的置信度乘以255
        /// </summary>
        public Bitmap GrayImage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Result))
                    return null;

                byte[] bytes = Convert.FromBase64String(this.Result);

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
                {
                    return new Bitmap(Image.FromStream(ms));
                }
            }
        }
    }
}
