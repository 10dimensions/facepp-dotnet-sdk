using System;

namespace Cody.FacePP.Core
{
    public enum HumanBodyAttributes : int
    {
        [EnumDescription("none")]
        None = 0,

        [EnumDescription("gender")]
        Gender = 1,

        [EnumDescription("cloth_color")]
        ClothColor = 2,

        [EnumDescription("all")]
        All = 3
    }
}
