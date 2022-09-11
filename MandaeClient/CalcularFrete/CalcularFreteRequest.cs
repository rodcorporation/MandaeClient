using Newtonsoft.Json;
using System.Collections.Generic;

namespace MandaeClient.CalcularFrete
{
    public class CalcularFreteRequest
    {
        [JsonProperty("items")]
        public IList<Item> Items { get; set; }

        public CalcularFreteRequest()
        {
            Items = new List<Item>();
        }

        public class Item
        {
            [JsonProperty("weight")]
            public float Peso { get; set; }

            [JsonProperty("height")]
            public float Altura { get; set; }

            [JsonProperty("width")]
            public float Largura { get; set; }

            [JsonProperty("length")]
            public float Comprimento { get; set; }

            [JsonProperty("quantity")]
            public int Quantidade { get; set; }

            [JsonProperty("declaredValue")]
            public float ValorDeclarado { get; set; }
        }
    }
}
