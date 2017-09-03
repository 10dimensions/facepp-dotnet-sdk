using System;
using System.Net;
using Newtonsoft.Json;

namespace Cody.FacePP.Core
{
    public abstract class BaseResponse
    {
        public virtual ResponseType ResponseType { get; } = ResponseType.Json;

        public virtual string ResponseBase64String { get; set; }

        public virtual string ResponseString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.ResponseBase64String))
                    return null;
                return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(this.ResponseBase64String));
            }
        }

        [JsonIgnore]
        public virtual WebHeaderCollection Headers { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 用于区分每一次请求的唯一的字符串。
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// 整个请求所花费的时间，单位为毫秒。
        /// </summary>
        [JsonProperty("time_used")]
        public int TimeUsed { get; set; }

        /// <summary>
        /// 当请求失败时才会返回此字符串，具体返回内容见后续错误信息章节。否则此字段不存在。
        /// </summary>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}