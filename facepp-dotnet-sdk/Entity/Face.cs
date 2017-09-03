using System;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;
using Cody.FacePP.Core;

namespace Cody.FacePP.Api.Entity
{
    public class Face
    {
        [JsonProperty("face_token")]
        public string FaceToken { get; set; }

        [JsonProperty("face_rectangle")]
        public FaceRectangle FaceRectangle { get; set; }

        [JsonProperty("landmark")]
        public LandMark LandMark { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    /// <summary>
    /// https://console.faceplusplus.com.cn/documents/5671270
    /// </summary>
    public class LandMark
    {
        public Coord contour_chin { get; set; }

        public Coord contour_left1 { get; set; }

        public Coord contour_left2 { get; set; }

        public Coord contour_left3 { get; set; }

        public Coord contour_left4 { get; set; }

        public Coord contour_left5 { get; set; }

        public Coord contour_left6 { get; set; }

        public Coord contour_left7 { get; set; }

        public Coord contour_left8 { get; set; }

        public Coord contour_left9 { get; set; }

        public Coord contour_right1 { get; set; }

        public Coord contour_right2 { get; set; }

        public Coord contour_right3 { get; set; }

        public Coord contour_right4 { get; set; }

        public Coord contour_right5 { get; set; }

        public Coord contour_right6 { get; set; }

        public Coord contour_right7 { get; set; }

        public Coord contour_right8 { get; set; }

        public Coord contour_right9 { get; set; }

        public Coord left_eye_bottom { get; set; }

        public Coord left_eye_center { get; set; }

        public Coord left_eye_left_corner { get; set; }

        public Coord left_eye_lower_left_quarter { get; set; }

        public Coord left_eye_lower_right_quarter { get; set; }

        public Coord left_eye_pupil { get; set; }

        public Coord left_eye_right_corner { get; set; }

        public Coord left_eye_top { get; set; }

        public Coord left_eye_upper_left_quarter { get; set; }

        public Coord left_eye_upper_right_quarter { get; set; }

        public Coord left_eyebrow_left_corner { get; set; }

        public Coord left_eyebrow_lower_left_quarter { get; set; }

        public Coord left_eyebrow_lower_middle { get; set; }

        public Coord left_eyebrow_lower_right_quarter { get; set; }

        public Coord left_eyebrow_right_corner { get; set; }

        public Coord left_eyebrow_upper_left_quarter { get; set; }

        public Coord left_eyebrow_upper_middle { get; set; }

        public Coord left_eyebrow_upper_right_quarter { get; set; }

        public Coord mouth_left_corner { get; set; }

        public Coord mouth_lower_lip_bottom { get; set; }

        public Coord mouth_lower_lip_left_contour1 { get; set; }

        public Coord mouth_lower_lip_left_contour2 { get; set; }

        public Coord mouth_lower_lip_left_contour3 { get; set; }

        public Coord mouth_lower_lip_right_contour1 { get; set; }

        public Coord mouth_lower_lip_right_contour2 { get; set; }

        public Coord mouth_lower_lip_right_contour3 { get; set; }

        public Coord mouth_lower_lip_top { get; set; }

        public Coord mouth_right_corner { get; set; }

        public Coord mouth_upper_lip_bottom { get; set; }

        public Coord mouth_upper_lip_left_contour1 { get; set; }

        public Coord mouth_upper_lip_left_contour2 { get; set; }

        public Coord mouth_upper_lip_left_contour3 { get; set; }

        public Coord mouth_upper_lip_right_contour1 { get; set; }

        public Coord mouth_upper_lip_right_contour2 { get; set; }

        public Coord mouth_upper_lip_right_contour3 { get; set; }

        public Coord mouth_upper_lip_top { get; set; }

        public Coord nose_contour_left1 { get; set; }

        public Coord nose_contour_left2 { get; set; }

        public Coord nose_contour_left3 { get; set; }

        public Coord nose_contour_lower_middle { get; set; }

        public Coord nose_contour_right1 { get; set; }

        public Coord nose_contour_right2 { get; set; }

        public Coord nose_contour_right3 { get; set; }

        public Coord nose_left { get; set; }

        public Coord nose_right { get; set; }

        public Coord nose_tip { get; set; }

        public Coord right_eye_bottom { get; set; }

        public Coord right_eye_center { get; set; }

        public Coord right_eye_left_corner { get; set; }

        public Coord right_eye_lower_left_quarter { get; set; }

        public Coord right_eye_lower_right_quarter { get; set; }

        public Coord right_eye_pupil { get; set; }

        public Coord right_eye_right_corner { get; set; }

        public Coord right_eye_top { get; set; }

        public Coord right_eye_upper_left_quarter { get; set; }

        public Coord right_eye_upper_right_quarter { get; set; }

        public Coord right_eyebrow_left_corner { get; set; }

        public Coord right_eyebrow_lower_left_quarter { get; set; }

        public Coord right_eyebrow_lower_middle { get; set; }

        public Coord right_eyebrow_lower_right_quarter { get; set; }

        public Coord right_eyebrow_right_corner { get; set; }

        public Coord right_eyebrow_upper_left_quarter { get; set; }

        public Coord right_eyebrow_upper_middle { get; set; }

        public Coord right_eyebrow_upper_right_quarter { get; set; }
    }

    public class Attributes
    {
        private static System.Collections.Generic.Dictionary<int, string> _genders = typeof(Gender).ToDictionary();

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender
        {
            get
            {
                if (this.GenderValue != null)
                    return (Gender)_genders.FirstOrDefault(p => p.Value.Equals(this.GenderValue.Value)).Key;
                return Gender.UnKnown;
            }
        }

        [JsonProperty("gender")]
        public GenderValue GenderValue { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age
        {
            get
            {
                if (this.AgeValue != null)
                    return this.AgeValue.Value;
                return 0;
            }
        }

        [JsonProperty("age")]
        public AgeValue AgeValue { get; set; }

        /// <summary>
        /// 笑容分析结果
        /// </summary>
        [JsonProperty("smiling")]
        public Smiling Smiling { get; set; }

        /// <summary>
        /// 人脸姿势分析结果
        /// </summary>
        [JsonProperty("headpose")]
        public HeadPose Headpose { get; set; }

        /// <summary>
        /// 人脸模糊分析结果
        /// </summary>
        [JsonProperty("blur")]
        public Blur Blur { get; set; }

        /// <summary>
        /// 眼睛状态信息
        /// </summary>
        [JsonProperty("eyestatus")]
        public EyeStatusResult EyeStatus { get; set; }

        /// <summary>
        /// 情绪识别结果
        /// </summary>
        [JsonProperty("emotion")]
        public Emotion Emotion { get; set; }

        /// <summary>
        /// 人脸质量判断结果
        /// </summary>
        [JsonProperty("facequality")]
        public FaceQuality FaceQuality { get; set; }

        /// <summary>
        /// 人种分析结果
        /// </summary>
        [JsonProperty("ethnicity")]
        public EthnicityValue EthnicityValue { get; set; }

        private static System.Collections.Generic.Dictionary<int, string> _ethnicity = typeof(Ethnicity).ToDictionary();

        /// <summary>
        /// 人种
        /// </summary>
        public Ethnicity EthnicityType
        {
            get
            {
                if (this.EthnicityValue == null || string.IsNullOrEmpty(this.EthnicityValue.Value))
                    return Core.Ethnicity.UnKnown;

                return (Ethnicity)_ethnicity.FirstOrDefault(p => p.Value.Equals(this.EthnicityValue.Value)).Key;
            }
        }

        [JsonProperty("beauty")]
        public Beauty Beauty { get; set; }

        /// <summary>
        /// 嘴部状态信息
        /// </summary>
        [JsonProperty("mouthstatus")]
        public MouthStatus MouthStatus { get; set; }

        /// <summary>
        /// 眼球位置与视线方向信息
        /// </summary>
        [JsonProperty("eyegaze")]
        public EyeGaze EyeGaze { get; set; }
    }

    public class GenderValue
    {
        [JsonProperty("value")]
        public virtual string Value { get; set; }
    }

    public class AgeValue
    {
        [JsonProperty("value")]
        public virtual int Value { get; set; }
    }

    public class EthnicityValue
    {
        [JsonProperty("value")]
        public virtual string Value { get; set; }
    }

    public class FaceRectangle
    {
        /// <summary>
        /// 矩形框左上角像素点的纵坐标
        /// </summary>
        [JsonProperty("top")]
        public int Top { get; set; }

        /// <summary>
        /// 矩形框左上角像素点的横坐标
        /// </summary>
        [JsonProperty("left")]
        public int Left { get; set; }

        /// <summary>
        /// 矩形框的宽度
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// 矩形框的高度
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        public override string ToString()
        {
            return string.Format("x:\t{0}\ty:\t{1}\twidth:\t{2}\theight:\t{3}", this.Left, this.Top, this.Width, this.Height);
        }

        /// <summary>
        /// 左 - 上 顶点坐标
        /// </summary>
        public Point TopLeft
        {
            get
            {
                return new Point(this.Left, this.Top);
            }
        }

        /// <summary>
        /// 右 - 上 顶点坐标
        /// </summary>
        public Point TopRight
        {
            get
            {
                return new Point(this.Left + this.Width, this.Top);
            }
        }

        /// <summary>
        /// 左 - 下 顶点坐标
        /// </summary>
        public Point BottomLeft
        {
            get
            {
                return new Point(this.Left, this.Top + this.Height);
            }
        }

        /// <summary>
        /// 右 - 下 顶点坐标
        /// </summary>
        public Point BottomRight
        {
            get
            {
                return new Point(this.Left + this.Width, this.Top + this.Height);
            }
        }
    }

    /// <summary>
    /// 坐标
    /// </summary>
    public class Coord
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }

    /// <summary>
    /// 笑容分析结果
    /// </summary>
    public class Smiling : ValueThreshold
    {
        /// <summary>
        /// 值为一个 [0,100] 的浮点数，小数点后3位有效数字。数值越大表示笑程度高。
        /// </summary>
        [JsonProperty("value")]
        public override decimal Value { get; set; }

        /// <summary>
        /// 代表笑容的阈值，超过该阈值认为有笑容。
        /// </summary>
        [JsonProperty("threshold")]
        public override decimal Threshold { get; set; }
    }

    public class Blur
    {
        /// <summary>
        /// 人脸模糊分析结果
        /// </summary>
        [JsonProperty("blurness")]
        public ValueThreshold Blurness { get; set; }
    }

    /// <summary>
    /// 人脸姿势分析结果。返回值包含以下属性，每个属性的值为一个 [-180, 180] 的浮点数，小数点后 6 位有效数字。单位为角度。
    /// </summary>
    public class HeadPose
    {
        /// <summary>
        /// 抬头
        /// </summary>
        [JsonProperty("pitch_angle")]
        public decimal PitchAngle { get; set; }

        /// <summary>
        /// 旋转（平面旋转）
        /// </summary>
        [JsonProperty("roll_angle")]
        public decimal RollAngle { get; set; }

        /// <summary>
        /// 摇头
        /// </summary>
        [JsonProperty("yaw_angle")]
        public decimal YawAngle { get; set; }
    }

    public class FaceQuality : ValueThreshold
    {
        /// <summary>
        /// 表示人脸质量基本合格的一个阈值，超过该阈值的人脸适合用于人脸比对。
        /// </summary>
        public override decimal Threshold { get; set; }

        /// <summary>
        /// 值为人脸的质量判断的分数，是一个浮点数，范围 [0,100]，小数点后 3 位有效数字。
        /// </summary>
        public override decimal Value { get; set; }
    }

    public class ValueThreshold
    {
        /// <summary>
        /// 值为一个 [0,100] 的浮点数，小数点后3位有效数字。
        /// </summary>
        [JsonProperty("value")]
        public virtual decimal Value { get; set; }

        /// <summary>
        /// 阈值
        /// </summary>
        [JsonProperty("threshold")]
        public virtual decimal Threshold { get; set; }
    }

    public class EyeStatus
    {
        /// <summary>
        /// 眼睛被遮挡的置信度
        /// </summary>
        [JsonProperty("occlusion")]
        public decimal Occlusion { get; set; }

        /// <summary>
        /// 眼睛被遮挡的置信度
        /// </summary>
        [JsonProperty("no_glass_eye_open")]
        public decimal NoGlassEyeOpen { get; set; }

        /// <summary>
        /// 佩戴普通眼镜且闭眼的置信度
        /// </summary>
        [JsonProperty("normal_glass_eye_close")]
        public decimal NormalGlassEyeClose { get; set; }

        /// <summary>
        /// 佩戴普通眼镜且睁眼的置信度
        /// </summary>
        [JsonProperty("normal_glass_eye_open")]
        public decimal NormalGlassEyeOpen { get; set; }

        /// <summary>
        /// 佩戴墨镜的置信度
        /// </summary>
        [JsonProperty("dark_glasses")]
        public decimal DarkGlasses { get; set; }

        /// <summary>
        /// 不戴眼镜且闭眼的置信度
        /// </summary>
        [JsonProperty("no_glass_eye_close")]
        public decimal NoGlassEyeClose { get; set; }
    }

    /// <summary>
    /// 眼睛状态信息
    /// </summary>
    public class EyeStatusResult
    {
        [JsonProperty("left_eye_status")]
        public EyeStatus LeftEyeStatus { get; set; }

        [JsonProperty("right_eye_status")]
        public EyeStatus RightEyeStatus { get; set; }
    }

    /// <summary>
    /// 情绪识别结果。返回值包含以下字段。每个字段的值都是一个浮点数，范围 [0,100]，小数点后 3 位有效数字。字段值的总和等于 100。
    /// </summary>
    public class Emotion
    {
        [JsonProperty("anger")]
        public decimal Anger { get; set; }

        [JsonProperty("disgust")]
        public decimal Disgust { get; set; }

        [JsonProperty("fear")]
        public decimal Fear { get; set; }

        [JsonProperty("happiness")]
        public decimal Happiness { get; set; }

        [JsonProperty("neutral")]
        public decimal Neutral { get; set; }

        [JsonProperty("sadness")]
        public decimal Sadness { get; set; }

        [JsonProperty("surprise")]
        public decimal Surprise { get; set; }
    }

    /// <summary>
    /// 颜值识别结果。返回值包含以下两个字段。每个字段的值是一个浮点数，范围 [0,100]，小数点后 3 位有效数字。
    /// </summary>
    public class Beauty
    {
        [JsonProperty("male_score")]
        public decimal MaleScore { get; set; }

        [JsonProperty("female_score")]
        public decimal FemaleScore { get; set; }
    }

    /// <summary>
    /// 嘴部状态信息，包括以下字段。每个字段的值都是一个浮点数，范围 [0,100]，小数点后 3 位有效数字。字段值的总和等于 100。
    /// </summary>
    public class MouthStatus
    {
        /// <summary>
        /// 嘴部被医用口罩或呼吸面罩遮挡的置信度
        /// </summary>
        [JsonProperty("surgical_mask_or_respirator")]
        public decimal SurgicalMaskOrRespirator { get; set; }

        /// <summary>
        /// 嘴部被其他物体遮挡的置信度
        /// </summary>
        [JsonProperty("other_occlusion")]
        public decimal OtherOcclusion { get; set; }

        /// <summary>
        /// 嘴部没有遮挡且闭上的置信度
        /// </summary>
        [JsonProperty("close")]
        public decimal Close { get; set; }

        /// <summary>
        /// 嘴部没有遮挡且张开的置信度
        /// </summary>
        [JsonProperty("open")]
        public decimal Open { get; set; }
    }

    /// <summary>
    /// 眼球位置与视线方向信息
    /// </summary>
    public class EyeGaze
    {
        /// <summary>
        /// 左眼的位置与视线状态
        /// </summary>
        [JsonProperty("left_eye_gaze")]
        public EyeGazeItem LeftEyeGaze { get; set; }

        /// <summary>
        /// 右眼的位置与视线状态
        /// </summary>
        [JsonProperty("right_eye_gaze")]
        public EyeGazeItem RightEyeGaze { get; set; }
    }

    /// <summary>
    /// 眼球位置与视线方向信息
    /// </summary>
    public class EyeGazeItem
    {
        /// <summary>
        /// 眼球中心位置的 X 轴坐标
        /// </summary>
        [JsonProperty("position_x_coordinate")]
        public decimal Position_X_Coordinate { get; set; }

        /// <summary>
        /// 眼球中心位置的 Y 轴坐标
        /// </summary>
        [JsonProperty("position_y_coordinate")]
        public decimal Position_Y_Coordinate { get; set; }

        /// <summary>
        /// 眼球视线方向向量的 X 轴分量
        /// </summary>
        [JsonProperty("vector_x_component")]
        public decimal Vector_X_Component { get; set; }

        /// <summary>
        /// 眼球视线方向向量的 Y 轴分量
        /// </summary>
        [JsonProperty("vector_y_component")]
        public decimal Vector_Y_Component { get; set; }

        /// <summary>
        /// 眼球视线方向向量的 Z 轴分量
        /// </summary>
        [JsonProperty("vector_z_component")]
        public decimal Vector_Z_Component { get; set; }
    }
}
