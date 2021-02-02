using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class EncargadosLogisticaService
    {
        public static string urlBase { get; set; }

        public EncargadosLogisticaService()
        {
            urlBase = "http://localhost:5757/api/EncargadosLogistica/";
        }

        public async Task<List<EncargadoLogistica>> obtenerEncargadosLogistica()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<EncargadoLogistica> encargadosLogistica = response.Content.ReadAsAsync<List<EncargadoLogistica>>().Result;
                    return encargadosLogistica;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<EncargadoLogistica> adicionarEncargadoLogistica(EncargadoLogistica encargadologistica)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, encargadologistica))
            {
                if (response.IsSuccessStatusCode)
                {
                    EncargadoLogistica registro = response.Content.ReadAsAsync<EncargadoLogistica>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<EncargadoLogistica> obtenerEncargadoLogistica(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    EncargadoLogistica registro = response.Content.ReadAsAsync<EncargadoLogistica>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<EncargadoLogistica> modificarEncargadoLogistica(int id, EncargadoLogistica encargadologistica)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), encargadologistica))
            {
                if (response.IsSuccessStatusCode)
                {
                    EncargadoLogistica registro = response.Content.ReadAsAsync<EncargadoLogistica>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<EncargadoLogistica> eliminarEncargadoLogistica(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    EncargadoLogistica registro = response.Content.ReadAsAsync<EncargadoLogistica>().Result;
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