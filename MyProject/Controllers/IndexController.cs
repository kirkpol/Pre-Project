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

            string test = Request.Form["muscle"];
           
            int i = 1;

            if (test != null )
            {
                return RedirectToAction("Suggest", "Index", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();


            

            
            
            return View(_cause.ToList());


        }

        public ActionResult Suggest(int test)
        {
            var check = db.CauseTables.Find(test);

            int keep = check.ID_Cause;

            var _check = db.SuggestTables.Where(a => a.ID_Cause == keep).FirstOrDefault<SuggestTable>();
            //var _check = check.SuggestTables.Where(a => a.CauseTables.Equals(keep)).FirstOrDefault();


           


            return View(_check);
        }

        public ActionResult Hospital()
        {
            return View();
        }


        public ActionResult test()
        {
            return View();
        }

        public ActionResult test2()
        {
            return View();
        }

    }
}