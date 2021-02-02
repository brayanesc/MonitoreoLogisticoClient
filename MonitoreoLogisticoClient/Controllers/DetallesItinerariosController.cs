using MonitoreoLogisticoClient.Data;
using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MonitoreoLogisticoClient.Controllers
{
    public class DetallesItinerariosController : Controller
    {
        public DetallesItinerarioService detallesService = new DetallesItinerarioService();

        // GET: DetallesItinerarios
        public async Task<ActionResult> Index()
        {
            IEnumerable<DetalleItinerario> detalles;
            detalles = await detallesService.obtenerDetalleItinerarios();
            return View(detalles);
        }

        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new DetalleItinerario());
            }
            else
            {
                DetalleItinerario detalle = await detallesService.obtenerDetalleItinerario(id);
                return View(detalle);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(DetalleItinerario detalle)
        {

            if (detalle.Id == 0)
            {
                await detallesService.adicionarDetalleItinerario(detalle);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await detallesService.modificarDetalleItinerario(detalle.Id, detalle);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }



        // GET: DetallesItinerarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            DetalleItinerario registro = new DetalleItinerario();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await detallesService.obtenerDetalleItinerario(id);
            return View();
        }

        // POST: DetallesItinerarios/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                await detallesService.eliminarDetalleItinerario(id);
                TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DetallesItinerarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
