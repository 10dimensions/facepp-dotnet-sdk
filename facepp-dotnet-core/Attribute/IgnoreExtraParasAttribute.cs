﻿using System;

namespace Cody.FacePP.Core
{
    /// <summary>
    /// If you want to ignore the extra paras, you could use this Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IgnoreExtraParasAttribute : Attribute
    {
        public IgnoreExtraParasAttribute()
            : base()
        {

        }
    }
}
