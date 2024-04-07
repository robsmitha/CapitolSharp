using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Options
{
    public enum ChamberOption
    {
        [SerializedOption("house")]
        House,

        [SerializedOption("senate")]
        Senate,

        [SerializedOption("both")]
        Both,
    }
}
