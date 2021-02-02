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
    [AllowAnonymous]
    //[Authorize]
    public class CoordenadasController : Controller
    {
        public CoordenadasService coordenadasService = new CoordenadasService();

        // GET: Coordenadas
        public async Task<ActionResult> Index()
        {
            IEnumerable<Coordenada> coordenadas;
            coordenadas = await coordenadasService.obtenerCoordenadas();
            return View(coordenadas);
        }

     
        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Coordenada());
            }
            {
                Coordenada coordenada = await coordenadasService.obtenerCoordenada(id);
                return View(coordenada);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(Coordenada coordenada)
        {
            if (coordenada.Id == 0)
            {
                await coordenadasService.adicionarCoordenada(coordenada);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await coordenadasService.modificarCoordenada(coordenada.Id, coordenada);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }



        // GET: Coordenadas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            Coordenada registro = new Coordenada();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await coordenadasService.obtenerCoordenada(id);
            return View(registro);
        }

        // POST: Coordenadas/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await coordenadasService.eliminarCoordenada(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        // GET: Coordenadas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }





    }
}
