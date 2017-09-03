using System;

namespace Cody.FacePP.Core
{
    public enum Gender : int
    {
        [EnumDescription("Male")]
        Male,

        [EnumDescription("Female")]
        Female,

        [EnumDescription("UnKnown")]
        UnKnown
    }
}
