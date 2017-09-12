using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cody.FacePP.Api.Entity
{
    public class HumanBody
    {
        [JsonProperty("humanbody_rectangle")]
        public HumanBodyRectangle BodyRectangle { get; set; }

        [JsonProperty("confidence")]
        public float Confidence { get; set; }

        [JsonProperty("attributes")]
        public HumanBodyAttributes BodyAttributes { get; set; }
    }
}
