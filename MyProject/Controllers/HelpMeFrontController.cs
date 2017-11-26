using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
namespace MyProject.Controllers
{
    public class HelpMeFrontController : Controller
    {
        private DBJ_DBEntities db = new DBJ_DBEntities();
        //private PredatabaseEntities db = new PredatabaseEntities();
        // GET: HelpMeFront
        public ActionResult Front()
        {
            return View();
        }

        public ActionResult L1()
        {

            string test = Request.Form["muscle"];

            int i = 1;
            
            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeFront", new { test });
            }
            


            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());

            
        }

        public ActionResult L2()
        {
            string test = Request.Form["muscle"];

            int i = 3;

           

            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeFront", new { test });
            } 

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult L3()
        {
            string test = Request.Form["muscle"];

            int i = 5;

            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeFront", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult L4()
        {
            string test = Request.Form["muscle"];

            int i = 7;

            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeFront", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult R1()
        {
            string test = Request.Form["muscle"];

            int i = 2;

            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeFront", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult R2()
        {
            string test = Request.Form["muscle"];

            int i = 4;

            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeFront", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult R3()
        {
            string test = Request.Form["muscle"];

            int i = 6;

            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeFront", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult R4()
        {
            string test = Request.Form["muscle"];

            int i = 8;

            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeFront", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult suggest(int test)
        {
            if(test == 0)
            {
               
                return RedirectToAction("Ghost","HelpMeFront");
            }
            var check = db.CauseTables.Find(test);

            int keep = check.ID_Cause;

            var _check = db.SuggestTables.Where(a => a.ID_Cause == keep).FirstOrDefault<SuggestTable>();
            //var _check = check.SuggestTables.Where(a => a.CauseTables.Equals(keep)).FirstOrDefault();





            return View(_check);
            
        }
        public ActionResult Ghost()
        {
            ViewBag.Error = "ok";
            return View();
        }
    }
}