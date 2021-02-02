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
    public class RepartidoresController : Controller
    {
        public RepartidoresService repartidoresService = new RepartidoresService();
        public UsuariosService usuariosService = new UsuariosService();

        // GET: Repartidores
        public async Task<ActionResult> Index3()
        {
            IEnumerable<Repartidor> repartidores;
            repartidores = await repartidoresService.obtenerRepartidores();
            return View(repartidores);
        }

        public async Task<ActionResult> Index()
        {
            List<Repartidor_dto> modelos = new List<Repartidor_dto>();

            IEnumerable<Repartidor> repartidores;
            repartidores = await repartidoresService.obtenerRepartidores();

            IEnumerable<Usuario> usuarios;
            usuarios = await usuariosService.obtenerUsuarios();

            foreach (var repartidor in repartidores)
            {
                Usuario u = new Usuario();
                u = usuarios.FirstOrDefault(x => x.Id == repartidor.UsuarioId);

                var model = new Repartidor_dto();

                model.Id = repartidor.Id;
                model.NombreCompleto = repartidor.NombreCompleto;
                model.Telefono = repartidor.Telefono;
                model.Email = repartidor.Email;
                model.FechaIngreso = repartidor.FechaIngreso;
                model.CI = repartidor.CI;
                model.Edad = repartidor.Edad;

                model.UsuarioId = u.Id;
                model.UsuarioNombre = u.NombreUsuario;

                modelos.Add(model);


            }

            return View(modelos);
        }

        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            List<Usuario> usuarios;
            usuarios = await usuariosService.obtenerUsuarios();

            ViewBag.UsuariosListItems = usuarios;

            if (id == 0)
            {
                return View(new Repartidor());
            }
            {
                Repartidor repartidor = await repartidoresService.obtenerRepartidor(id);
                return View(repartidor);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(Repartidor repartidor)
        {
            if (repartidor.Id == 0)
            {
                await repartidoresService.adicionarRepartidor(repartidor);
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                await repartidoresService.modificarRepartidor(repartidor.Id, repartidor);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            Repartidor registro = new Repartidor();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await repartidoresService.obtenerRepartidor(id);
            return View(registro);


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await repartidoresService.eliminarRepartidor(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        // GET: Repartidores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


    }
}
