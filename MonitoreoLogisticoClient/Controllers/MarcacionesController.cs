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
    [AllowAnonymous]
    public class MarcacionesController : Controller
    {
        public MarcacionesService marcacionesService = new MarcacionesService();

        // GET: MarcacionEntregaes
        public async Task<ActionResult> Index()
        {
            IEnumerable<MarcacionEntrega> marcaciones;
            marcaciones = await marcacionesService.obtenerMarcacionesEntrega();
            return View(marcaciones);
        }

        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new MarcacionEntrega());
            }
            else
            {
                MarcacionEntrega rol = await marcacionesService.obtenerMarcacionEntrega(id);
                return View(rol);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(MarcacionEntrega rol)
        {

            if (rol.Id == 0)
            {
                await marcacionesService.adicionarMarcacionEntrega(rol);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await marcacionesService.modificarMarcacionEntrega(rol.Id, rol);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            MarcacionEntrega registro = new MarcacionEntrega();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await marcacionesService.obtenerMarcacionEntrega(id);
            return View(registro);


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await marcacionesService.eliminarMarcacionEntrega(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}