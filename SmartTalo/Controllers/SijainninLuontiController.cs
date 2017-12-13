using AssetManagementWeb.Utilities;
using Newtonsoft.Json;
using SmartTalo.Database;
using SmartTalo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartTalo.Controllers
{
    public class SijainninLuontiController : Controller
    {
        // GET: SijainninLuonti
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sijainti()
        {
            return View();
        }
        // GET: SijainninLuonti/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SijainninLuonti/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SijainninLuonti()
     
        {
            string json = Request.InputStream.ReadToEnd();
            SijainninLuontiModel inputData = JsonConvert.DeserializeObject<SijainninLuontiModel>(json);
            bool success = false;
            string error = "";

            SmartHouseEntities entities = new SmartHouseEntities();
            try
            {

                string koodi = inputData.Koodi;

                string nimi = inputData.Nimi;

                string osoite = inputData.Osoite;
               
                {
                    //( tallennetaan uusi rivi kantaan
                    Sijainti newEntry = new Sijainti();
                    newEntry.Koodi = koodi;
                    newEntry.Nimi = nimi;
                    newEntry.Osoite = osoite;
                  
                    entities.Sijainti.Add(newEntry);
                    entities.SaveChanges();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.GetType().Name + ": " + ex.Message;


            }

            finally
            {
                entities.Dispose();
            }

            // palautetn JSON-muotoinen tulos kutsujalle.
            var result = new { success = success, error = error };
            return Json(result);

        }
        // POST: SijainninLuonti/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SijainninLuonti/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SijainninLuonti/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SijainninLuonti/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SijainninLuonti/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
