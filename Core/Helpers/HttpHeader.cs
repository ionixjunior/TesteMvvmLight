namespace Core.Helpers
{
    public class HttpHeader
    {
        public HttpHeader(string type, string value)
        {
            Type = type;
            Value = value;
        }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
