using System;
using System.Collections.Generic;
using System.Linq;
using Cody.FacePP.Core;
using Cody.FacePP.Api.Entity;

namespace Cody.FacePP.Api.Face
{
    public class FaceDetectRequest : BaseRequest<FaceDetectResponse>
    {
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

        private Dictionary<int, string> _attributes = typeof(AttributesType).ToDictionary();

        public override string QueryString
        {
            get
            {
                if (this.ImageFile != null && this.ImageFile.Exists)
                    return null;

                return string.Join("&", BuildQuery().Select(p => string.Format("{0}={1}", p.Key, p.Value)));
            }
        }

        private Dictionary<string, string> BuildQuery()
        {
            var dics = new Dictionary<string, string>();

            dics.Add("api_key", this.ApiKey);
            dics.Add("api_secret", this.ApiSecret);

            if (!string.IsNullOrWhiteSpace(this.ImageBase64String))
                dics.Add("image_base64", this.ImageBase64String);
            else if (!string.IsNullOrWhiteSpace(this.ImageUrl))
                dics.Add("image_url", WebQueryHelper.UrlEncode(this.ImageUrl));

            if (this.IsReturnLandMark)
                dics.Add("return_landmark", "1");

            if (this.ReturnAttributesType != AttributesType.None)
            {
                var _att = "";
                foreach (var d in _attributes)
                {
                    if (d.Key == (int)(this.ReturnAttributesType & (AttributesType)d.Key) && d.Key != (int)AttributesType.All && d.Key != (int)AttributesType.None)
                        _att += string.Format("{0},", d.Value);
                }
                _att = _att.TrimEnd(',');
                dics.Add("return_attributes", _att);
            }

            if (this.IsCalculateAll)
                dics.Add("calculate_all", "1");

            if (this.FaceRectangle != null)
                dics.Add("face_rectangle", string.Format("{0},{1},{2},{3}",
                    this.FaceRectangle.Top, this.FaceRectangle.Left,
                    this.FaceRectangle.Width, this.FaceRectangle.Height));

            return dics;
        }

        private string _boundary = FileHelper.GetBoundary();

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

        public override string ApiUrl
        {
            get
            {
                return string.Format("{0}/detect", this.ApiBaseUrl);

                //if (this.QueryBytes != null)
                //    url = string.Format("{0}?{1}", url, string.Join("&", BuildQuery().Select(p => string.Format("{0}={1}", p.Key, p.Value))));
                //return url;
            }
        }

        /// <summary>
        /// 是否检测并返回人脸关键点
        /// </summary>
        public bool IsReturnLandMark { get; set; } = false;

        /// <summary>
        /// 是否检测并返回根据人脸特征判断出的年龄、性别、情绪等属性
        /// </summary>
        public AttributesType ReturnAttributesType { get; set; } = AttributesType.None;

        /// <summary>
        /// 可选（仅正式 API Key 可以使用）
        /// </summary>
        public bool IsCalculateAll { get; set; } = false;

        /// <summary>
        /// 可选（仅正式 API Key 可以使用）
        /// </summary>
        public FaceRectangle FaceRectangle { get; set; } = null;

        public FaceDetectRequest()
            : base()
        {
            this.RequestMethod = HttpMethod.POST;
        }
    }
}
