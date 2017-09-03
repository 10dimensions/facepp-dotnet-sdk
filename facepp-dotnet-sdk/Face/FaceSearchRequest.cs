using System;
using System.Collections.Generic;
using System.Linq;
using Cody.FacePP.Core;
using Cody.FacePP.Api.Entity;

namespace Cody.FacePP.Api.Face
{
    public class FaceSearchRequest : BaseRequest<FaceSearchResponse>
    {
        /// <summary>
        /// 进行搜索的目标人脸的 face_token，优先使用该参数
        /// <para>与<see cref="ImageUrl"/>、<see cref="ImageFile"/>、<see cref="ImageBase64String"/> 选择一个</para>
        /// </summary>
        public string FaceToken { get; set; }

        /// <summary>
        /// 目标人脸所在的图片的 URL
        /// <para>与<see cref="FaceToken"/>、<see cref="ImageFile"/>、<see cref="ImageBase64String"/> 选择一个</para>
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 目标人脸所在的图片，二进制文件，需要用 post multipart/form-data 的方式上传。
        /// <para>与<see cref="FaceToken"/>、<see cref="ImageUrl"/>、<see cref="ImageBase64String"/> 选择一个</para>
        /// </summary>
        public System.IO.FileInfo ImageFile { get; set; } = null;

        /// <summary>
        /// base64 编码的二进制图片数据
        /// 如果同时传入了 image_url、image_file 和 image_base64 参数，本 API 使用顺序为 image_file 优先，image_url 最低。
        /// <para>与<see cref="FaceToken"/>、<see cref="ImageUrl"/>、<see cref="ImageFile"/> 选择一个</para>
        /// </summary>
        public string ImageBase64String { get; set; }

        /// <summary>
        /// 用来搜索的 FaceSet 的标识，和 <see cref="OuterId"/> 二选一
        /// </summary>
        public string FaceSetToken { get; set; }

        /// <summary>
        /// 用户自定义的 FaceSet 标识，和 <see cref="FaceSetToken"/> 二选一
        /// </summary>
        public string OuterId { get; set; }

        /// <summary>
        /// 控制返回比对置信度最高的结果的数量。合法值为一个范围 [1,5] 的整数。默认值为 1
        /// </summary>
        public int ReturnResultCount { get; set; } = 1;

        /// <summary>
        /// 可选（仅正式 API Key 可以使用）
        /// </summary>
        public FaceRectangle FaceRectangle { get; set; }

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

            if (!string.IsNullOrWhiteSpace(this.FaceToken))
                dics.Add("face_token", this.FaceToken);
            if (!string.IsNullOrWhiteSpace(this.ImageBase64String))
                dics.Add("image_base64", this.ImageBase64String);
            else if (!string.IsNullOrWhiteSpace(this.ImageUrl))
                dics.Add("image_url", WebQueryHelper.UrlEncode(this.ImageUrl));

            if (!string.IsNullOrWhiteSpace(this.FaceSetToken))
                dics.Add("faceset_token", this.FaceSetToken);
            else if (!string.IsNullOrWhiteSpace(this.OuterId))
                dics.Add("outer_id", this.OuterId);

            dics.Add("return_result_count", this.ReturnResultCount.ToString());

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
                return string.Format("{0}/search", this.ApiBaseUrl);
            }
        }

        public FaceSearchRequest()
            : base()
        {
            this.RequestMethod = HttpMethod.POST;
        }

    }
}
