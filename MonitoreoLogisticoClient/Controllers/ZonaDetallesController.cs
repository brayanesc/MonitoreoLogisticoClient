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
    public class ZonaDetallesController : Controller
    {
        // GET: ZonaDetalles
        public ActionResult Index()
        {
            IEnumerable<ZonaDetalle> empList;
            HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("ZonaDetalles").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<ZonaDetalle>>().Result;
            return View(empList);
        }


        [HttpGet]
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ZonaDetalle());
            }
            {
                HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("ZonaDetalles/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ZonaDetalle>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(ZonaDetalle zona_det)
        {
            if (zona_det.Id == 0)
            {
                HttpResponseMessage response = ConnectionHelper.WebApiClient.PostAsJsonAsync("ZonaDetalles", zona_det).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = ConnectionHelper.WebApiClient.PutAsJsonAsync("ZonaDetalles/" + zona_det.Id, zona_det).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ZonaDetalle registro = new ZonaDetalle();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = ConnectionHelper.WebApiClient.GetAsync("ZonaDetalles/" + id.ToString()).Result;
            registro = response.Content.ReadAsAsync<ZonaDetalle>().Result;
            return View(registro);


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = ConnectionHelper.WebApiClient.DeleteAsync("ZonaDetalles/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }



        // GET: ZonaDetalles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //// GET: ZonaDetalles/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ZonaDetalles/Create
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

        //// GET: ZonaDetalles/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ZonaDetalles/Edit/5
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

        //// GET: ZonaDetalles/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ZonaDetalles/Delete/5
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
