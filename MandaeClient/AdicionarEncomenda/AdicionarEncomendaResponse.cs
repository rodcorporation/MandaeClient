using Newtonsoft.Json;
using System.Collections.Generic;

namespace MandaeClient.AdicionarEncomenda
{
    public class AdicionarEncomendaResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("customerId")]
        public string IdentificadorCliente { get; set; }

        [JsonProperty("vehicle")]
        public string Veiculo { get; set; }

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }

        public AdicionarEncomendaResponse()
        {
            Items = new List<Item>();
        }

        public class Item
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("reference")]
            public string Referencia { get; set; }

            [JsonProperty("sender")]
            public Remetente Remetente { get; set; }

            [JsonProperty("recipient")]
            public Destinatario Destinatario { get; set; }

            [JsonProperty("shippingService")]
            public string ServicoDeEnvio { get; set; }

            [JsonProperty("valueAddedServices")]
            public IList<ValorItemServico> ValoresItensServicos { get; set; }

            [JsonProperty("partnerItemId")]
            public string IdentificadorDoItem { get; set; }

            [JsonProperty("invoice")]
            public NotaFiscal NotaFiscal { get; set; }

            [JsonProperty("trackingId")]
            public string CodigoDeRastreio { get; set; }

            [JsonProperty("plataform")]
            public string Plataform { get; set; }

            [JsonProperty("inputChannel")]
            public string CanalDeVenda { get; set; }

            public Item()
            {
                ValoresItensServicos = new List<ValorItemServico>();
            }
        }

        public class Remetente
        {
            [JsonProperty("fullName")]
            public string NomeCompleto { get; set; }

            [JsonProperty("address")]
            public Endereco Endereco { get; set; }

            [JsonProperty("document")]
            public string Documento { get; set; }

            [JsonProperty("ie")]
            public string InscricaoEstadual { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("phone")]
            public string Telefone { get; set; }
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

            [JsonProperty("reference")]
            public string Reference { get; set; }
        }

        public class ValorItemServico
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("value")]
            public float Value { get; set; }
        }

        public class NotaFiscal
        {
            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("key")]
            public string ChaveAcesso { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }
    }
}
