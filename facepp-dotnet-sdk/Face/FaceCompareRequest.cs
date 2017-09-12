using System;
using System.Collections.Generic;
using System.Linq;
using Cody.FacePP.Core;
using Cody.FacePP.Api.Entity;

namespace Cody.FacePP.Api.Face
{
    public class FaceCompareRequest : BaseRequest<FaceCompareResponse>
    {
        /// <summary>
        /// 第一个人脸标识 face_token，优先使用该参数
        /// <para>与<see cref="ImageUrl1"/>、<see cref="ImageFile1"/>、<see cref="ImageBase64String1"/> 选择一个</para>
        /// </summary>
        public string FaceToken1 { get; set; }

        /// <summary>
        /// 第一张图片的 URL
        /// <para>与<see cref="FaceToken1"/>、<see cref="ImageFile1"/>、<see cref="ImageBase64String1"/> 选择一个</para>
        /// </summary>
        public string ImageUrl1 { get; set; }

        /// <summary>
        /// 第一张图片，二进制文件，需要用 post multipart/form-data 的方式上传。
        /// <para>与<see cref="FaceToken1"/>、<see cref="ImageUrl1"/>、<see cref="ImageBase64String1"/> 选择一个</para>
        /// </summary>
        public System.IO.FileInfo ImageFile1 { get; set; } = null;

        /// <summary>
        /// base64 编码的二进制图片数据
        /// <para>与<see cref="FaceToken1"/>、<see cref="ImageUrl1"/>、<see cref="ImageFile1"/> 选择一个</para>
        /// </summary>
        public string ImageBase64String1 { get; set; }

        /// <summary>
        /// 第二个人脸标识 face_token，优先使用该参数
        /// <para>与<see cref="ImageUrl2"/>、<see cref="ImageFile2"/>、<see cref="ImageBase64String2"/> 选择一个</para>
        /// </summary>
        public string FaceToken2 { get; set; }

        /// <summary>
        /// 第二张图片的 URL
        /// <para>与<see cref="FaceToken2"/>、<see cref="ImageFile2"/>、<see cref="ImageBase64String2"/> 选择一个</para>
        /// </summary>
        public string ImageUrl2 { get; set; }

        /// <summary>
        /// 第二张图片，二进制文件，需要用 post multipart/form-data 的方式上传。
        /// <para>与<see cref="FaceToken2"/>、<see cref="ImageUrl2"/>、<see cref="ImageBase64String2"/> 选择一个</para>
        /// </summary>
        public System.IO.FileInfo ImageFile2 { get; set; } = null;

        /// <summary>
        /// base64 编码的二进制图片数据
        /// 如果同时传入了 image_url2、image_file2 和 image_base64_2 参数，本API 使用顺序为 image_file2优先，image_url2 最低。
        /// <para>与<see cref="FaceToken2"/>、<see cref="ImageUrl2"/>、<see cref="ImageFile2"/> 选择一个</para>
        /// </summary>
        public string ImageBase64String2 { get; set; }

        /// <summary>
        /// 可选（仅正式 API Key 可以使用）
        /// 只有在传入 image_url1、image_file1 和 image_base64_1 三个参数中任意一个时，本参数才生效
        /// </summary>
        public FaceRectangle FaceRectangle1 { get; set; }

        /// <summary>
        /// 可选（仅正式 API Key 可以使用）
        /// 只有在传入image_url2、image_file2 和image_base64_2 三个参数中任意一个后本参数才生效
        /// </summary>
        public FaceRectangle FaceRectangle2 { get; set; }

        public override string ApiUrl
        {
            get
            {
                return string.Format("{0}/facepp/v3/compare", this.ApiBaseUrl);
            }
        }

        public override string QueryString
        {
            get
            {
                if ((this.ImageFile1 != null && this.ImageFile1.Exists) || (this.ImageFile2 != null && this.ImageFile2.Exists))
                    return null;

                return string.Join("&", BuildQuery().Select(p => string.Format("{0}={1}", p.Key, p.Value)));
            }
        }

        public override byte[] QueryBytes
        {
            get
            {
                if ((this.ImageFile1 == null || !this.ImageFile1.Exists) && (this.ImageFile2 == null || !this.ImageFile2.Exists))
                    return null;

                if (this.ImageFile1 != null && this.ImageFile2 != null && this.ImageFile1.Exists && this.ImageFile2.Exists)
                    return FileHelper.GetMultipartBytes(this.ImageFile1, this.ImageFile2, _boundary, BuildQuery(), "image_file1", "image_file2");

                if (this.ImageFile1 != null && this.ImageFile1.Exists)
                    return FileHelper.GetMultipartBytes(this.ImageFile1, _boundary, BuildQuery(), "image_file1");
                else
                    return FileHelper.GetMultipartBytes(this.ImageFile2, _boundary, BuildQuery(), "image_file2");
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

        private string _boundary = FileHelper.GetBoundary();

        private Dictionary<string, string> BuildQuery()
        {
            var dics = new Dictionary<string, string>();

            dics.Add("api_key", this.ApiKey);
            dics.Add("api_secret", this.ApiSecret);

            if (!string.IsNullOrWhiteSpace(this.FaceToken1))
                dics.Add("face_token1", this.FaceToken1);
            if (!string.IsNullOrWhiteSpace(this.ImageUrl1))
                dics.Add("image_url1", WebQueryHelper.UrlEncode(this.ImageUrl1));
            if(!string.IsNullOrWhiteSpace(this.ImageBase64String1))
                dics.Add("image_base64_1", this.ImageBase64String1);

            if (!string.IsNullOrWhiteSpace(this.FaceToken2))
                dics.Add("face_token2", this.FaceToken2);
            if (!string.IsNullOrWhiteSpace(this.ImageUrl2))
                dics.Add("image_url2", WebQueryHelper.UrlEncode(this.ImageUrl2));
            if (!string.IsNullOrWhiteSpace(this.ImageBase64String2))
                dics.Add("image_base64_2", this.ImageBase64String2);

            if (this.FaceRectangle1 != null)
                dics.Add("face_rectangle1", string.Format("{0},{1},{2},{3}",
                    this.FaceRectangle1.Top, this.FaceRectangle1.Left,
                    this.FaceRectangle1.Width, this.FaceRectangle1.Height));

            if (this.FaceRectangle2 != null)
                dics.Add("face_rectangle2", string.Format("{0},{1},{2},{3}",
                    this.FaceRectangle2.Top, this.FaceRectangle2.Left,
                    this.FaceRectangle2.Width, this.FaceRectangle2.Height));

            return dics;
        }

        public FaceCompareRequest()
            : base()
        {
            this.RequestMethod = HttpMethod.POST;
        }
    }
}
