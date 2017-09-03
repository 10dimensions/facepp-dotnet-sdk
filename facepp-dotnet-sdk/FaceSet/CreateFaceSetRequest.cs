using System;
using System.Collections.Generic;
using System.Linq;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.FaceSet
{
    public class CreateFaceSetRequest : BaseRequest<CreateFaceSetResponse>
    {
        /// <summary>
        /// 可选
        /// 人脸集合的名字，最长256个字符，不能包括字符^@,&=*'"
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 可选
        /// 账号下全局唯一的FaceSet自定义标识，可以用来管理FaceSet对象。最长255个字符，不能包括字符^@,&=*'"
        /// </summary>
        public string OuterId { get; set; }

        /// <summary>
        /// 可选
        /// FaceSet自定义标签组成的字符串，用来对FaceSet分组。最长255个字符，多个tag用逗号分隔，每个tag不能包括字符^@,&=*'"
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// 可选
        /// 人脸标识face_token，可以是一个或者多个，用逗号分隔。最多不超过5个face_token
        /// </summary>
        public List<string> FaceTokens { get; set; }

        /// <summary>
        /// 可选
        /// 自定义用户信息，不大于16KB，不能包括字符^@,&=*'"
        /// </summary>
        public string UserData { get; set; }

        /// <summary>
        /// 可选
        /// 在传入outer_id的情况下，如果outer_id已经存在，是否将face_token加入已经存在的FaceSet中
        /// </summary>
        public bool IsForceMerge { get; set; } = false;

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

            if (!string.IsNullOrWhiteSpace(this.DisplayName))
                dics.Add("display_name", WebQueryHelper.UrlEncode(this.DisplayName));

            if (!string.IsNullOrWhiteSpace(this.OuterId))
                dics.Add("outer_id", WebQueryHelper.UrlEncode(this.OuterId));

            if (this.Tags != null)
            {
                dics.Add("tags", WebQueryHelper.UrlEncode(string.Join(",", this.Tags)));
            }

            if (this.FaceTokens != null)
            {
                if (this.FaceTokens.Count > 0)
                    throw new Exception("最多不超过5个face_token");
                dics.Add("face_tokens", string.Join(",", this.FaceTokens));
            }

            if (!string.IsNullOrWhiteSpace(this.UserData))
                dics.Add("user_data", WebQueryHelper.UrlEncode(this.UserData));

            if (this.IsForceMerge)
                dics.Add("force_merge", "1");

            return dics;
        }

        public override string ApiUrl
        {
            get
            {
                return string.Format("{0}/faceset/create", this.ApiBaseUrl);
            }
        }
    }
}
