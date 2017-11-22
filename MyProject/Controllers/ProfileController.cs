using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using System.Data.Entity.Validation;
using System.Globalization;

namespace MyProject.Controllers
{
    public class ProfileController : Controller
    {
        //private AzurePredatabaseEntities db = new AzurePredatabaseEntities();
        private PredatabaseEntities db = new PredatabaseEntities();
        // GET: Profile
        [HttpGet]
        public ActionResult Show(int? id)
        {
            var email = this.Session["Email"];

            Profile profile = db.Profiles.Find(email);
            if (profile == null)
            {
                return HttpNotFound();
            }
            if (id == 1)
            {
                ViewBag.ok = "OK";
                return View(profile);
            }
            return View(profile);
            //return View();
        }



        public ActionResult Edit()
        {
            var email = this.Session["Email"];

            Profile profile = db.Profiles.Find(email);
            if (profile == null)
            {
                return HttpNotFound();
            }

            string Email_update = Request.Form["Email_update"];
            string First_update = Request.Form["Firstname_update"];
            string Lastname_update = Request.Form["Lastname_update"];
            string Contact_update = Request.Form["Contact_update"];
            string Congenital_update = Request.Form["Congenital"];
            string Birthday_update = Request.Form["Birthday_update"];
            //DateTime Birthday_update = (Request.Form["birthday"]);


            if (ModelState.IsValid)
            {
                if (Email_update != null)
                {
                    var check_edit = db.Profiles.Where(a => a.Email.Equals(Email_update)).FirstOrDefault();

                    DateTime result;
                    if (!DateTime.TryParse(Birthday_update,out result))
                    {
                        result = DateTime.ParseExact(Birthday_update, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        
                    }

                    
                    
                  
                    //DateTime date = DateTime.ParseExact(Birthday_update, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    check_edit.Firstname = First_update;
                    check_edit.Lastname = Lastname_update;
                    check_edit.Contact = Contact_update;
                    check_edit.Congenital_disease = Congenital_update;
                    check_edit.Birthday = result;
                 



                    try
                    {


                        db.SaveChanges();


                        Session["Firstname"] = check_edit.Firstname;
                        Session["Lastname"] = check_edit.Lastname;
                        Session["Contact"] = check_edit.Contact;
                        Session["Congenital"] = check_edit.Congenital_disease;
                        ViewBag.ok = "OK";
                        return RedirectToAction("Show", "Profile", new { id = 1 });                      
                        //return View();
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
            return View(profile);
        }




        public ActionResult changpassword(Profile profile)
        {

            string Email = Request.Form["Email_update"];
            string Password = Request.Form["Password"];
            string Password_new = Request.Form["Password_new"];
            string Comfirm_new = Request.Form["Comfirm_new"];

            if (Password != null)
            {
                var check = db.Profiles.Where(b => b.Email.Equals(Email)).FirstOrDefault<Profile>();

                if (check.Password == Password)
                {
                    if (Password_new == Comfirm_new)
                    {
                        check.Password = Password_new;
                        db.SaveChanges();
                        ViewBag.ok = "OK";
                        //return JavaScript(alert("Hello this is an alert"));
                        // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");

                    }
                    else
                    {
                        ViewBag.Error2 = "รหัสผ่านไม่ตรงกัน";
                    }
                }
                else
                {
                    ViewBag.Error1 = "รหัสผ่านไม่ถูกต้อง";
                }

            }


            return View();
        }


    }
}