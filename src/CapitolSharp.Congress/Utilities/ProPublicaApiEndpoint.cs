using CapitolSharp.Congress.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Utilities
{
    public class ProPublicaApiEndpoint(string format, params object[] args)
    {
        internal const string ApiServer = "https://api.propublica.org";

        internal const string CongressDataStore = ApiServer + "/congress/v1";

        public object[] _args = args;

        readonly string _format = format;

        private static readonly HashSet<string> replaceUnderscoreList = Enum.GetValues(typeof(ExpenseCategoryOption))
                                        .Cast<ExpenseCategoryOption>()
                                        .Select(c => c.ToString())
                                        .Where(s => s.Contains('_'))
                                        .ToHashSet();

        public static implicit operator string(ProPublicaApiEndpoint d) => d.ToString();

        public override string ToString()
        {
            for (var i = 0; i < _args?.Length; i++)
            {
                if (replaceUnderscoreList.Contains(_args[i].ToString(), StringComparer.InvariantCultureIgnoreCase))
                {
                    _args[i] = _args[i]!.ToString()!.Replace("_", "-");
                }
            }

            return CongressDataStore + string.Format(_format, _args);
        }
    }
}
