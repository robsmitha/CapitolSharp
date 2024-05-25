namespace CapitolSharp.Congress.Models
{
    public abstract class JsonFormatApiRequest<T>
    {
        public abstract CongressApiEndpoint Endpoint { get; }

        public virtual Dictionary<string, string> QueryStringParameters => new()
        {
            {"format", "json" },
        };

        public Uri Uri
        {
            get
            {
                var uri = new Uri(Endpoint);
                var parameterList = QueryStringParameters.Keys.Select(k => $"{k}={Uri.EscapeDataString(QueryStringParameters[k])}").ToList();
                var queryParameters = string.Join("&", parameterList);
                var newQuery = string.IsNullOrEmpty(uri.Query) ? $"&{queryParameters}" : $"{uri.Query}&{queryParameters}";
                return new Uri(uri.GetLeftPart(UriPartial.Path) + "?" + newQuery);
            }
        }
    }
}
