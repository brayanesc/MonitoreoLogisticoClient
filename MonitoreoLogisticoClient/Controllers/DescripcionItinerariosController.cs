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
    public class DescripcionItinerariosController : Controller
    {
        // GET: DescripcionItinerarios
        public ActionResult Index()
        {
            IEnumerable<DetalleItinerario> empList;
            HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("DetalleItinerarios").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<DetalleItinerario>>().Result;
            return View(empList);
        }


        [HttpGet]
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new DetalleItinerario());
            }
            {
                HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("DetalleItinerarios/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<DetalleItinerario>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(DetalleItinerario detalle)
        {
            if (detalle.Id == 0)
            {
                HttpResponseMessage response = ConnectionHelper.WebApiClient.PostAsJsonAsync("DetalleItinerarios", detalle).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = ConnectionHelper.WebApiClient.PutAsJsonAsync("DetalleItinerarios/" + detalle.Id, detalle).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            DetalleItinerario registro = new DetalleItinerario();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("DetalleItinerarios/" + id.ToString()).Result;
            registro = response.Content.ReadAsAsync<DetalleItinerario>().Result;
            return View(registro);


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = ConnectionHelper.WebApiClient.DeleteAsync("DetalleItinerarios/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        // GET: DescripcionItinerarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        //// GET: DescripcionItinerarios/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DescripcionItinerarios/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DescripcionItinerarios/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DescripcionItinerarios/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DescripcionItinerarios/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DescripcionItinerarios/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
