using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class ZonasService
    {
        public static string urlBase { get; set; }

        public ZonasService()
        {
            urlBase = "http://localhost:5757/api/Zonas/";
        }

        public async Task<List<Zona>> obtenerZonas()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Zona> roles = response.Content.ReadAsAsync<List<Zona>>().Result;
                    return roles;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Zona> adicionarZona(Zona rol)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, rol))
            {
                if (response.IsSuccessStatusCode)
                {
                    Zona registro = response.Content.ReadAsAsync<Zona>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Zona> obtenerZona(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Zona registro = response.Content.ReadAsAsync<Zona>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Zona> modificarZona(int id, Zona rol)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), rol))
            {
                if (response.IsSuccessStatusCode)
                {
                    Zona registro = response.Content.ReadAsAsync<Zona>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Zona> eliminarZona(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Zona registro = response.Content.ReadAsAsync<Zona>().Result;
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