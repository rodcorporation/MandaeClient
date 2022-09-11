using Newtonsoft.Json;
using System.Collections.Generic;

namespace MandaeClient.AdicionarEncomenda
{
    public class AdicionarEncomendaRequest
    {
        [JsonProperty("customerId")]
        public string IdentificadorCliente { get; set; }

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }

        public AdicionarEncomendaRequest()
        {
            Items = new List<Item>();
        }

        public class Item
        {

            [JsonProperty("recipient")]
            public Destinatario Destinatario { get; set; }

            [JsonProperty("shippingService")]
            public string ServicoDeEnvio { get; set; }

            [JsonProperty("partnerItemId")]
            public string IdentificadorDoItem { get; set; }

            [JsonProperty("invoice")]
            public NotaFiscal NotaFiscal { get; set; }

            [JsonProperty("trackingId")]
            public string CodigoDeRastreio { get; set; }

            [JsonProperty("dimensions")]
            public Dimensao Dimensao { get; set; }

            [JsonProperty("totalValue")]
            public float ValorNotaFiscal { get; set; }

            [JsonProperty("totalFreight")]
            public float ValorFrete { get; set; }
        }

        public class Destinatario
        {
            [JsonProperty("fullName")]
            public string NomeCompleto { get; set; }

            [JsonProperty("address")]
            public Endereco Endereco { get; set; }

            [JsonProperty("document")]
            public string Documento { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("phone")]
            public string Telefone { get; set; }
        }

        public class Endereco
        {
            [JsonProperty("postalCode")]
            public string Cep { get; set; }

            [JsonProperty("street")]
            public string Logradouro { get; set; }

            [JsonProperty("number")]
            public string Numero { get; set; }

            [JsonProperty("addressLine2")]
            public string Complemento { get; set; }

            [JsonProperty("neighborhood")]
            public string Bairro { get; set; }

            [JsonProperty("city")]
            public string Cidade { get; set; }

            [JsonProperty("state")]
            public string Estado { get; set; }

            [JsonProperty("country")]
            public string Pais { get; set; }
        }

        public class NotaFiscal
        {
            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("key")]
            public string ChaveAcesso { get; set; }
        }

        public class Dimensao
        {
            [JsonProperty("height")]
            public float Altura { get; set; }

            [JsonProperty("width")]
            public float Largura { get; set; }

            [JsonProperty("length")]
            public float Comprimento { get; set; }

            [JsonProperty("weight")]
            public float PesoBruto { get; set; }
        }
    }
}
