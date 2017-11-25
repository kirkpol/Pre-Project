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
            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();
            
            return View(_cause.ToList());


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