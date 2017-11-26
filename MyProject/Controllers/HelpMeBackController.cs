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
            return View();
        }

        public ActionResult L2() //ข้อศอกซ้าย
        {
            return View();
        }

        public ActionResult L3()//ข้อพับหัวเข่าซ้าย
        {
            return View();
        }

        public ActionResult L4()//น่องซ้าย
        {
            return View();
        }

        public ActionResult L5()//เท้าหลัง
        {
            return View();
        }

        public ActionResult R1()//ไหลขวา
        {
            return View();
        }

        public ActionResult R2()//ข้อศอกซ้าย
        {
            return View();
        }

        public ActionResult R3()//น่องซ้าย
        {
            return View();
        }

        public ActionResult R4()//เท้าหลัง
        {
            return View();
        }

        public ActionResult R5()//เท้าหลัง
        {
            return View();
        }

        public ActionResult C1()//ต้นคอ
        {
            return View();
        }


        public ActionResult C2()//หลังส่วนล่าง
        {
            return View();
        }


        public ActionResult C3()//สะโพก
        {
            return View();
        }

        public ActionResult suggest(int test)
        {
            if (test == 0)
            {

                return RedirectToAction("Ghost", "HelpMeFront");
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