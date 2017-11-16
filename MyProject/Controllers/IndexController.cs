using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyProject.Controllers
{
    public class IndexController : Controller
    {
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