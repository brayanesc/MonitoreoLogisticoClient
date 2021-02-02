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
    public class EncargadosLogisticaController : Controller
    {
        public EncargadosLogisticaService encargadosService = new EncargadosLogisticaService();
        public UsuariosService usuariosService = new UsuariosService();

        // GET: EncargadosLogistica
        public async Task<ActionResult> Index()
        {
            IEnumerable<EncargadoLogistica> encargados;
            encargados = await encargadosService.obtenerEncargadosLogistica();
            return View(encargados);
        }

        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            List<Usuario> usuarios;
            usuarios = await usuariosService.obtenerUsuarios();
            usuarios = usuarios.Where(x => x.RolId == 2).ToList();

            ViewBag.UsuariosListItems = usuarios;
            if (id == 0)
            {
                return View(new EncargadoLogistica());
            }
            else
            {
                EncargadoLogistica encargado = await encargadosService.obtenerEncargadoLogistica(id);
                return View(encargado);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(EncargadoLogistica encargado)
        {

            if (encargado.Id == 0)
            {
                await encargadosService.adicionarEncargadoLogistica(encargado);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await encargadosService.modificarEncargadoLogistica(encargado.Id, encargado);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        // GET: EncargadosLogistica/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            EncargadoLogistica registro = new EncargadoLogistica();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await encargadosService.obtenerEncargadoLogistica(id);
            return View(registro);
        }

        // POST: EncargadosLogistica/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                await encargadosService.eliminarEncargadoLogistica(id);
                TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EncargadosLogistica/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
