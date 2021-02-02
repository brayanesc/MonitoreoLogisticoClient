using MonitoreoLogisticoClient.Models;
using MonitoreoLogisticoClient.Models.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class CoordenadasService
    {
        public static string urlBase { get; set; }

        public CoordenadasService() {
            urlBase = "http://localhost:5757/api/Coordenadas/";
        }

        public async Task<List<Coordenada>> obtenerCoordenadas()
        {
            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Coordenada> roles = response.Content.ReadAsAsync<List<Coordenada>>().Result;
                    return roles;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Coordenada> adicionarCoordenada(Coordenada coordenada)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, coordenada))
            {
                if (response.IsSuccessStatusCode)
                {
                    Coordenada registro = response.Content.ReadAsAsync<Coordenada>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Coordenada> obtenerCoordenada(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Coordenada registro = response.Content.ReadAsAsync<Coordenada>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Coordenada> modificarCoordenada(int id, Coordenada coordenada)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), coordenada))
            {
                if (response.IsSuccessStatusCode)
                {
                    Coordenada registro = response.Content.ReadAsAsync<Coordenada>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Coordenada> eliminarCoordenada(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Coordenada registro = response.Content.ReadAsAsync<Coordenada>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<List<Coordenada_dto>> agregarCoordenadas(List<Coordenada_dto> coordenadas) {
            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, coordenadas))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Coordenada_dto> roles = response.Content.ReadAsAsync<List<Coordenada_dto>>().Result;
                    return roles;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}