using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.FaceSet
{
    public class DeleteFaceSetRequest : BaseRequest<DeleteFaceSetResponse>
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
        /// 可选
        /// 删除时是否检查FaceSet中是否存在face_token,默认为true。如果设置为true，当FaceSet中存在face_token则不能删除
        /// </summary>
        public bool IsCheckEmpty { get; set; } = true;

        public override string ApiUrl => string.Format("{0}/faceset/delete", this.ApiBaseUrl);

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

            if (this.IsCheckEmpty)
                dics.Add("check_empty", "1");
            else
                dics.Add("check_empty", "0");

            return dics;
        }
    }
}
