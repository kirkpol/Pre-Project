using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using System.Data.Entity.Validation;

namespace MyProject.Controllers
{
    public class PMHController : Controller
    {
        private AzurePredatabaseEntities db = new AzurePredatabaseEntities();
        //private PredatabaseEntities db = new PredatabaseEntities();
        // GET: PMH
        public ActionResult PMH_Show()
        {
            var email = this.Session["Email"];
            string email_convert = Convert.ToString(email);

            var check = db.Medical_history.Where(a => a.Email.Equals(email_convert)).ToList();

            return View(check.ToList());
        }

        public ActionResult PMH_Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PMH_Create(Medical_history MH)
        {

            var email = this.Session["email"];
            string email_convert = Convert.ToString(email);

            string Symtpomatic = Request.Form["Symtpomatic"];
            string PMH = Request.Form["PMH"];


            if (ModelState.IsValid)
            {
                var check = db.Profiles.Find(email);

                if (check.Email != null)
                {
                    MH.Email = check.Email;
                    try
                    {

                        db.Medical_history.SqlQuery("insert into Medical_history(Symtpomatic,PMH) values (,'Symtpomatic','PMH') ");
                        db.Medical_history.Add(MH);
                        db.SaveChanges();


                    }
                    catch (DbEntityValidationException ex)
                    {
                        var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                        var fullErrorMessage = string.Join("; ", errorMessages);
                        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                    }
                }
               
            }
            return RedirectToAction("PMH_Create", "PMH");
        }

        public ActionResult PMHDetail(int? id )
        {

            Medical_history PHM = db.Medical_history.Find(id);
            if (PHM == null)
            {
                return HttpNotFound();
            }
            return View(PHM);
        }
    }
}
