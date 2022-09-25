using MandaeClient.AdicionarEncomenda;
using MandaeClient.CalcularFrete;
using MandaeClient.ConsuiltarTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

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
                BaseAddress = new Uri(_environment.GetUrl()),
            };

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_credential.Token);
        }

        public ApiResponse<CalcularFreteResponse> CalcularFrete(string cep, CalcularFreteRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = _httpClient.PostAsync($"/v3/postalcodes/{cep}/rates", content).Result;

            if (response.IsSuccessStatusCode)
                return new ApiResponse<CalcularFreteResponse>(JsonConvert.DeserializeObject<CalcularFreteResponse>(response.Content.ReadAsStringAsync().Result));

            return new ApiResponse<CalcularFreteResponse>(JsonConvert.DeserializeObject<ErrorResponse>(response.Content.ReadAsStringAsync().Result));
        }

        public ApiResponse<AdicionarEncomendaResponse> AdicionarEncomenda(AdicionarEncomendaRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = _httpClient.PostAsync("/v2/orders/add-parcel", content).Result;

            if (response.IsSuccessStatusCode)
                return new ApiResponse<AdicionarEncomendaResponse>(JsonConvert.DeserializeObject<AdicionarEncomendaResponse>(response.Content.ReadAsStringAsync().Result));

            return new ApiResponse<AdicionarEncomendaResponse>(JsonConvert.DeserializeObject<ErrorResponse>(response.Content.ReadAsStringAsync().Result));
        }

        public ApiResponse<ConsultarTrackingResponse> ConsultarTracking(string trackingId)
        {
            var response = _httpClient.GetAsync($"/v3/trackings/{trackingId}").Result;

            if (response.IsSuccessStatusCode)
                return new ApiResponse<ConsultarTrackingResponse>(JsonConvert.DeserializeObject<ConsultarTrackingResponse>(response.Content.ReadAsStringAsync().Result));

            return new ApiResponse<ConsultarTrackingResponse>(JsonConvert.DeserializeObject<ErrorResponse>(response.Content.ReadAsStringAsync().Result));
        }
    }
}
