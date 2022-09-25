using Newtonsoft.Json;

namespace MandaeClient
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public ErrorItem Error { get; set; }
        public class ErrorItem
        {
            [JsonProperty("code")]
            public string Codigo { get; set; }
            [JsonProperty("message")]
            public string Mensagem { get; set; }
        }
    }
}
