using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class RepartidoresService
    {
        public static string urlBase { get; set; }

        public RepartidoresService()
        {
            urlBase = "http://localhost:5757/api/Repartidores/";
        }

        public async Task<List<Repartidor>> obtenerRepartidores()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Repartidor> repartidores = response.Content.ReadAsAsync<List<Repartidor>>().Result;
                    return repartidores;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Repartidor> adicionarRepartidor(Repartidor repartidor)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, repartidor))
            {
                if (response.IsSuccessStatusCode)
                {
                    Repartidor registro = response.Content.ReadAsAsync<Repartidor>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Repartidor> obtenerRepartidor(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Repartidor registro = response.Content.ReadAsAsync<Repartidor>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Repartidor> modificarRepartidor(int id, Repartidor repartidor)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), repartidor))
            {
                if (response.IsSuccessStatusCode)
                {
                    Repartidor registro = response.Content.ReadAsAsync<Repartidor>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Repartidor> eliminarRepartidor(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                
                if (response.IsSuccessStatusCode)
                {
                    Repartidor registro = response.Content.ReadAsAsync<Repartidor>().Result;
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