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
    public class ValonLuontiController : Controller
    {
        // GET: ValonLuonti
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

        // GET: ValonLuonti/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ValonLuonti/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public JsonResult ValonLuonti()
        {
            string json = Request.InputStream.ReadToEnd();
            ValonLuontiModel inputData = JsonConvert.DeserializeObject<ValonLuontiModel>(json);
            bool success = false;
            string error = "";

            SmartHouseEntities entities = new SmartHouseEntities();
            try
            {
                //haetaan sijainti id koodin perusteella.
                string koodi = inputData.Koodi;

                //haetaan sijainti id koodin perusteella.
                string tyyppi = inputData.Tyyppi;

                string tila = inputData.Tila;

                int valonmaara = inputData.Valonmaara;
               

                {
                    //( tallennetaan uusi rivi kantaan

                    Valo newEntry = new Valo();
                    newEntry.Koodi = koodi;
                    newEntry.Tyyppi = tyyppi;
                    newEntry.Tila = tila;
                    newEntry.Valonmaara = valonmaara;



                    entities.Valo.Add(newEntry);
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

        // POST: ValonLuonti/Create
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

        // GET: ValonLuonti/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ValonLuonti/Edit/5
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

        // GET: ValonLuonti/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ValonLuonti/Delete/5
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
