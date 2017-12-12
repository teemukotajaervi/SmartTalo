using AssetManagementWeb.Utilities;
using Newtonsoft.Json;
using SmartTalo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartTalo.Models
{
    public class SaunanLuontiController : Controller
    {
        // GET: SaunanLuonti
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

        // GET: SaunanLuonti/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaunanLuonti/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaunanLuonti()
        {
            string json = Request.InputStream.ReadToEnd();
            SaunanLuontiModel inputData = JsonConvert.DeserializeObject<SaunanLuontiModel>(json);
            bool success = false;
            string error = "";

            SmartHouseEntities entities = new SmartHouseEntities();
            try
            {
              
                string koodi = inputData.Koodi;
              
                string tyyppi = inputData.Tyyppi;

                string tila = inputData.Tila;

                int lampotila = inputData.Lampotila;


                {
                    //( tallennetaan uusi rivi kantaan

                    Sauna newEntry = new Sauna();
                    newEntry.Koodi = koodi;
                    newEntry.Tyyppi = tyyppi;
                    newEntry.Tila = tila;
                    newEntry.Lampotila = lampotila;

                    entities.Sauna.Add(newEntry);
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

        // POST: SaunanLuonti/Create
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

        // GET: SaunanLuonti/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaunanLuonti/Edit/5
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

        // GET: SaunanLuonti/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaunanLuonti/Delete/5
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
