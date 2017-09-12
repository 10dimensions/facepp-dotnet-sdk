using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.FaceSet
{
    public class UpdateFaceSetRequest : BaseRequest<UpdateFaceSetResponse>
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
        /// 人脸集合的名字，最长256个字符，不能包括字符^@,&=*'"
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 账号下全局唯一的FaceSet自定义标识，可以用来管理FaceSet对象。最长255个字符，不能包括字符^@,&=*'"
        /// </summary>
        public string NewOuterId { get; set; }

        /// <summary>
        /// FaceSet自定义标签组成的字符串，用来对FaceSet分组。最长255个字符，多个tag用逗号分隔，每个tag不能包括字符^@,&=*'"
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// 自定义用户信息，不大于16KB，不能包括字符^@,&=*'"
        /// </summary>
        public string UserData { get; set; }

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

            if (!string.IsNullOrWhiteSpace(this.DisplayName))
                dics.Add("display_name", WebQueryHelper.UrlEncode(this.DisplayName));

            if (!string.IsNullOrWhiteSpace(this.NewOuterId))
                dics.Add("new_outer_id", WebQueryHelper.UrlEncode(this.NewOuterId));

            if (this.Tags != null)
            {
                dics.Add("tags", WebQueryHelper.UrlEncode(string.Join(",", this.Tags)));
            }

            if (!string.IsNullOrWhiteSpace(this.UserData))
                dics.Add("user_data", WebQueryHelper.UrlEncode(this.UserData));

            return dics;
        }

        public override string ApiUrl
        {
            get
            {
                return string.Format("{0}/facepp/v3/faceset/update", this.ApiBaseUrl);
            }
        }
    }
}
