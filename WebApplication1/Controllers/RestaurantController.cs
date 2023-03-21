using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.EF;

namespace WebApplication1.Controllers
{
    public class RestaurantController : Controller
    {
        public ZeroHungerEntities db = new ZeroHungerEntities();

        
        public ActionResult Index()
        {
            return View(db.Restaurant_Table.ToList());
        }

       
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant_Table rt = db.Restaurant_Table.Find(id);
            if (rt == null)
            {
                return HttpNotFound();
            }
            return View(rt);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Restaurant_ID,Restaurant_Name,Address,Contact")] Restaurant_Table rt)
        {
            if (ModelState.IsValid)
            {
                db.Restaurant_Table.Add(rt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rt);
        }

        
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant_Table rt = db.Restaurant_Table.Find(id);
            if (rt == null)
            {
                return HttpNotFound();
            }
            return View(rt);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Restaurant_ID,Restaurant_Name,Address,Contact")] Restaurant_Table rt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rt);
        }

        
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant_Table rt = db.Restaurant_Table.Find(id);
            if (rt == null)
            {
                return HttpNotFound();
            }
            return View(rt);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Restaurant_Table restaurant_Table = db.Restaurant_Table.Find(id);
            db.Restaurant_Table.Remove(restaurant_Table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
