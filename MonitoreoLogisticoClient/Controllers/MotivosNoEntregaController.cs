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
    public class MotivosNoEntregaController : Controller
    {
        public MotivosService motivosService = new MotivosService();

        // GET: MotivoNoEntregaes
        public async Task<ActionResult> Index()
        {
            IEnumerable<MotivoNoEntrega> motivos;
            motivos = await motivosService.obtenerMotivosNoEntrega();
            return View(motivos);
        }

        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new MotivoNoEntrega());
            }
            else
            {
                MotivoNoEntrega motivo = await motivosService.obtenerMotivoNoEntrega(id);
                return View(motivo);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(MotivoNoEntrega motivo)
        {

            if (motivo.Id == 0)
            {
                await motivosService.adicionarMotivoNoEntrega(motivo);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await motivosService.modificarMotivoNoEntrega(motivo.Id, motivo);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            MotivoNoEntrega registro = new MotivoNoEntrega();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await motivosService.obtenerMotivoNoEntrega(id);
            return View(registro);


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await motivosService.eliminarMotivoNoEntrega(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View();
        }


    }
}
