using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace WebApplication1.Controllers
{
    
    public class CastController : Controller
    {
        private Context db = new Context();

        
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ModelSortParm = sortOrder == "model_asc" ? "model_desc" : "model_asc";
            ViewBag.DateSortParm = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var vehicles = from s in db.Vehicles
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(s => s.Model.Contains(searchString)
                                       || s.Brand.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Model);
                    break;
                case "model_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Brand);
                    break;
                case "model_asc":
                    vehicles = vehicles.OrderBy(s => s.Brand);
                    break;
                case "date_asc":
                    vehicles = vehicles.OrderBy(s => s.Year);
                    break;
                case "date_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Year);
                    break;
                default:
                    vehicles = vehicles.OrderBy(s => s.Model);
                    break;
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(vehicles.ToPagedList(pageNumber, pageSize));
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Model,Brand,Year,Color,Mileage,Description,Url")] Vehicle vehicle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Vehicles.Add(vehicle);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(vehicle);
        }

        
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleToUpdate = db.Vehicles.Find(id);
            if (TryUpdateModel(vehicleToUpdate, "",
               new string[] { "Model", "Brand", "Year", "Color", "Mileage", "Description", "Url" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(vehicleToUpdate);
        }

        
        [Authorize]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Vehicle vehicle = db.Vehicles.Find(id);
                db.Vehicles.Remove(vehicle);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
