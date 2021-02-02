using MonitoreoLogisticoClient.Helpers;
using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;
using System.Globalization;
using System.Security.Claims;
using System.Net.Http.Headers;

namespace MonitoreoLogisticoClient.Controllers
{
    [Authorize]
    public class OldClientesController : Controller
    {
        //// GET: Clientes
        //public ActionResult Index()
        //{
        //    IEnumerable<Cliente> empList = new List<Cliente>();

        //    //CLIENTES NECESITA AUTORIZACION
        //    //ANTES
        //    //HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("Clientes").Result;

        //    using (var httpclient = new HttpClient())
        //    {
        //        var identity = User.Identity as ClaimsIdentity;
        //        var user = User.Identity.Name;
        //        var accessToken = identity.Claims.FirstOrDefault(c => c.Type == "AccessToken");
        //        string token = accessToken.Value;
        //        httpclient.DefaultRequestHeaders.Add("Authorization", token);
        //        var response = httpclient.GetAsync("http://localhost:5757/api/Clientes").Result;
        //        empList = response.Content.ReadAsAsync<IEnumerable<Cliente>>().Result;


        //    }

        //    //empList = response.Content.ReadAsAsync<IEnumerable<Cliente>>().Result;
        //    //return View(empList);
        //    return View(empList);
        //}


        //[HttpGet]
        //public ActionResult AddorEdit(int id = 0)
        //{
        //    if (id == 0)
        //    {
        //        return View(new Cliente());
        //    }
        //    {
        //        HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("Clientes/" + id.ToString()).Result;
        //        return View(response.Content.ReadAsAsync<Cliente>().Result);
        //    }
        //}

        //[HttpPost]
        //public ActionResult AddorEdit(Cliente client)
        //{
        //    if (client.Id == 0)
        //    {
        //        HttpResponseMessage response = ConnectionHelper.WebApiClient.PostAsJsonAsync("Clientes", client).Result;
        //        TempData["SuccessMessage"] = "Saved Successfully";
        //    }
        //    else
        //    {
        //        HttpResponseMessage response = ConnectionHelper.WebApiClient.PutAsJsonAsync("Clientes/" + client.Id, client).Result;
        //        TempData["SuccessMessage"] = "Updated Successfully";
        //    }

        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public ActionResult Delete(int? id)
        //{
        //    Cliente registro = new Cliente();
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("Clientes/" + id.ToString()).Result;
        //    registro = response.Content.ReadAsAsync<Cliente>().Result;
        //    return View(registro);


        //}

        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    if (id == 0)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HttpResponseMessage response = ConnectionHelper.WebApiClient.DeleteAsync("Clientes/" + id.ToString()).Result;
        //    TempData["SuccessMessage"] = "Deleted Successfully";
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult MapData()
        //{

        //    List<Cliente> clientes = new List<Cliente>();
        //    List<Ubicacion> ubicaciones = new List<Ubicacion>();
        //    List<Coordenada> coordenadas = new List<Coordenada>();



        //    //var identity = User.Identity as ClaimsIdentity;
        //    //var user = User.Identity.Name;
        //    //var accessToken = identity.Claims.FirstOrDefault(c => c.Type == "AccessToken");
        //    //string token = accessToken.Value;
        //    //ConnectionHelper.WebApiClient.DefaultRequestHeaders.Add("Authorization", token);
        //    HttpResponseMessage clienteResp = ConnectionHelper.WebApiClient.GetAsync("Clientes").Result;
        //    clientes = clienteResp.Content.ReadAsAsync<List<Cliente>>().Result;

        //    HttpResponseMessage ubicacionResp = ConnectionHelper.WebApiClient.GetAsync("Ubicaciones").Result;
        //    ubicaciones = ubicacionResp.Content.ReadAsAsync<List<Ubicacion>>().Result;

        //    HttpResponseMessage coordenadaResp = ConnectionHelper.WebApiClient.GetAsync("Coordenadas").Result;
        //    coordenadas = coordenadaResp.Content.ReadAsAsync<List<Coordenada>>().Result;

        //    List<Marcador> Marcadores = new List<Marcador>();

        //    foreach (var c in clientes) {
        //        Marcador marcador = new Marcador();
        //        marcador.Nombre = c.Nombre + " " + c.ApellidoPaterno + " " + c.ApellidoMaterno;

        //        Ubicacion ubicacion = ubicaciones.Where(u => u.Id == c.UbicacionId).FirstOrDefault();
        //        Coordenada coordenada = coordenadas.Where(cord => cord.Id == ubicacion.CoordenadaId).FirstOrDefault();

        //        marcador.Latitud    = (float) double.Parse(coordenada.Latitud, CultureInfo.InvariantCulture);
        //        marcador.Longitud   = (float) double.Parse(coordenada.Longitud, CultureInfo.InvariantCulture);

        //        Marcadores.Add(marcador);
        //    }

        //    return (Json(Marcadores, JsonRequestBehavior.AllowGet));


        //    //MODIFICAR

        //    //List<Cliente> todos = new List<Cliente>();
        //    //List<Marcador> Marcadores = new List<Marcador>();

        //    //HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("Clientes").Result;
        //    //todos = response.Content.ReadAsAsync<List<Cliente>>().Result;

        //    //foreach (var x in todos)
        //    //{
        //    //    Marcador marker = new Marcador();
        //    //    marker.Nombre = x.Nombre + " " + x.Nombre;
        //    //    //marker.Latitud = (float)double.Parse(x.latitudCliente, CultureInfo.InvariantCulture);
        //    //    //marker.Longitud = (float)double.Parse(x.longitudCliente, CultureInfo.InvariantCulture);
        //    //    Marcadores.Add(marker);
        //    //}
        //}



        //// GET: Clientes/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}



    }
}
