using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MonitoreoLogisticoClient.Data
{
    public class ClientesService
    {
        public static string urlClientes { get; set; }
        public static string urlClientesPersona { get; set; }
        public static string urlClientesEmpresa { get; set; }

        public ClientesService()
        {
            urlClientes = "http://localhost:5757/api/Clientes/";
            urlClientesPersona = "http://localhost:5757/api/ClientesPersona/";
            urlClientesEmpresa = "http://localhost:5757/api/ClientesEmpresa";
        }

        public async Task<List<Cliente>> obtenerClientes()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlClientes))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Cliente> clientes = response.Content.ReadAsAsync<List<Cliente>>().Result;
                    return clientes;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Cliente> adicionarCliente(Cliente cliente)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlClientes, cliente))
            {
                if (response.IsSuccessStatusCode)
                {
                    Cliente registro = response.Content.ReadAsAsync<Cliente>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Cliente> obtenerCliente(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlClientes + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Cliente registro = response.Content.ReadAsAsync<Cliente>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<Cliente> modificarCliente(int id, Cliente cliente)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlClientes + id.ToString(), cliente))
            {
                if (response.IsSuccessStatusCode)
                {
                    Cliente registro = response.Content.ReadAsAsync<Cliente>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Cliente> eliminarCliente(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlClientes + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    Cliente registro = response.Content.ReadAsAsync<Cliente>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }


        //clientes personas

        public async Task<List<ClientePersona>> obtenerClientesPersonas() {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlClientesPersona))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<ClientePersona> clientespersona = response.Content.ReadAsAsync<List<ClientePersona>>().Result;
                    return clientespersona;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public async Task<ClientePersona> adicionarClientePersona(ClientePersona clientePersona)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlClientesPersona, clientePersona))
            {
                if (response.IsSuccessStatusCode)
                {
                    ClientePersona registro = response.Content.ReadAsAsync<ClientePersona>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }


        public async Task<ClientePersona> obtenerClientePersona(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlClientesPersona + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    ClientePersona registro = response.Content.ReadAsAsync<ClientePersona>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<ClientePersona> modificarClientePersona(int id, ClientePersona clientePersona)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlClientesPersona + id.ToString(), clientePersona))
            {
                if (response.IsSuccessStatusCode)
                {
                    ClientePersona registro = response.Content.ReadAsAsync<ClientePersona>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public async Task<ClientePersona> eliminarClientePersona(int? id)
        {
            string urlrequest = urlClientesPersona + id.ToString();
            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlrequest))
            {
                if (response.IsSuccessStatusCode)
                {
                    ClientePersona registro = response.Content.ReadAsAsync<ClientePersona>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }




        //clientes empresas

        public async Task<List<ClienteEmpresa>> obtenerClientesEmpresa()
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlClientesEmpresa))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<ClienteEmpresa> clientespersona = response.Content.ReadAsAsync<List<ClienteEmpresa>>().Result;
                    return clientespersona;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public async Task<ClienteEmpresa> adicionarClienteEmpresa(ClienteEmpresa clienteEmpresa)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PostAsJsonAsync(urlClientesEmpresa, clienteEmpresa))
            {
                if (response.IsSuccessStatusCode)
                {
                    ClienteEmpresa registro = response.Content.ReadAsAsync<ClienteEmpresa>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }


        public async Task<ClienteEmpresa> obtenerClienteEmpresa(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.GetAsync(urlClientesEmpresa + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    ClienteEmpresa registro = response.Content.ReadAsAsync<ClienteEmpresa>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<ClienteEmpresa> modificarClienteEmpresa(int id, ClienteEmpresa clienteEmpresa)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.PutAsJsonAsync(urlClientesEmpresa + id.ToString(), clienteEmpresa))
            {
                if (response.IsSuccessStatusCode)
                {
                    ClienteEmpresa registro = response.Content.ReadAsAsync<ClienteEmpresa>().Result;
                    return registro;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public async Task<ClienteEmpresa> eliminarClienteEmpresa(int? id)
        {

            using (HttpResponseMessage response = await Helpers.ConnectionHelper.httpClient.DeleteAsync(urlClientesEmpresa + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    ClienteEmpresa registro = response.Content.ReadAsAsync<ClienteEmpresa>().Result;
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