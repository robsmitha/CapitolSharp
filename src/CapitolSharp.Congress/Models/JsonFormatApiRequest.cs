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
                var parameterList = QueryStringParameters.Where(kvp => !string.IsNullOrEmpty(kvp.Value)).Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}").ToList();
                var queryParameters = string.Join("&", parameterList);
                var newQuery = string.IsNullOrEmpty(uri.Query) ? $"&{queryParameters}" : $"{uri.Query}&{queryParameters}";
                return new Uri(uri.GetLeftPart(UriPartial.Path) + "?" + newQuery);
            }
        }
    }
}
