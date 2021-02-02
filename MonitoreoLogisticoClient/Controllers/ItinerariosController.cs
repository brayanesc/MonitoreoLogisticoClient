using MonitoreoLogisticoClient.Data;
using MonitoreoLogisticoClient.Helpers;
using MonitoreoLogisticoClient.Models;
using MonitoreoLogisticoClient.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MonitoreoLogisticoClient.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    public class ItinerariosController : Controller
    {
        public ItinerariosService itinerariosService = new ItinerariosService();
        public RepartidoresService repartidoresService = new RepartidoresService();
        public ZonasService zonasService = new ZonasService();
        public DetallesItinerarioService detallesService = new DetallesItinerarioService();

        // GET: Itinerarios
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Itinerario_dto> modelos = new List<Itinerario_dto>();

            IEnumerable<Repartidor> repartidores;
            repartidores = await repartidoresService.obtenerRepartidores();

            IEnumerable<Zona> zonas;
            zonas = await zonasService.obtenerZonas();

            IEnumerable<DetalleItinerario> detalles;
            detalles = await detallesService.obtenerDetalleItinerarios();

            IEnumerable<Itinerario> itinerarios;
            itinerarios = await itinerariosService.obtenerItinerarios();

            foreach (var itinerario in itinerarios)
            {
                DetalleItinerario d = new DetalleItinerario();
                d = detalles.FirstOrDefault(x => x.Id == itinerario.DetalleItinerarioId);

                Repartidor r = new Repartidor();
                r = repartidores.FirstOrDefault(x => x.Id == itinerario.RepartidorId);

                Zona z = new Zona();
                z = zonas.FirstOrDefault(x => x.Id == itinerario.ZonaId);

                var model = new Itinerario_dto();

                model.Id = itinerario.Id;
                model.Descripcion = itinerario.Descripcion;

                model.IdDetalleItinerario = d.Id;
                model.Salida = d.Salida;
                model.Llegada = d.Llegada;

                model.RepartidorId = r.Id;
                model.NombreRepartidor = r.NombreCompleto;

                model.ZonaId = z.Id;
                model.ZonaNombre = z.Nombre;

                modelos.Add(model);

            }

            return View(modelos);



        }

        [HttpGet]
        public async Task<ActionResult> RegistrarLlegada(int detalleItinerarioId)
        {
            DetalleItinerario detalle = await detallesService.obtenerDetalleItinerario(detalleItinerarioId);
            detalle.Llegada = DateTime.Now;
            await detallesService.modificarDetalleItinerario(detalle.Id, detalle);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Mod(int id = 0)
        {
            IEnumerable<Repartidor> repartidores;
            repartidores = await repartidoresService.obtenerRepartidores();

            IEnumerable<Zona> zonas;
            zonas = await zonasService.obtenerZonas();

            IEnumerable<DetalleItinerario> detalles;
            detalles = await detallesService.obtenerDetalleItinerarios();

            ViewBag.RepartidoresListItems = repartidores.ToList();
            ViewBag.ZonasListItems = zonas.ToList();
            ViewBag.DetallesListItems = detalles.ToList();
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {

            IEnumerable<Repartidor> repartidores;
            repartidores = await repartidoresService.obtenerRepartidores();

            IEnumerable<Zona> zonas;
            zonas = await zonasService.obtenerZonas();

            //IEnumerable<DetalleItinerario> detalles;
            //detalles = await detallesService.obtenerDetalleItinerarios();

            ViewBag.RepartidoresListItems = repartidores.ToList();
            ViewBag.ZonasListItems = zonas.ToList();




            if (id == 0)
            {
                return View(new Itinerario());
            }
            else
            {
                Itinerario itinerario = await itinerariosService.obtenerItinerario(id);
                return View(itinerario);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(Itinerario itinerario)
        {
            if (itinerario.Id == 0)
            {
                await itinerariosService.adicionarItinerario(itinerario);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {

                await itinerariosService.modificarItinerario(itinerario.Id, itinerario);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            Itinerario registro = new Itinerario();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await itinerariosService.obtenerItinerario(id);
            return View(registro);


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await itinerariosService.eliminarItinerario(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }



        // GET: Itinerarios/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

    }
}
