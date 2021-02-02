using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class UbicacionesService
    {
        public static string urlBase { get; set; }

        public UbicacionesService()
        {
            urlBase = "http://localhost:5757/api/Ubicaciones/";
        }

        public async Task<List<Ubicacion>> obtenerUbicaciones()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Ubicacion> ubicaciones = response.Content.ReadAsAsync<List<Ubicacion>>().Result;
                    return ubicaciones;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Ubicacion> adicionarUbicacion(Ubicacion ubicacion)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, ubicacion))
            {
                if (response.IsSuccessStatusCode)
                {
                    Ubicacion registro = response.Content.ReadAsAsync<Ubicacion>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Ubicacion> obtenerUbicacion(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Ubicacion registro = response.Content.ReadAsAsync<Ubicacion>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Ubicacion> modificarUbicacion(int id, Ubicacion ubicacion)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), ubicacion))
            {
                if (response.IsSuccessStatusCode)
                {
                    try {

                    Ubicacion registro = response.Content.ReadAsAsync<Ubicacion>().Result;
                    return registro;
                    } catch (Exception e) { var a = e; }
                    return new Ubicacion();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Ubicacion> eliminarUbicacion(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Ubicacion registro = response.Content.ReadAsAsync<Ubicacion>().Result;
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