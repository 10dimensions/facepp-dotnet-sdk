using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Cody.FacePP.Core
{
    /// <summary>
    /// This provide the basic implementation of IWebClient. 
    /// It could automatically handle the url signature and parse the response.
    /// </summary>
    public class DefaultApiClient : IWebClient
    {
        private IProfile _profile = null;

        public string ApiBaseUrl { get; set; } = "https://api-cn.faceplusplus.com";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile">Your account profile</param>
        public DefaultApiClient(IProfile profile)
        {
            this._profile = profile;
        }

        public DefaultApiClient()
        {

        }

        /// <summary>
        /// Get or Set your profile
        /// </summary>
        public IProfile Profile
        {
            get
            {
                return this._profile;
            }
            set
            {
                this._profile = value;
            }
        }

        /// <summary>
        /// The Encoding used to parse the response content.
        /// Default is UTF8
        /// </summary>
        public Encoding ParseEncoding { get; set; } = Encoding.UTF8;

        /// <summary>
        /// Set the api base url & signature
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        protected virtual void SetHostAndSignature<T>(BaseRequest<T> request)
            where T : BaseResponse
        {
            if (request != null)
            {
                request.ApiBaseUrl = this.ApiBaseUrl;
                request.ApiKey = this.Profile.APIKey;
                request.ApiSecret = this.Profile.APISecret;
            }
        }

        /// <summary>
        /// Parse the response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        private T Parse<T>(BaseRequest<T> request, HttpResponse httpResponse)
            where T : BaseResponse
        {
            var responseString = ParseEncoding.GetString(httpResponse.ResponseBytes);

            if (string.IsNullOrWhiteSpace(responseString))
            {
                var obj = System.Activator.CreateInstance<T>();
                obj.Headers = httpResponse.Headers;
                obj.StatusCode = httpResponse.StatusCode;
                return obj;
            }

            var t = System.Activator.CreateInstance<T>();
            t.ResponseBase64String = Convert.ToBase64String(httpResponse.ResponseBytes);
            t.Headers = httpResponse.Headers;
            t.StatusCode = httpResponse.StatusCode;

            if (t.ResponseType == ResponseType.Json)
            {
                var _t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                _t.ResponseBase64String = t.ResponseBase64String;
                _t.Headers = httpResponse.Headers;
                _t.StatusCode = httpResponse.StatusCode;

                return _t;
            }

            return t;
        }

        /// <summary>
        /// Get the response synchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual T GetResponse<T>(BaseRequest<T> request)
            where T : BaseResponse
        {
            SetHostAndSignature(request);

            var response = RequestHelper.GetResponse(request);
            return this.Parse(request, response);
        }

        /// <summary>
        /// Get the response asynchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual async Task<T> GetResponseAsync<T>(BaseRequest<T> request)
            where T : BaseResponse
        {
            SetHostAndSignature(request);

            var response = await RequestHelper.GetResponseAsync(request);
            return this.Parse(request, response);
        }
    }
}