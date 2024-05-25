namespace CapitolSharp.Congress.Core.Models
{
    public class CongressApiEndpoint(string format, params object[] args)
    {
        internal const string ApiServer = "https://api.congress.gov/";

        internal const string CongressDataStore = ApiServer + "/v3";

        public object[] _args = args;

        readonly string _format = format;

        public static implicit operator string(CongressApiEndpoint d) => d.ToString();

        public override string ToString()
        {
            return CongressDataStore + string.Format(_format, _args);
        }
    }
}
