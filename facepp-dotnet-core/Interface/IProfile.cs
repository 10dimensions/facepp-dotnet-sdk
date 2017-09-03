using System;

namespace Cody.FacePP.Core
{
    /// <summary>
    /// This is your account profile.
    /// https://console.faceplusplus.com.cn/app/apikey/list
    /// </summary>
    public interface IProfile
    {
        /// <summary>
        /// your access_key_id
        /// </summary>
        string APIKey { get; set; }

        /// <summary>
        /// your secret_key
        /// </summary>
        string APISecret { get; set; }
    }
}