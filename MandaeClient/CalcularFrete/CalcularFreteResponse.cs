using Newtonsoft.Json;
using System.Collections.Generic;

namespace MandaeClient.CalcularFrete
{
    public class CalcularFreteResponse
    {
        [JsonProperty("data")]
        public Data Dados { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadados { get; set; }

        public class Data
        {
            [JsonProperty("postalCode")]
            public string CodigoPostal { get; set; }

            [JsonProperty("shippingServices")]
            public IList<ServicoDeEntrega> ServicosDeEntrega { get; set; }

            public class ServicoDeEntrega
            {
                [JsonProperty("id")]
                public int? Id { get; set; }

                [JsonProperty("name")]
                public string Nome { get; set; }

                [JsonProperty("days")]
                public string Dias { get; set; }

                [JsonProperty("price")]
                public float Preco { get; set; }
            }
        }

        public class Metadata
        {
            [JsonProperty("statusCode")]
            public int StatusCode { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("elapsedTimeMillis")]
            public int TempoDecorridoEmMilisegundos { get; set; }

        }
    }
}
