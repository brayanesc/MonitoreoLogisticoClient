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
    public class RolesController : Controller
    {
        public RolesService rolesService = new RolesService();

        // GET: Roles
        public async Task<ActionResult> Index()
        {
            IEnumerable<Rol> roles;
            roles = await rolesService.obtenerRoles();
            return View(roles);
        }

        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Rol());
            }
            else
            {
                Rol rol = await rolesService.obtenerRol(id);
                return View(rol);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(Rol rol)
        {

            if (rol.Id == 0)
            {
                await rolesService.adicionarRol(rol);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await rolesService.modificarRol(rol.Id, rol);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            Rol registro = new Rol();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await rolesService.obtenerRol(id);
            return View(registro);


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await rolesService.eliminarRol(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id) {
            return View();
        }
    }
}