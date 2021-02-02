using MonitoreoLogisticoClient.Data;
using MonitoreoLogisticoClient.Models;
using MonitoreoLogisticoClient.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MonitoreoLogisticoClient.Controllers
{
    [AllowAnonymous]
    public class OrdenesEntregaController : Controller
    {
        public OrdenesService ordenesService = new OrdenesService();
        public ItinerariosService itinerariosService = new ItinerariosService();
        public ClientesService clientesService = new ClientesService();


        public async Task<ActionResult> Index() {
            List<OrdenEntrega_dto> modelos = new List<OrdenEntrega_dto>();

            IEnumerable<OrdenEntrega> ordenes;
            ordenes = await ordenesService.obtenerOrdenesEntrega();

            IEnumerable<Itinerario> itinerarios;
            itinerarios = await itinerariosService.obtenerItinerarios();

            IEnumerable<Cliente> clientes;
            clientes = await clientesService.obtenerClientes();

            foreach (var orden in ordenes)
            {
                Itinerario i = new Itinerario();
                i = itinerarios.FirstOrDefault(x => x.Id == orden.ItinerarioId);

                Cliente c = new Cliente();
                c = clientes.FirstOrDefault(x => x.Id == orden.ClienteId);


                var model = new OrdenEntrega_dto();

                model.Id = orden.Id;
                model.FechaEmision = orden.FecharEmision;
                model.NroFactura = orden.NroFactura;
                model.Estado = orden.Estado;
                model.Prioridad = orden.Prioridad;

                model.ItinerarioId = i.Id;
                model.ItinerarioDescripcion = i.Descripcion;

                model.ClienteId = c.Id;
                model.ClienteNombre = c.NombreCompleto;

                modelos.Add(model);

            }
            return View(modelos);



        }

        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            List<Itinerario> itinerarios;
            itinerarios = await itinerariosService.obtenerItinerarios();

            List<Cliente> clientes;
            clientes = await clientesService.obtenerClientes();

            List<string> estados;
            estados = new List<string>{ "Pendiente", "Entregado", "No Entregado" };

            ViewBag.ItinerariosListItems = itinerarios;
            ViewBag.ClientesListItems = clientes;
            ViewBag.EstadosListItems = estados;

            if (id == 0)
            {
                return View(new OrdenEntrega());
            }
            else
            {
                OrdenEntrega orden = await ordenesService.obtenerOrdenEntrega(id);
                return View(orden);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(OrdenEntrega rol)
        {

            if (rol.Id == 0)
            {
                await ordenesService.adicionarOrdenEntrega(rol);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await ordenesService.modificarOrdenEntrega(rol.Id, rol);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            OrdenEntrega registro = new OrdenEntrega();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await ordenesService.obtenerOrdenEntrega(id);
            return View(registro);


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await ordenesService.eliminarOrdenEntrega(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

    }
}