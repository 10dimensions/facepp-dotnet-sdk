using System;

namespace Cody.FacePP.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ColorDescriptionAttribute : Attribute
    {
        public string Name { get; set; }

        public string CnName { get; set; }

        public int R { get; set; }

        public int G { get; set; }

        public int B { get; set; }

        public ColorDescriptionAttribute(string name, int r, int g, int b, string cnName)
            : base()
        {
            this.Name = name;
            this.CnName = cnName;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public ColorDescriptionAttribute()
            : base()
        {

        }
    }
}
