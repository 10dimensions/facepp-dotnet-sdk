using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.HumanBody
{
    public class HumanBodySegmentRequest : BaseRequest<HumanBodySegmentResponse>
    {
        private string _boundary = FileHelper.GetBoundary();

        /// <summary>
        /// 图片的 URL
        /// <para>与<see cref="ImageFile"/>、<see cref="ImageBase64String"/> 选择一个</para>
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 一个图片，二进制文件，需要用post multipart/form-data的方式上传。
        /// <para>与<see cref="ImageUrl"/>、<see cref="ImageBase64String"/> 选择一个</para>
        /// </summary>
        public System.IO.FileInfo ImageFile { get; set; } = null;

        /// <summary>
        /// base64 编码的二进制图片数据
        /// <para>与<see cref="ImageUrl"/>、<see cref="ImageFile"/> 选择一个</para>
        /// </summary>
        public string ImageBase64String { get; set; }

        private Dictionary<string, string> BuildQuery()
        {
            var dics = new Dictionary<string, string>();

            dics.Add("api_key", this.ApiKey);
            dics.Add("api_secret", this.ApiSecret);

            if (!string.IsNullOrWhiteSpace(this.ImageBase64String))
                dics.Add("image_base64", this.ImageBase64String);
            else if (!string.IsNullOrWhiteSpace(this.ImageUrl))
                dics.Add("image_url", WebQueryHelper.UrlEncode(this.ImageUrl));

            return dics;
        }

        public override string ApiUrl
        {
            get
            {
                return string.Format("{0}/humanbodypp/beta/segment", this.ApiBaseUrl);
            }
        }

        public override byte[] QueryBytes
        {
            get
            {
                if (this.ImageFile == null || !this.ImageFile.Exists)
                    return null;

                return FileHelper.GetMultipartBytes(this.ImageFile, _boundary, BuildQuery(), "image_file");
            }
        }

        public override string ContentTypeHeader
        {
            get
            {
                if (this.QueryBytes != null)
                    return FileHelper.GetContentType(_boundary);
                return base.ContentTypeHeader;
            }
        }

        public override string QueryString
        {
            get
            {
                if (this.ImageFile != null && this.ImageFile.Exists)
                    return null;

                return string.Join("&", BuildQuery().Select(p => string.Format("{0}={1}", p.Key, p.Value)));
            }
        }
    }
}
