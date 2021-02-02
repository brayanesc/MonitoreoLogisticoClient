using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class RolesService
    {

        public static string urlBase { get; set; }

        public RolesService() {
            urlBase = "http://localhost:5757/api/Roles/";
        }

        public async Task<List<Rol>> obtenerRoles() {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Rol> roles = response.Content.ReadAsAsync<List<Rol>>().Result;
                    return roles;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            } 
        }

        public async Task<Rol> adicionarRol(Rol rol)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, rol))
            {
                if (response.IsSuccessStatusCode)
                {
                    Rol registro = response.Content.ReadAsAsync<Rol>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Rol> obtenerRol(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Rol registro = response.Content.ReadAsAsync<Rol>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Rol> modificarRol(int id, Rol rol)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), rol))
            {
                if (response.IsSuccessStatusCode)
                {
                    Rol registro = response.Content.ReadAsAsync<Rol>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Rol> eliminarRol(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Rol registro = response.Content.ReadAsAsync<Rol>().Result;
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