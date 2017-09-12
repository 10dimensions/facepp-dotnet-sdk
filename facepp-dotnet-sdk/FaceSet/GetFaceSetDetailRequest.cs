using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.FaceSet
{
    public class GetFaceSetDetailRequest : BaseRequest<GetFaceSetDetailResponse>
    {
        /// <summary>
        /// FaceSet 的标识
        /// <para>与<see cref="OuterId"/>选择一个</para>
        /// </summary>
        public string FaceSetToken { get; set; }

        /// <summary>
        /// 用户提供的 FaceSet 标识
        /// <para>与<see cref="FaceSetToken"/>选择一个</para>
        /// </summary>
        public string OuterId { get; set; }

        /// <summary>
        /// 一个数字 n，表示开始返回的 face_token 在本 FaceSet 中的序号， n 是 [1,10000] 间的一个整数。
        /// 通过传入数字 n，可以控制本 API 从第 n 个 face_token 开始返回。返回的 face_token 按照创建时间排序，每次返回 100 个 face_token。
        /// </summary>
        public int Start { get; set; } = 0;

        /// <summary>
        /// 您可以输入上一次请求本 API 返回的 next 值，用以获得接下来的 100 个 face_token。
        /// </summary>
        public string StartToken { get; set; }

        public override string ApiUrl => string.Format("{0}/facepp/v3/faceset/getdetail", this.ApiBaseUrl);

        public override string QueryString
        {
            get
            {
                return string.Join("&", BuildQuery().Select(p => string.Format("{0}={1}", p.Key, p.Value)));
            }
        }

        private Dictionary<string, string> BuildQuery()
        {
            var dics = new Dictionary<string, string>();

            dics.Add("api_key", this.ApiKey);
            dics.Add("api_secret", this.ApiSecret);

            if (!string.IsNullOrWhiteSpace(this.FaceSetToken))
                dics.Add("faceset_token", this.FaceSetToken);
            else if (!string.IsNullOrWhiteSpace(this.OuterId))
                dics.Add("outer_id", WebQueryHelper.UrlEncode(this.OuterId));

            if (this.Start >= 1 && this.Start < 10000)
                dics.Add("start", this.Start.ToString());
            else if (!string.IsNullOrWhiteSpace(this.StartToken))
                dics.Add("start", this.StartToken);

            return dics;
        }
    }
}
