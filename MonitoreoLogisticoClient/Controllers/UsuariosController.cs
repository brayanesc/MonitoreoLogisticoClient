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
    public class UsuariosController : Controller
    {
        public UsuariosService usuariosService = new UsuariosService();
        public RolesService rolesService = new RolesService();

        // GET: Usuarios
        public async Task<ActionResult> Index()
        {
            IEnumerable<Usuario> usuarios;
            usuarios = await usuariosService.obtenerUsuarios();
            return View(usuarios);
        }

        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            List<Rol> roles;
            roles = await rolesService.obtenerRoles();

            ViewBag.RolesListItems = roles;

            if (id == 0)
            {
                return View(new Usuario());
            }
            else
            {
                Usuario usuario = await usuariosService.obtenerUsuario(id);
                return View(usuario);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(Usuario usuario)
        {

            if (usuario.Id == 0)
            {
                await usuariosService.adicionarUsuario(usuario);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await usuariosService.modificarUsuario(usuario.Id, usuario);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            Usuario registro = new Usuario();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await usuariosService.obtenerUsuario(id);
            return View(registro);


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await usuariosService.eliminarUsuario(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

    }


}