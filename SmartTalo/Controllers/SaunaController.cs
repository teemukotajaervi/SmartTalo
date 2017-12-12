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
    public class SaunaController : Controller
    {
        // GET: Sauna
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

        // GET: Sauna/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sauna/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AsetaSaunaTaloon()
        {
            string json = Request.InputStream.ReadToEnd();
            SaunaTaloonModel inputData = JsonConvert.DeserializeObject<SaunaTaloonModel>(json);
            bool success = false;
            string error = "";

            SmartHouseEntities entities = new SmartHouseEntities();

            try
            {
                //haetaan sijainti id koodin perusteella.
                int sijaintiKoodi = (from s in entities.Sijainti
                                     where s.Koodi == inputData.SijaintiKoodi
                                     select s.Id).FirstOrDefault();

                //haetaan sijainti id koodin perusteella.
                int saunaKoodi = (from s in entities.Sauna
                                  where s.Koodi == inputData.SaunaKoodi
                                  select s.Id).FirstOrDefault();

                if ((sijaintiKoodi > 0) && (saunaKoodi > 0))
                {
                    //( tallennetaan uusi rivi kantaan

                    Talo newEntry = new Talo();
                    newEntry.SijaintiId = sijaintiKoodi;
                    newEntry.SaunaId = saunaKoodi;
                    newEntry.AsetusPaiva = DateTime.Now;
                    entities.Talo.Add(newEntry);
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

        // POST: Sauna/Create
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

        // GET: Sauna/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sauna/Edit/5
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

        // GET: Sauna/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sauna/Delete/5
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
