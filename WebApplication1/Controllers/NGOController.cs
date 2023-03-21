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
    public class NGOController : Controller
    {
        public ZeroHungerEntities db = new ZeroHungerEntities();

        
        public ActionResult CollectRequest()
        {
            return View(db.Restaurant_Table.ToList());
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
            return RedirectToAction("CollectRequest");
        }

    }
}