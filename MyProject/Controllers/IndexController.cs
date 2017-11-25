using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyProject.Models;

namespace MyProject.Controllers
{
    

    public class IndexController : Controller
    {
        private DBJ_DBEntities db = new DBJ_DBEntities();
        //private PredatabaseEntities db = new PredatabaseEntities();
        // GET: Index


        public ActionResult Index()
        {
            return View();

        }


        
        public ActionResult Logout()
        {

            if (HttpContext.Session == null)
            {
                return RedirectToAction("Index", "Index");
            }
            else if (HttpContext.Session != null)
            {
                FormsAuthentication.SignOut();
                HttpContext.Session.Abandon();    
            }
            return RedirectToAction("Index", "Index");

        }

        public ActionResult Anatomy()
        {
            int i = 1;
            var check_Muscle = db.MuscleTables.Find(i);
            if(check_Muscle != null)
            {
                var check_cause = db.CauseTables.Where(a=>a.ID_Muscle.Equals(check_Muscle)).ToList();

                return View();
            }
            return View();
        }

        public ActionResult Suggest()
        {
            return View();
        }

        public ActionResult Hospital()
        {
            return View();
        }


        public ActionResult test()
        {
            return View();
        }

    }
}