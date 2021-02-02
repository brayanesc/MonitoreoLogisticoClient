using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class UsuariosService
    {
        public static string urlBase { get; set; }

        public UsuariosService()
        {
            urlBase = "http://localhost:5757/api/Usuarios/";
        }

        public async Task<List<Usuario>> obtenerUsuarios()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Usuario> roles = response.Content.ReadAsAsync<List<Usuario>>().Result;
                    return roles;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Usuario> adicionarUsuario(Usuario usuario)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlBase, usuario))
            {
                if (response.IsSuccessStatusCode)
                {
                    Usuario registro = response.Content.ReadAsAsync<Usuario>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Usuario> obtenerUsuario(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Usuario registro = response.Content.ReadAsAsync<Usuario>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Usuario> modificarUsuario(int id, Usuario usuario)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlBase + id.ToString(), usuario))
            {
                if (response.IsSuccessStatusCode)
                {
                    Usuario registro = response.Content.ReadAsAsync<Usuario>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Usuario> eliminarUsuario(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlBase + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Usuario registro = response.Content.ReadAsAsync<Usuario>().Result;
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