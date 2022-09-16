using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace MandaeClient.ConsuiltarTracking
{
    public class ConsultarTrackingResponse
    {

        [JsonProperty("trackingCode")]
        public string CodigoDeRastreio { get; set; }

        [JsonProperty("carrierCode")]
        public string CodigoDaOperadora { get; set; }

        [JsonProperty("carrierName")]
        public string NomeDaOperadora{ get; set; }

        [JsonProperty("idItemParceiro")]
        public string IdDoItemDoParceiro { get; set; }

        [JsonProperty("partnerItemId")]
        public string IdDoParceiro { get; set; }

        [JsonProperty("events")]
        public IList<Event> Eventos { get; set; }

        public ConsultarTrackingResponse()
        {
            Eventos = new List<Event>();
        }

        public class Event
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("date")]
            public string Data { get; set; }

            [JsonProperty("timestamp")]
            public string Tempo { get; set; }

            [JsonProperty("name")]
            public string Nome { get; set; }

            [JsonProperty("description")]
            public string Descricao { get; set; }
        }
    }
}
