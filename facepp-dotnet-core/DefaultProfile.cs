using System;

namespace Cody.FacePP.Core
{
    /// <summary>
    /// The default profile
    /// </summary>
    public class DefaultProfile : IProfile
    {
        public string APIKey { get; set; }
        public string APISecret { get; set; }

        public DefaultProfile()
        {

        }

        public DefaultProfile(string apiKey, string apiSecret)
        {
            this.APIKey = apiKey;
            this.APISecret = apiSecret;
        }
    }
}