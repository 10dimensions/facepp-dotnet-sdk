using System;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    public class Gesture
    {
        /// <summary>
        /// 未定义手势
        /// </summary>
        [JsonProperty("unknown")]
        public float UnKnown { get; set; }

        /// <summary>
        /// 比心A
        /// 手背朝画面，心尖向下，拇指指尖接触
        /// </summary>
        [JsonProperty("heart_a")]
        public float HeartA { get; set; }

        /// <summary>
        /// 比心B
        /// 手指第二关节接触，心尖向下，拇指指尖接触
        /// </summary>
        [JsonProperty("heart_b")]
        public float HeartB { get; set; }

        /// <summary>
        /// 比心C
        /// 手腕接触，心尖向下，剩下四指左右两手接触
        /// </summary>
        [JsonProperty("heart_c")]
        public float HeartC { get; set; }

        /// <summary>
        /// 比心D
        /// 食指大拇指交叉，食指朝上，其余手指折叠
        /// </summary>
        [JsonProperty("heart_d")]
        public float HeartD { get; set; }

        /// <summary>
        /// OK
        /// 食指拇指尖接触，剩余手指摊开
        /// </summary>
        [JsonProperty("ok")]
        public float OK { get; set; }

        /// <summary>
        /// 手张开
        /// 五指打开，手心面向画面
        /// </summary>
        [JsonProperty("hand_open")]
        public float HandOpen { get; set; }

        /// <summary>
        /// 点赞 
        /// 竖大拇指，方向向上
        /// </summary>
        [JsonProperty("thumb_up")]
        public float ThumbUp { get; set; }

        /// <summary>
        /// 差评
        /// 竖大拇指，方向向下
        /// </summary>
        [JsonProperty("thumb_down")]
        public float ThumnDown { get; set; }

        /// <summary>
        /// ROCK
        /// 小拇指、食指、大拇指伸直，无名指、中指折起，手心对外
        /// </summary>
        [JsonProperty("rock")]
        public float Rock { get; set; }

        /// <summary>
        /// 合十
        /// 双手合十
        /// </summary>
        [JsonProperty("namaste")]
        public float Namaste { get; set; }

        /// <summary>
        /// 手心向上
        /// 摊开手，手心朝上
        /// </summary>
        [JsonProperty("palm_up")]
        public float PalmUp { get; set; }

        /// <summary>
        /// 握拳
        /// 握拳，手心对外
        /// </summary>
        [JsonProperty("fist")]
        public float Fist { get; set; }

        /// <summary>
        /// 食指朝上
        /// 伸出食指，其余手指折起，手心对外
        /// </summary>
        [JsonProperty("index_finger_up")]
        public float IndexFingerUp { get; set; }

        /// <summary>
        /// 双指朝上
        /// 伸出食指和中止，并拢，其余手指折起，手心对外
        /// </summary>
        [JsonProperty("double_finger_up")]
        public float DoubleFingerUp { get; set; }

        /// <summary>
        /// 胜利
        /// 伸出食指和中止，张开，其余手指折起，手心对外
        /// </summary>
        [JsonProperty("victory")]
        public float Victory { get; set; }

        /// <summary>
        /// 大V
        /// 伸出食指和大拇指，其余手指折起，手背朝外
        /// </summary>
        [JsonProperty("big_v")]
        public float BigV { get; set; }

        /// <summary>
        /// 打电话
        /// 伸出大拇指和小指，其余手指折叠，手背对外
        /// </summary>
        [JsonProperty("phonecall")]
        public float PhoneCall { get; set; }

        /// <summary>
        /// 作揖
        /// 一手握拳，另一手覆盖在其之上
        /// </summary>
        [JsonProperty("beg")]
        public float Beg { get; set; }

        /// <summary>
        /// 感谢
        /// 一手握拳，另一手张开，手心覆盖在其之上
        /// </summary>
        [JsonProperty("thanks")]
        public float Thanks { get; set; }
    }
}
