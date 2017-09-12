using System;
using System.Collections.Generic;
using System.Linq;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Face
{
    public class FaceAnalyzeRequest : BaseRequest<FaceAnalyzeResponse>
    {
        /// <summary>
        /// 一个字符串，由一个或多个人脸标识组成，用逗号分隔。最多支持 5 个 face_token。
        /// </summary>
        public List<string> FaceTokens { get; set; }

        /// <summary>
        /// 是否检测并返回人脸关键点
        /// 此项 与 <see cref="ReturnAttributesType"/> 至少选择一项
        /// </summary>
        public bool IsReturnLandMark { get; set; } = false;

        /// <summary>
        /// 是否检测并返回根据人脸特征判断出的年龄、性别、情绪等属性
        /// 此项 与 <see cref="IsReturnLandMark"/> 至少选择一项
        /// </summary>
        public AttributesType ReturnAttributesType { get; set; } = AttributesType.None;

        /// <summary>
        /// 文档：https://console.faceplusplus.com.cn/documents/4888383
        /// </summary>
        public override string ApiUrl
        {
            get
            {
                return string.Format("{0}/facepp/v3/face/analyze", this.ApiBaseUrl);
            }
        }

        public override string QueryString
        {
            get
            {
                return string.Join("&", BuildQuery().Select(p => string.Format("{0}={1}", p.Key, p.Value)));
            }
        }

        private static Dictionary<int, string> _attributes = typeof(AttributesType).ToDictionary();

        private Dictionary<string, string> BuildQuery()
        {
            var dics = new Dictionary<string, string>();

            dics.Add("api_key", this.ApiKey);
            dics.Add("api_secret", this.ApiSecret);

            if (this.FaceTokens != null && this.FaceTokens.Count > 0)
                dics.Add("face_tokens", string.Join(",", this.FaceTokens));

            if (this.IsReturnLandMark)
                dics.Add("return_landmark", "1");

            if (this.ReturnAttributesType != AttributesType.None)
            {
                var _att = "";
                foreach (var d in _attributes)
                {
                    if (d.Key == (int)(this.ReturnAttributesType & (AttributesType)d.Key) && d.Key != (int)AttributesType.All && d.Key != (int)AttributesType.None)
                        _att += string.Format("{0},", d.Value);
                }
                _att = _att.TrimEnd(',');
                dics.Add("return_attributes", _att);
            }

            return dics;
        }
    }
}
