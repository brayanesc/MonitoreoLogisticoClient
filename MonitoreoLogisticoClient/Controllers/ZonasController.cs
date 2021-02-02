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
using System.Web.Script.Serialization;

namespace MonitoreoLogisticoClient.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    public class ZonasController : Controller
    {
        public ZonasService zonasService = new ZonasService();
        public CoordenadasService coordenadasService = new CoordenadasService();
        // GET: Zonas
        public async Task<ActionResult> Index()
        {


            List<ZonaCoordenada_dto> zonasCoord = new List<ZonaCoordenada_dto>();
            var zonasa = await zonasService.obtenerZonas();
            var coordenadas = await coordenadasService.obtenerCoordenadas();

            foreach (var z in zonasa)
            {
                ZonaCoordenada_dto item = new ZonaCoordenada_dto();
                List<Coordenada_dto> coord_mapa = new List<Coordenada_dto>();
                var coords_zona = coordenadas.Where(x => x.ZonaId == z.Id).ToList();

                foreach (var c in coords_zona)
                {
                    Coordenada_dto coordenada = new Coordenada_dto();

                    coordenada.lat = c.Latitud;
                    coordenada.lng = c.Longitud;

                    coord_mapa.Add(coordenada);
                }

                item.zonaid = z.Id;
                item.coordenadas = coord_mapa;

                zonasCoord.Add(item);
            }

            ViewBag.CoordenadasTotalesListItems = zonasCoord;



            IEnumerable<Zona> zonas;
            zonas = await zonasService.obtenerZonas();
            return View(zonas);
        }

        [HttpGet]
        public async Task<ActionResult> AddorEdit(int id = 0)
        {
            



            if (id == 0)
            {
                ViewBag.CoordenadasListItems = new List<Coordenada>();
                
                return View(new Zona());
            }
            {
                Zona zona = await zonasService.obtenerZona(id);
                List<Coordenada> coordenadas2 = await coordenadasService.obtenerCoordenadas();
                List<Coordenada> cords = coordenadas2.Where(x => x.ZonaId == zona.Id).ToList();
                ViewBag.CoordenadasListItems = cords;

                List<ZonaCoordenada_dto> zonasCoord = new List<ZonaCoordenada_dto>();
                var zonas = await zonasService.obtenerZonas();
                var coordenadas = await coordenadasService.obtenerCoordenadas();

                foreach (var z in zonas)
                {
                    ZonaCoordenada_dto item = new ZonaCoordenada_dto();
                    List<Coordenada_dto> coord_mapa = new List<Coordenada_dto>();
                    var coords_zona = coordenadas.Where(x => x.ZonaId == z.Id).ToList();

                    foreach (var c in coords_zona)
                    {
                        Coordenada_dto coordenada = new Coordenada_dto();

                        coordenada.lat = c.Latitud;
                        coordenada.lng = c.Longitud;

                        coord_mapa.Add(coordenada);
                    }

                    item.zonaid = z.Id;
                    item.coordenadas = coord_mapa;

                    zonasCoord.Add(item);
                }

                ViewBag.CoordenadasTotalesListItems = zonasCoord;
                zona.datos = zonasCoord;


                return View(zona);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddorEdit(Zona zona)
        {



            if (zona.Id == 0)
            {
                Zona z = await zonasService.adicionarZona(zona);
                if (zona.Coordenadas != null)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string valor = zona.Coordenadas;
                    Coordenada_dto[] puntos = js.Deserialize<Coordenada_dto[]>(valor);
                    foreach (var p in puntos)
                    {
                        Coordenada c = new Coordenada();
                        c.Latitud = p.lat;
                        c.Longitud = p.lng;
                        c.ZonaId = z.Id;
                        await coordenadasService.adicionarCoordenada(c);
                    }

                }


                TempData["SuccessMessage"] = "Saved Successfully";

            }
            else
            {


                await zonasService.modificarZona(zona.Id, zona);
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            Zona registro = new Zona();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro = await zonasService.obtenerZona(id);
            return View(registro);


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await zonasService.eliminarZona(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }



        // GET: Zonas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

       
    }
}
