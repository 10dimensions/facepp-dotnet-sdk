using System;
using System.Collections.Generic;
using System.Linq;

namespace Cody.FacePP.Core
{
    public abstract class BaseRequest<T>
        where T : BaseResponse
    {
        private static Dictionary<int, string> _contentTypeDicts = EnumHelper.ToDictionary(typeof(ContentType));
        private Dictionary<string, string> _headers = new Dictionary<string, string>();

        /// <summary>
        /// domain
        /// </summary>
        public string ApiBaseUrl { get; set; }

        public string ApiKey { get; set; }

        public string ApiSecret { get; set; }

        /// <summary>
        /// User Agent. You can override this property to use your own UA
        /// </summary>
        public virtual string UserAgent { get; } = ".NET SDK For Face++ - Cody";

        public HttpMethod RequestMethod { get; set; } = HttpMethod.POST;

        /// <summary>
        /// api url address
        /// </summary>
        public abstract string ApiUrl { get; }

        public ContentType ContentType { get; set; } = ContentType.Default;

        public virtual string ContentTypeHeader
        {
            get
            {
                return _contentTypeDicts[(int)this.ContentType];
            }
        }

        public abstract string QueryString { get; }

        /// <summary>
        /// When you are using POST, this is the request body you want to parse.
        /// </summary>
        public virtual byte[] QueryBytes { get; }

        /// <summary>
        /// Custom headers
        /// </summary>
        public virtual Dictionary<string, string> Headers
        {
            get
            {
                return _headers;
            }
        }

        /// <summary>
        /// Set the custom header
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetHeader(string key, string value)
        {
            if (!_headers.ContainsKey(key))
                _headers.Add(key, value);
            else
                _headers[key] = value;
        }

        /// <summary>
        /// Remove the custom header
        /// </summary>
        /// <param name="key"></param>
        public void RemoveHeader(string key)
        {
            if (_headers.ContainsKey(key))
                _headers.Remove(key);
        }

        public BaseRequest()
        {
            this.SetHeader("Accept-Encoding", "gzip, deflate");
        }

        /// <summary>
        /// The extra paras you can pass to the request
        /// </summary>
        public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();
    }
}