using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class DetallesItinerarioService
    {
        public static string urlBase { get; set; }

        public DetallesItinerarioService()
        {
            urlBase = "http://localhost:5757/api/DetallesItinerario/";
        }

        public async Task<List<DetalleItinerario>> obtenerDetalleItinerarios()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<DetalleItinerario> detalles = response.Content.ReadAsAsync<List<DetalleItinerario>>().Result;
                    return detalles;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<DetalleItinerario> adicionarDetalleItinerario(DetalleItinerario detalle)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, detalle))
            {
                if (response.IsSuccessStatusCode)
                {
                    DetalleItinerario registro = response.Content.ReadAsAsync<DetalleItinerario>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<DetalleItinerario> obtenerDetalleItinerario(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    DetalleItinerario registro = response.Content.ReadAsAsync<DetalleItinerario>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<DetalleItinerario> modificarDetalleItinerario(int id, DetalleItinerario detalle)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), detalle))
            {
                if (response.IsSuccessStatusCode)
                {
                    DetalleItinerario registro = response.Content.ReadAsAsync<DetalleItinerario>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<DetalleItinerario> eliminarDetalleItinerario(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    DetalleItinerario registro = response.Content.ReadAsAsync<DetalleItinerario>().Result;
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