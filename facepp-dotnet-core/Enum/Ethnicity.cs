using System;

namespace Cody.FacePP.Core
{
    public enum Ethnicity : int
    {
        /// <summary>
        /// 亚洲人
        /// </summary>
        [EnumDescription("Asian")]
        Asian,

        /// <summary>
        /// 白人
        /// </summary>
        [EnumDescription("White")]
        White,

        /// <summary>
        /// 黑人
        /// </summary>
        [EnumDescription("Black")]
        Black,

        [EnumDescription("UnKnown")]
        UnKnown
    }
}
