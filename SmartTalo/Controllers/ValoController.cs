using Newtonsoft.Json;
using SmartTalo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartTalo.Database;
using AssetManagementWeb.Utilities;

namespace SmartTalo.Controllers
{
    public class ValoController : Controller
    {
        // GET: Valo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

        // GET: Valo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Valo/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AsetaValoTaloon()
        {
            string json = Request.InputStream.ReadToEnd();
            ValoTaloonModel inputData = JsonConvert.DeserializeObject<ValoTaloonModel>(json);
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
                int valoKoodi = (from v in entities.Valo
                                     where v.Koodi == inputData.ValoKoodi
                                     select v.Id).FirstOrDefault();

                if ((sijaintiKoodi > 0) && (valoKoodi >0))

                {
                    //( tallennetaan uusi rivi kantaan

                    Talo newEntry = new Talo();
                    newEntry.SijaintiId = sijaintiKoodi;
                    newEntry.ValoId = valoKoodi;

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

        // POST: Valo/Create
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

        // GET: Valo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Valo/Edit/5
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

        // GET: Valo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Valo/Delete/5
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
