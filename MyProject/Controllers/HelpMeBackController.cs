using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
namespace MyProject.Controllers
{
    public class HelpMeBackController : Controller
    {
        private DBJ_DBEntities db = new DBJ_DBEntities();
        //private PredatabaseEntities db = new PredatabaseEntities();
        // GET: HelpMeBack
        public ActionResult Back()
        {
            return View();
        }

        public ActionResult L1() //ไหลซ้าย
        {
            string test = Request.Form["muscle"];

            int i = 10;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult L2() //ข้อศอกซ้าย
        {
            string test = Request.Form["muscle"];

            int i = 12;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult L3()//ข้อพับหัวเข่าซ้าย
        {
            string test = Request.Form["muscle"];

            int i = 16;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult L4()//น่องซ้าย
        {
            string test = Request.Form["muscle"];

            int i = 18;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult L5()//เท้าหลัง
        {
            string test = Request.Form["muscle"];

            int i = 20;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult R1()//ไหลขวา
        {
            string test = Request.Form["muscle"];

            int i = 11;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult R2()//ข้อศอกขวา
        {
            string test = Request.Form["muscle"];

            int i = 13;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult R3()//ข้อพับขวา
        {
            string test = Request.Form["muscle"];

            int i = 17;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult R4()//น่องขวา
        {
            string test = Request.Form["muscle"];

            int i = 19;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult R5()//ข้อเท้าหลังขวา
        {
            string test = Request.Form["muscle"];

            int i = 21;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult C1()//ต้นคอ
        {
            string test = Request.Form["muscle"];

            int i = 9;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }


        public ActionResult C2()//หลังส่วนล่าง
        {
            string test = Request.Form["muscle"];

            int i = 14;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }


        public ActionResult C3()//สะโพก
        {
            string test = Request.Form["muscle"];

            int i = 15;



            if (test != null)
            {
                return RedirectToAction("Suggest", "HelpMeBack", new { test });
            }

            var check_Muscle = db.MuscleTables.Where(a => a.ID_Muscle == i).FirstOrDefault<MuscleTable>();

            var _cause = check_Muscle.CauseTables.ToList();

            return View(_cause.ToList());
        }

        public ActionResult suggest(int test)
        {
            if (test == 0)
            {

                return RedirectToAction("Ghost", "HelpMeBack");
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