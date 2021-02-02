using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class MarcacionesService
    {
        public static string urlBase { get; set; }

        public MarcacionesService()
        {
            urlBase = "http://localhost:5757/api/MarcacionesEntrega/";
        }

        public async Task<List<MarcacionEntrega>> obtenerMarcacionesEntrega()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<MarcacionEntrega> marcaciones = response.Content.ReadAsAsync<List<MarcacionEntrega>>().Result;
                    return marcaciones;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<MarcacionEntrega> adicionarMarcacionEntrega(MarcacionEntrega marcacion)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, marcacion))
            {
                if (response.IsSuccessStatusCode)
                {
                    MarcacionEntrega registro = response.Content.ReadAsAsync<MarcacionEntrega>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<MarcacionEntrega> obtenerMarcacionEntrega(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    MarcacionEntrega registro = response.Content.ReadAsAsync<MarcacionEntrega>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<MarcacionEntrega> modificarMarcacionEntrega(int id, MarcacionEntrega marcacion)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), marcacion))
            {
                if (response.IsSuccessStatusCode)
                {
                    MarcacionEntrega registro = response.Content.ReadAsAsync<MarcacionEntrega>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<MarcacionEntrega> eliminarMarcacionEntrega(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    MarcacionEntrega registro = response.Content.ReadAsAsync<MarcacionEntrega>().Result;
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