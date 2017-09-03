using System;

namespace Cody.FacePP.Core
{
    [Flags]
    public enum AttributesType : int
    {
        [EnumDescription("none")]
        None = 0,

        [EnumDescription("gender")]
        Gender = 1,

        [EnumDescription("age")]
        Age = 2,

        [EnumDescription("smiling")]
        Smiling = 4,

        [EnumDescription("headpose")]
        HeadPose = 8,

        [EnumDescription("facequality")]
        Facequality = 16,

        [EnumDescription("blur")]
        Blur = 32,

        [EnumDescription("eyestatus")]
        EyeStatus = 64,

        [EnumDescription("emotion")]
        Emotion = 128,

        [EnumDescription("ethnicity")]
        Ethnicity = 256,

        [EnumDescription("beauty")]
        Beauty = 512,

        [EnumDescription("mouthstatus")]
        MouthStatus = 1024,

        [EnumDescription("eyegaze")]
        EyeGaze = 2048,

        [EnumDescription("all")]
        All = 4095
    }
}
