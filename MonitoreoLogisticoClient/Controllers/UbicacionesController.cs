using MonitoreoLogisticoClient.Data;
using MonitoreoLogisticoClient.Helpers;
using MonitoreoLogisticoClient.Models;
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

    public class UbicacionesController : Controller
    {
        UbicacionesService ubicacionesService = new UbicacionesService();

        // GET: Ubicaciones
        public async Task<ActionResult> Index()
        {
            IEnumerable<Ubicacion> ubicaciones;
            ubicaciones = await ubicacionesService.obtenerUbicaciones();
            return View(ubicaciones);
        }


        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Ubicacion());
            }
            {
                Ubicacion ubicacion = await ubicacionesService.obtenerUbicacion(id);
                return View(ubicacion);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(Ubicacion ubicacion)
        {
            if (ubicacion.Id == 0)
            {
                await ubicacionesService.adicionarUbicacion(ubicacion);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await ubicacionesService.modificarUbicacion(ubicacion.Id, ubicacion);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            Ubicacion registro = new Ubicacion();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await ubicacionesService.obtenerUbicacion(id);
            return View(registro);


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await ubicacionesService.eliminarUbicacion(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }


        // GET: Ubicaciones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
