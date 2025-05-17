using Newtonsoft.Json;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxRadboltGen
{
    [JsonObject(MemberSerialization.OptIn)]
    [RestartRequired]

    public class MaxRadboltGenOptions
    {
        [Option("Max Radbolt Generation", "MaxRadboltGen")]
        [JsonProperty]
        [Limit(0f, 100f)]
        public float MaxRadboltGen { get; set; } = 0.5f;
    }
}
