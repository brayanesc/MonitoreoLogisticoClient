using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class ItinerariosService
    {
        public static string urlBase { get; set; }

        public ItinerariosService()
        {
            urlBase = "http://localhost:5757/api/Itinerarios/";
        }

        public async Task<List<Itinerario>> obtenerItinerarios()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Itinerario> itinerarios = response.Content.ReadAsAsync<List<Itinerario>>().Result;
                    return itinerarios;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Itinerario> adicionarItinerario(Itinerario itinerario)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, itinerario))
            {
                if (response.IsSuccessStatusCode)
                {
                    Itinerario registro = response.Content.ReadAsAsync<Itinerario>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Itinerario> obtenerItinerario(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Itinerario registro = response.Content.ReadAsAsync<Itinerario>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Itinerario> modificarItinerario(int id, Itinerario itinerario)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), itinerario))
            {
                if (response.IsSuccessStatusCode)
                {
                    Itinerario registro = response.Content.ReadAsAsync<Itinerario>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Itinerario> eliminarItinerario(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Itinerario registro = response.Content.ReadAsAsync<Itinerario>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }
}