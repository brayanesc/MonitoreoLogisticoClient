using MonitoreoLogisticoClient.Data;
using MonitoreoLogisticoClient.Models;
using MonitoreoLogisticoClient.Models.Dtos;
using MonitoreoLogisticoClient.Models.Mapas;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MonitoreoLogisticoClient.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        public ClientesService clientesService = new ClientesService();
        public UbicacionesService ubicacionesService = new UbicacionesService();


        [HttpGet]
        public async Task<ActionResult> ClientesPersonas()
        {

            //if (User.Identity.IsAuthenticated)
            //{
            //    var identity = User.Identity as ClaimsIdentity;
            //    var nombreUsuario = identity.Name;
            //    var accessToken = identity.Claims.FirstOrDefault(c => c.Type == "AccessToken");
            //}


            List<Marcador> marcadores = new List<Marcador>();

            List<ClientePersona_dto> modelos = new List<ClientePersona_dto>();

            IEnumerable<Cliente> clientes;
            clientes = await clientesService.obtenerClientes();

            IEnumerable<ClientePersona> clientespersonas;
            clientespersonas = await clientesService.obtenerClientesPersonas();

            IEnumerable<Ubicacion> ubicaciones;
            ubicaciones = await ubicacionesService.obtenerUbicaciones();


            foreach (var cp in clientespersonas)
            {
                ClientePersona_dto model = new ClientePersona_dto();
                Marcador marcador = new Marcador();

                Cliente c = new Cliente();
                c = clientes.FirstOrDefault(x => x.Id == cp.Id);

                Ubicacion u = new Ubicacion();
                u = ubicaciones.FirstOrDefault(x => x.Id == c.UbicacionId);

                model.Id = c.Id;
                model.NombreCompleto = c.NombreCompleto;
                model.Telefono = c.Telefono;
                model.Email = c.Email;

                model.ClientePersonaId = cp.Id;
                model.CI = cp.CI;
                model.Ocupacion = cp.Ocupacion;
                model.FechaNacimiento = cp.FechaNacimiento;
                model.Edad = cp.Edad;
                model.Sexo = cp.Sexo;

                model.UbicacionId = u.Id;
                model.Descripcion = u.Descripcion;
                model.Latitud = u.Latitud;
                model.Longitud = u.Longitud;

                marcador.Latitud = (float)double.Parse(u.Latitud, CultureInfo.InvariantCulture);
                marcador.Longitud = (float)double.Parse(u.Longitud, CultureInfo.InvariantCulture);
                marcador.Descripcion = u.Descripcion;
                marcador.Nombre = c.NombreCompleto;

                marcadores.Add(marcador);


                modelos.Add(model);


            }
            ViewBag.Marcadores = marcadores;
            return View(modelos);
        }

        [HttpGet]
        public async Task<ActionResult> ClientePersonaAddorEdit(int id = 0)
        {

            if (id == 0)
            {
                return View(new ClientePersona_dto());
            }
            else
            {

                ClientePersona_dto model = new ClientePersona_dto();

                ClientePersona clientepersona = await clientesService.obtenerClientePersona(id);
                Cliente cliente = await clientesService.obtenerCliente(id);
                Ubicacion ubicacion = await ubicacionesService.obtenerUbicacion(cliente.UbicacionId);

                model.Id = cliente.Id;
                model.UbicacionId = ubicacion.Id;
                model.ClientePersonaId = clientepersona.Id;

                model.NombreCompleto = cliente.NombreCompleto;
                model.Telefono = cliente.Telefono;
                model.Email = cliente.Email;

                model.CI = clientepersona.CI;
                model.Ocupacion = clientepersona.Ocupacion;
                model.FechaNacimiento = clientepersona.FechaNacimiento;
                model.Edad = clientepersona.Edad;
                model.Sexo = clientepersona.Sexo;

                model.Descripcion = ubicacion.Descripcion;
                model.Latitud = ubicacion.Latitud;
                model.Longitud = ubicacion.Longitud;





                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ClientePersonaAddorEdit(ClientePersona_dto model) {
            if (!ModelState.IsValid) {
                return View();
            }
            var a = model;
            if (model.Id == 0)
            {
                Ubicacion ubicacion = new Ubicacion();
                ubicacion.Descripcion = model.Descripcion;
                ubicacion.Latitud = model.Latitud;
                ubicacion.Longitud = model.Longitud;

                ubicacion = await ubicacionesService.adicionarUbicacion(ubicacion);


                Cliente cliente = new Cliente();

                cliente.NombreCompleto = model.NombreCompleto;
                cliente.Telefono = model.Telefono;
                cliente.Email = model.Email;
                cliente.UbicacionId = ubicacion.Id;

                cliente = await clientesService.adicionarCliente(cliente);

                ClientePersona clientepersona = new ClientePersona();

                clientepersona.Id = cliente.Id;
                clientepersona.CI = model.CI;
                clientepersona.Ocupacion = model.Ocupacion;
                clientepersona.FechaNacimiento = model.FechaNacimiento;
                clientepersona.Edad = model.Edad;
                clientepersona.Sexo = model.Sexo;

                clientepersona = await clientesService.adicionarClientePersona(clientepersona);
                TempData["SuccessMessage"] = "Updated Successfully";

            }
            else {
                Ubicacion ubicacion = new Ubicacion();

                ubicacion.Id = model.UbicacionId;
                ubicacion.Descripcion = model.Descripcion;
                ubicacion.Latitud = model.Latitud;
                ubicacion.Longitud = model.Longitud;

                ubicacion = await ubicacionesService.modificarUbicacion(ubicacion.Id,ubicacion);


                Cliente cliente = new Cliente();

                cliente.Id = model.Id;
                cliente.NombreCompleto = model.NombreCompleto;
                cliente.Telefono = model.Telefono;
                cliente.Email = model.Email;
                cliente.UbicacionId = ubicacion.Id;

                cliente = await clientesService.modificarCliente(cliente.Id,cliente);


                ClientePersona clientepersona = new ClientePersona();

                clientepersona.Id = model.ClientePersonaId;
                clientepersona.CI = model.CI;
                clientepersona.Ocupacion = model.Ocupacion;
                clientepersona.FechaNacimiento = model.FechaNacimiento;
                clientepersona.Edad = model.Edad;
                clientepersona.Sexo = model.Sexo;

                clientepersona = await clientesService.modificarClientePersona(clientepersona.Id,clientepersona);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("ClientesPersonas");


        }


        [HttpGet]
        public async Task<ActionResult> ClientePersonaDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClientePersona_dto model = new ClientePersona_dto();

            ClientePersona clientepersona = await clientesService.obtenerClientePersona(id);
            Cliente cliente = await clientesService.obtenerCliente(clientepersona.Id);
            Ubicacion ubicacion = await ubicacionesService.obtenerUbicacion(cliente.UbicacionId);

            model.Id = cliente.Id;
            model.UbicacionId = ubicacion.Id;
            model.ClientePersonaId = clientepersona.Id;

            model.NombreCompleto = cliente.NombreCompleto;
            model.Telefono = cliente.Telefono;
            model.Email = cliente.Email;

            model.CI = clientepersona.CI;
            model.Ocupacion = clientepersona.Ocupacion;
            model.FechaNacimiento = clientepersona.FechaNacimiento;
            model.Edad = clientepersona.Edad;
            model.Sexo = clientepersona.Sexo;

            model.Descripcion = ubicacion.Descripcion;
            model.Latitud = ubicacion.Latitud;
            model.Longitud = ubicacion.Longitud;

            return View(model);


        }

        [HttpPost]
        public async Task<ActionResult> ClientePersonaDelete(ClientePersona_dto model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await clientesService.eliminarClientePersona(model.ClientePersonaId);
            await clientesService.eliminarCliente(model.Id);
            await ubicacionesService.eliminarUbicacion(model.UbicacionId);

            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("ClientesPersonas");
        }

        //Metodos antiguos sin modelo

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            IEnumerable<Cliente> clientes;
            clientes = await clientesService.obtenerClientes();
            return View(clientes);
        }


        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Cliente());
            }
            else
            {
                Cliente cliente = await clientesService.obtenerCliente(id);
                return View(cliente);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(Cliente cliente)
        {

            if (cliente.Id == 0)
            {
                await clientesService.adicionarCliente(cliente);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await clientesService.modificarCliente(cliente.Id, cliente);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            Cliente registro = new Cliente();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await clientesService.obtenerCliente(id);
            return View(registro);


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await clientesService.eliminarCliente(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}