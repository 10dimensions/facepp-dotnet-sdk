using System;
using System.Collections.Generic;
using System.Linq;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Face
{
    public class FaceSetUserIdRequest : BaseRequest<FaceSetUserIdResponse>
    {
        /// <summary>
        /// 人脸标识face_token
        /// </summary>
        public string FaceToken { get; set; }

        /// <summary>
        /// 用户自定义的user_id，不超过255个字符，不能包括^@,&=*'" 建议将同一个人的多个face_token设置同样的user_id。
        /// </summary>
        public string UserId { get; set; }

        public override string ApiUrl => string.Format("{0}/facepp/v3/face/setuserid", this.ApiBaseUrl);

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
            dics.Add("face_token", this.FaceToken);
            dics.Add("user_id", this.UserId);

            return dics;
        }
    }
}
