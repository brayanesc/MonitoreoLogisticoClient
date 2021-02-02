using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class MotivosService
    {
        public static string urlBase { get; set; }

        public MotivosService()
        {
            urlBase = "http://localhost:5757/api/MotivosNoEntrega/";
        }

        public async Task<List<MotivoNoEntrega>> obtenerMotivosNoEntrega()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<MotivoNoEntrega> motivos = response.Content.ReadAsAsync<List<MotivoNoEntrega>>().Result;
                    return motivos;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<MotivoNoEntrega> adicionarMotivoNoEntrega(MotivoNoEntrega motivo)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, motivo))
            {
                if (response.IsSuccessStatusCode)
                {
                    MotivoNoEntrega registro = response.Content.ReadAsAsync<MotivoNoEntrega>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<MotivoNoEntrega> obtenerMotivoNoEntrega(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    MotivoNoEntrega registro = response.Content.ReadAsAsync<MotivoNoEntrega>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<MotivoNoEntrega> modificarMotivoNoEntrega(int id, MotivoNoEntrega motivo)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), motivo))
            {
                if (response.IsSuccessStatusCode)
                {
                    MotivoNoEntrega registro = response.Content.ReadAsAsync<MotivoNoEntrega>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<MotivoNoEntrega> eliminarMotivoNoEntrega(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    MotivoNoEntrega registro = response.Content.ReadAsAsync<MotivoNoEntrega>().Result;
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