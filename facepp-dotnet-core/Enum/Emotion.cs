using System;

namespace Cody.FacePP.Core
{
    public enum Emotion : int
    {
        /// <summary>
        /// 愤怒
        /// </summary>
        [EnumDescription("anger")]
        Anger,

        /// <summary>
        /// 厌恶
        /// </summary>
        [EnumDescription("disgust")]
        Disgust,

        /// <summary>
        /// 恐惧
        /// </summary>
        [EnumDescription("fear")]
        Fear,

        /// <summary>
        /// 高兴
        /// </summary>
        [EnumDescription("happiness")]
        Happiness,

        /// <summary>
        /// 平静
        /// </summary>
        [EnumDescription("neutral")]
        Neutral,

        /// <summary>
        /// 伤心
        /// </summary>
        [EnumDescription("sadness")]
        Sadness,

        /// <summary>
        /// 惊讶
        /// </summary>
        [EnumDescription("surprise")]
        Surprise
    }
}
