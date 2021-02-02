using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class OrdenesService
    {

        public static string urlBase { get; set; }

        public OrdenesService()
        {
            urlBase = "http://localhost:5757/api/OrdenesEntrega/";
        }

        public async Task<List<OrdenEntrega>> obtenerOrdenesEntrega()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<OrdenEntrega> ordenes = response.Content.ReadAsAsync<List<OrdenEntrega>>().Result;
                    return ordenes;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<OrdenEntrega> adicionarOrdenEntrega(OrdenEntrega orden)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, orden))
            {
                if (response.IsSuccessStatusCode)
                {
                    OrdenEntrega registro = response.Content.ReadAsAsync<OrdenEntrega>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<OrdenEntrega> obtenerOrdenEntrega(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    OrdenEntrega registro = response.Content.ReadAsAsync<OrdenEntrega>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<OrdenEntrega> modificarOrdenEntrega(int id, OrdenEntrega orden)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), orden))
            {
                if (response.IsSuccessStatusCode)
                {
                    OrdenEntrega registro = response.Content.ReadAsAsync<OrdenEntrega>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<OrdenEntrega> eliminarOrdenEntrega(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    OrdenEntrega registro = response.Content.ReadAsAsync<OrdenEntrega>().Result;
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