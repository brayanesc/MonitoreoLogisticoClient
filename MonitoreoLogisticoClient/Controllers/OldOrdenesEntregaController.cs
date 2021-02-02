using MonitoreoLogisticoClient.Helpers;
using MonitoreoLogisticoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MonitoreoLogisticoClient.Controllers
{
    [Authorize]
    public class OldOrdenesEntregaController : Controller
    {
        //// GET: OrdenesEntrega
        //public ActionResult Index()
        //{
        //    IEnumerable<OrdenEntrega> empList;
        //    HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("OrdenEntregas").Result;
        //    empList = response.Content.ReadAsAsync<IEnumerable<OrdenEntrega>>().Result;
        //    return View(empList);
        //}


        //[HttpGet]
        //public ActionResult AddorEdit(int id = 0)
        //{
        //    IEnumerable<Cliente> clientes;
        //    HttpResponseMessage clientes_response = ConnectionHelper.WebApiClient.GetAsync("Clientes").Result;
        //    clientes = clientes_response.Content.ReadAsAsync<IEnumerable<Cliente>>().Result;

        //    IEnumerable<Itinerario> itinerarios;
        //    HttpResponseMessage itinerario_response = ConnectionHelper.WebApiClient.GetAsync("Itinerarios").Result;
        //    itinerarios = itinerario_response.Content.ReadAsAsync<IEnumerable<Itinerario>>().Result;

        //    ViewBag.ClientesListItems = clientes.ToList();
        //    ViewBag.ItinerariosListItems = itinerarios.ToList();

        //    if (id == 0)
        //    {
        //        var orden_entrega = new OrdenEntrega();
        //        return View(orden_entrega);
        //    }
        //    {
        //        HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("OrdenEntregas/" + id.ToString()).Result;
        //        return View(response.Content.ReadAsAsync<OrdenEntrega>().Result);
        //    }
        //}

        //[HttpPost]
        //public ActionResult AddorEdit(OrdenEntrega ordenEntrega)
        //{
        //    if (ordenEntrega.Id == 0)
        //    {
        //        HttpResponseMessage response = ConnectionHelper.WebApiClient.PostAsJsonAsync("OrdenEntregas", ordenEntrega).Result;
        //        TempData["SuccessMessage"] = "Saved Successfully";
        //    }
        //    else
        //    {
        //        HttpResponseMessage response = ConnectionHelper.WebApiClient.PutAsJsonAsync("OrdenEntregas/" + ordenEntrega.Id, ordenEntrega).Result;
        //        TempData["SuccessMessage"] = "Updated Successfully";
        //    }

        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public ActionResult Delete(int? id)
        //{
        //    OrdenEntrega registro = new OrdenEntrega();
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("OrdenEntregas/" + id.ToString()).Result;
        //    registro = response.Content.ReadAsAsync<OrdenEntrega>().Result;
        //    return View(registro);


        //}

        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    if (id == 0)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HttpResponseMessage response = ConnectionHelper.WebApiClient.DeleteAsync("OrdenEntregas/" + id.ToString()).Result;
        //    TempData["SuccessMessage"] = "Deleted Successfully";
        //    return RedirectToAction("Index");
        //}


        //// GET: OrdenesEntrega/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

     
    }
}
