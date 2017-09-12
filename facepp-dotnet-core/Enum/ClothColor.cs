using System;

namespace Cody.FacePP.Core
{
    public enum ClothColor : int
    {
        [EnumDescription("black")]
        [ColorDescription("black", 0, 0, 0, "黑色")]
        Black,

        [EnumDescription("white")]
        [ColorDescription("white", 255, 255, 255, "白色")]
        White,

        [EnumDescription("red")]
        [ColorDescription("red", 255, 0, 0, "红色")]
        Red,

        [EnumDescription("green")]
        [ColorDescription("green", 0, 255, 0, "绿色")]
        Green,

        [EnumDescription("blue")]
        [ColorDescription("blue", 0, 0, 255, "蓝色")]
        Blue,

        [EnumDescription("yellow")]
        [ColorDescription("yellow", 255, 255, 0, "黄色")]
        Yellow,

        [EnumDescription("magenta")]
        [ColorDescription("magenta", 255, 0, 255, "洋红")]
        Magenta,

        [EnumDescription("cyan")]
        [ColorDescription("cyan", 0, 255, 255, "青色")]
        Cyan,

        [EnumDescription("gray")]
        [ColorDescription("gray", 128, 128, 128, "灰色")]
        Gray,

        [EnumDescription("purple")]
        [ColorDescription("purple", 128, 0, 128, "紫色")]
        Purple,

        [EnumDescription("orange")]
        [ColorDescription("orange", 255, 128, 0, "橙色")]
        Orange,

        [EnumDescription("unknown")]
        [ColorDescription("unknown", 0, 0, 0, "未知")]
        UnKnown
    }
}
