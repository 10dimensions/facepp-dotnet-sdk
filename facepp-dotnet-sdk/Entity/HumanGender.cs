using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Entity
{
    public class HumanGender
    {
        /// <summary>
        /// 置信度，是一个浮点数，范围[0,100]，小数点后3位有效数
        /// </summary>
        [JsonProperty("confidence")]
        public float Confidence { get; set; }

        /// <summary>
        /// 值为Male/Female。Male 代表男性，Female代表女性
        /// </summary>
        [JsonProperty("value")]
        public string GenderValue { get; set; }

        private static Dictionary<int, string> _genders = typeof(Gender).ToDictionary();

        public Gender Gender
        {
            get
            {
                foreach(var g in _genders)
                {
                    if (g.Value.Equals(this.GenderValue))
                        return (Gender)g.Key;
                }
                return Gender.UnKnown;
            }
        }
    }
}
