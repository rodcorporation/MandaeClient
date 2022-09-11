using MandaeClient.AdicionarEncomenda;
using MandaeClient.CalcularFrete;
using MandaeClient.ConsuiltarTracking;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace MandaeClient
{
    public sealed class Mandae
    {
        private readonly Credential _credential;
        private readonly IEnvironment _environment;
        private readonly HttpClient _httpClient;

        public Mandae(Credential credential,
                      IEnvironment environment)
        {
            _credential = credential;
            _environment = environment;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_environment.GetUrl())
            };
        }

        public CalcularFreteResponse CalcularFrete(string cep, CalcularFreteRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));

            var response = _httpClient.PostAsync($"/v3/postalcodes/{cep}/rates", content).Result;

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<CalcularFreteResponse>(response.Content.ReadAsStringAsync().Result);

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public AdicionarEncomendaResponse AdicionarEncomenda(AdicionarEncomendaRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));

            var response = _httpClient.PostAsync("/v2/orders/add-parcel", content).Result;

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<AdicionarEncomendaResponse>(response.Content.ReadAsStringAsync().Result);

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public ConsultarTrackingResponse ConsultarTracking(string trackingId)
        {
            var response = _httpClient.GetAsync($"/v3/trackings/{trackingId}").Result;

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ConsultarTrackingResponse>(response.Content.ReadAsStringAsync().Result);

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }
    }
}
