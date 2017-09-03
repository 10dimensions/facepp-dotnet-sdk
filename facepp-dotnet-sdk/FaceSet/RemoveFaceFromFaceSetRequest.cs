using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.FaceSet
{
    public class RemoveFaceFromFaceSetRequest : BaseRequest<RemoveFaceFromFaceSetResponse>
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
        /// 需要移除的人脸标识字符串，可以是一个或者多个face_token组成，用逗号分隔。最多不能超过1,000个face_token
        /// </summary>
        public List<string> FaceTokens { get; set; }

        /// <summary>
        /// 是否移除所有的Face
        /// </summary>
        public bool IsRemoveAll { get; set; } = false;

        public override string ApiUrl => string.Format("{0}/faceset/removeface", this.ApiBaseUrl);

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

            if (this.IsRemoveAll)
            {
                dics.Add("face_tokens", "RemoveAllFaceTokens");
            }
            else if (this.FaceTokens != null)
            {
                if (this.FaceTokens.Count > 5)
                    throw new Exception("最多不超过5个face_token");
                dics.Add("face_tokens", string.Join(",", this.FaceTokens));
            }

            return dics;
        }
    }
}
