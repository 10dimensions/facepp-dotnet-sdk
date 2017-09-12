using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.FaceSet
{
    public class GetAllFaceSetsRequest : BaseRequest<GetAllFaceSetsResponse>
    {
        /// <summary>
        /// 可选
        /// 包含需要查询的FaceSet标签的字符串，用逗号分隔
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// 可选
        /// 一个数字 n，表示开始返回的 faceset_token 在传入的 API Key 下的序号。
        /// 通过传入数字 n，可以控制本 API 从第 n 个 faceset_token 开始返回。返回的 faceset_token 按照创建时间排序。每次返回1000个FaceSets。
        /// </summary>
        public int Start { get; set; } = 0;

        /// <summary>
        /// 可选
        /// 输入上一次请求本 API 返回的 next 值，用以获得接下来的 100 个 faceset_token。
        /// </summary>
        public string StartToken { get; set; }

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

            if (this.Tags != null)
            {
                dics.Add("tags", WebQueryHelper.UrlEncode(string.Join(",", this.Tags)));
            }

            if (this.Start >= 1 && this.Start < 10000)
                dics.Add("start", this.Start.ToString());
            else if (!string.IsNullOrWhiteSpace(this.StartToken))
                dics.Add("start", this.StartToken);

            return dics;
        }

        public override string ApiUrl
        {
            get
            {
                return string.Format("{0}/facepp/v3/faceset/getfacesets", this.ApiBaseUrl);
            }
        }
    }
}
