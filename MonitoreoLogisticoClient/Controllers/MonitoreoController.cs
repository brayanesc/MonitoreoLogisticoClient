using MonitoreoLogisticoClient.Helpers;
using MonitoreoLogisticoClient.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MonitoreoLogisticoClient.Controllers
{
    [Authorize]
    public class MonitoreoController : Controller
    {
        //    public ActionResult EntregasPreview()
        //    {
        //        return View();
        //    }

        //    public ActionResult ZonasPreview()
        //    {
        //        return View();
        //    }

        //    public ActionResult DatosMapa()
        //    {

        //        List<OrdenEntrega> ordenes = new List<OrdenEntrega>();

        //        List<Cliente> clientes = new List<Cliente>();
        //        List<Ubicacion> ubicaciones = new List<Ubicacion>();
        //        List<Coordenada> coordenadas = new List<Coordenada>();


        //        HttpResponseMessage ordenesResp = ConnectionHelper.WebApiClient.GetAsync("OrdenEntregas").Result;
        //        ordenes = ordenesResp.Content.ReadAsAsync<List<OrdenEntrega>>().Result;

        //        HttpResponseMessage clienteResp = ConnectionHelper.WebApiClient.GetAsync("Clientes").Result;
        //        clientes = clienteResp.Content.ReadAsAsync<List<Cliente>>().Result;

        //        HttpResponseMessage ubicacionResp = ConnectionHelper.WebApiClient.GetAsync("Ubicaciones").Result;
        //        ubicaciones = ubicacionResp.Content.ReadAsAsync<List<Ubicacion>>().Result;

        //        HttpResponseMessage coordenadaResp = ConnectionHelper.WebApiClient.GetAsync("Coordenadas").Result;
        //        coordenadas = coordenadaResp.Content.ReadAsAsync<List<Coordenada>>().Result;

        //        List<Marcador> Marcadores = new List<Marcador>();

        //        clientes = clientes.Where(x => ordenes.Any(a => a.ClienteId == x.Id)).ToList();

        //        foreach (var client in clientes)
        //        {
        //            foreach (var orden in ordenes)
        //            {
        //                if (client.Id == orden.ClienteId)
        //                {
        //                    Marcador marcador = new Marcador();
        //                    marcador.Nombre = client.Nombre + " " + client.ApellidoPaterno + " " + client.ApellidoMaterno;

        //                    Ubicacion ubicacion = ubicaciones.Where(u => u.Id == client.UbicacionId).FirstOrDefault();
        //                    Coordenada coordenada = coordenadas.Where(cord => cord.Id == ubicacion.CoordenadaId).FirstOrDefault();

        //                    marcador.Latitud = (float)double.Parse(coordenada.Latitud, CultureInfo.InvariantCulture);
        //                    marcador.Longitud = (float)double.Parse(coordenada.Longitud, CultureInfo.InvariantCulture);

        //                    //logica de condicion
        //                    switch (orden.Estado)
        //                    {
        //                        case "Entregado":
        //                            marcador.Icono = "http://maps.google.com/mapfiles/ms/icons/green-dot.png";
        //                            break;
        //                        case "Pendiente":
        //                            marcador.Icono = "http://maps.google.com/mapfiles/ms/icons/yellow-dot.png";
        //                            break;
        //                        case "NEntregado":
        //                            marcador.Icono = "http://maps.google.com/mapfiles/ms/icons/red-dot.png";
        //                            break;


        //                    }


        //                    Marcadores.Add(marcador);
        //                }
        //            }
        //        }

        //        //foreach (var c in clientes)
        //        //{
        //        //    Marcador marcador = new Marcador();
        //        //    marcador.Nombre = c.Nombre + " " + c.ApellidoPaterno + " " + c.ApellidoMaterno;

        //        //    Ubicacion ubicacion = ubicaciones.Where(u => u.Id == c.UbicacionId).FirstOrDefault();
        //        //    Coordenada coordenada = coordenadas.Where(cord => cord.Id == ubicacion.CoordenadaId).FirstOrDefault();

        //        //    marcador.Latitud = (float)double.Parse(coordenada.Latitud, CultureInfo.InvariantCulture);
        //        //    marcador.Longitud = (float)double.Parse(coordenada.Longitud, CultureInfo.InvariantCulture);

        //        //    Marcadores.Add(marcador);
        //        //}

        //        return (Json(Marcadores, JsonRequestBehavior.AllowGet));

        //    }

        //    public ActionResult DatosZonificacion()
        //    {
        //        List<Zona> zonas = new List<Zona>();
        //        List<ZonaDetalle> detalles = new List<ZonaDetalle>();


        //        List<Zonificacion> zonificaciones = new List<Zonificacion>();



        //        HttpResponseMessage zonaResp = ConnectionHelper.WebApiClient.GetAsync("Zonas").Result;
        //        zonas = zonaResp.Content.ReadAsAsync<List<Zona>>().Result;

        //        HttpResponseMessage detalleResp = ConnectionHelper.WebApiClient.GetAsync("ZonaDetalles").Result;
        //        detalles = detalleResp.Content.ReadAsAsync<List<ZonaDetalle>>().Result;

        //        foreach (var x in zonas)
        //        {
        //            Zonificacion item = new Zonificacion();

        //            item.Nombre = x.Nombre;

        //            var detalles_de_zona = detalles.Where(y => y.ZonaId == x.Id).ToList<ZonaDetalle>();

        //            foreach (var det in detalles_de_zona)
        //            {
        //                Coordenadas coordenada = new Coordenadas();
        //                coordenada.lat = det.Latitud;
        //                coordenada.lng = det.Longitud;

        //                item.Coordenadas.Add(coordenada);
        //            }

        //            zonificaciones.Add(item);
        //        }

        //        return (Json(zonificaciones, JsonRequestBehavior.AllowGet));






        //    }


        //    // GET: Monitoreo
        //    public ActionResult Index()
        //    {
        //        return View();
        //    }

        //    // GET: Monitoreo/Details/5
        //    public ActionResult Details(int id)
        //    {
        //        return View();
        //    }

        //    // GET: Monitoreo/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Monitoreo/Create
        //    [HttpPost]
        //    public ActionResult Create(FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add insert logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    [HttpGet]
        //    public JsonResult PolygonData()
        //    {
        //        IEnumerable<ZonaCoordenada> zona_coord;
        //        IEnumerable<Zona> zona;
        //        IEnumerable<Coordenada> coord;
        //        HttpResponseMessage data = ConnectionHelper.WebApiClient.GetAsync("Zonas_Coordenadas").Result;
        //        HttpResponseMessage c = ConnectionHelper.WebApiClient.GetAsync("Coordenadas").Result;
        //        HttpResponseMessage z = ConnectionHelper.WebApiClient.GetAsync("Zonas").Result;

        //        zona_coord = data.Content.ReadAsAsync<IEnumerable<ZonaCoordenada>>().Result;
        //        zona = z.Content.ReadAsAsync<IEnumerable<Zona>>().Result;
        //        coord = c.Content.ReadAsAsync<IEnumerable<Coordenada>>().Result;





        //        return Json(zona_coord, JsonRequestBehavior.AllowGet);

        //    }


        //    //AGREGAR DE ZONAS
        //    [HttpPost]
        //    public ActionResult Polygonos(List<Zonificacion> zonificacion)
        //    {

        //        foreach (var x in zonificacion)
        //        {
        //            HttpResponseMessage response = new HttpResponseMessage();
        //            Zona zona = new Zona();
        //            zona.Nombre = x.Nombre;
        //            response = ConnectionHelper.WebApiClient.PostAsJsonAsync("Zonas", zona).Result;
        //            var zona_agregada = response.Content.ReadAsAsync<Zona>().Result;

        //            foreach (var y in x.Coordenadas)
        //            {
        //                ZonaDetalle zonacoordenada = new ZonaDetalle();

        //                HttpResponseMessage responseDetalle = new HttpResponseMessage();
        //                ZonaDetalle detalle = new ZonaDetalle();
        //                detalle.Latitud = y.lat;
        //                detalle.Longitud = y.lng;
        //                detalle.ZonaId = zona_agregada.Id;
        //                responseDetalle = ConnectionHelper.WebApiClient.PostAsJsonAsync("ZonaDetalles", detalle).Result;
        //                var detalle_agregado = responseDetalle.Content.ReadAsAsync<ZonaDetalle>().Result;



        //                //HttpResponseMessage coordenadas_response = new HttpResponseMessage();
        //                //Coordenada coordenada = new Coordenada();
        //                //ZonaCoordenada zonacoordenada = new ZonaCoordenada();

        //                //coordenada.Latitud = y.lat.ToString();
        //                //coordenada.Longitud = y.lng.ToString();
        //                //coordenadas_response = ConnectionHelper.WebApiClient.PostAsJsonAsync("Coordenadas", coordenada).Result;
        //                //var coordenada_agregada = coordenadas_response.Content.ReadAsAsync<Coordenada>().Result;



        //                //zonacoordenada.ZonaId = zona_agregada.Id;
        //                //zonacoordenada.CoordenadaId = coordenada_agregada.Id;

        //                //HttpResponseMessage zona_coordenada = new HttpResponseMessage();
        //                //zona_coordenada = ConnectionHelper.WebApiClient.PostAsJsonAsync("Zonas_Coordenadas", zonacoordenada).Result;


        //            }

        //        }



        //        Console.Beep();
        //        return View();

        //    }

        //    // GET: Monitoreo/Edit/5
        //    public ActionResult Edit(int id)
        //    {
        //        return View();
        //    }

        //    // POST: Monitoreo/Edit/5
        //    [HttpPost]
        //    public ActionResult Edit(int id, FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add update logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: Monitoreo/Delete/5
        //    public ActionResult Delete(int id)
        //    {
        //        return View();
        //    }

        //    // POST: Monitoreo/Delete/5
        //    [HttpPost]
        //    public ActionResult Delete(int id, FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add delete logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
    }
}
