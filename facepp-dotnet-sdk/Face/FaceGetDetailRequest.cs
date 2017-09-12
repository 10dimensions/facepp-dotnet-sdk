using System;
using System.Linq;
using System.Collections.Generic;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Face
{
    public class FaceGetDetailRequest : BaseRequest<FaceGetDetailResponse>
    {
        /// <summary>
        /// 人脸标识face_token
        /// </summary>
        public string FaceToken { get; set; }

        public override string ApiUrl
        {
            get
            {
                return string.Format("{0}/facepp/v3/face/getdetail", this.ApiBaseUrl);
            }
        }

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

            return dics;
        }
    }
}
