using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class PMHController : Controller
    {
        private PredatabaseEntities db = new PredatabaseEntities();
        // GET: PMH
        public ActionResult PMH_Show()
        {

            return View();
        }

        public ActionResult PMH_Create()
        {
            return View();
        }
    }
}