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
    public class RegistorController : Controller
    {
        private AzurePredatabaseEntities db = new AzurePredatabaseEntities();
        //private PredatabaseEntities db = new PredatabaseEntities();
        // GET: Registor

        public ActionResult Registor()
        {
            return View();
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registor(Profile profile)
        {

            string Email_registor = Request.Form["email"];
            string Password_registor = Request.Form["Password"];
            string Password_Comfirm_registor = Request.Form["password_two"];
            string First_registor = Request.Form["firstname"];
            string Lastname_registor = Request.Form["lastname"];
            //string Birthday_registor = Request.Form["birthday"];
            DateTime Birthday_registor =  Convert.ToDateTime(Request.Form["birthday"]);
            string Sex_registor = Request.Form["sex"];
            string Contact_registor = Request.Form["Contact"];
          


            if (ModelState.IsValid)
            {
                if (Email_registor != null)
                {
                    var check_profile = db.Profiles.Where(a => a.Email.Equals(Email_registor)).FirstOrDefault<Profile>();
                    if (check_profile != null)
                    {
                        ViewBag.Message = "มีชื่อผู้ใช้นี้อยู่แล้ว";
                        return View();
                    }
                    else
                    {
                        try
                        {


                            db.Profiles.SqlQuery("insert into Profile(Email,Password,Firstname,Lastname,Birthday,Sex,Contact) values ('Email_registor','Password_registor','First_registor','Lastname_registor','Birthday_registor','Sex_registor','Contact_registor')");
                            db.Profiles.Add(profile);
                            db.SaveChanges();


                        
                            var GT_login = db.Profiles.Where(a => a.Email.Equals(Email_registor) && a.Password.Equals(Password_registor)).FirstOrDefault(); 
                            DateTime now = DateTime.Now;
                            int age = now.Year - GT_login.Birthday.Year;
                            string Age_convert = age.ToString();
                            //DateTime dt = DateTime.ParseExact(GT_login.Birthday.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                            string s = GT_login.Birthday.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                            /*if (GT_login.Sex != null)
                            {
                                string sex_new;
                                if (GT_login.Sex == "M")
                                {
                                    sex_new = "ชาย";
                                    Session["Sex"] = sex_new;
                                }
                                else if (GT_login.Sex == "F")
                                {
                                    sex_new = "หญิง";
                                    Session["Sex"] = sex_new;
                                }

                            }*/
                            
                            Session["Email"] = GT_login.Email;
                            Session["Password"] = GT_login.Password;
                            Session["Firstname"] = GT_login.Firstname;
                            Session["Lastname"] = GT_login.Lastname;
                            Session["Birthday"] = s;

                            Session["Congenital"] = GT_login.Congenital_disease;
                            Session["Age"] = Age_convert;
                            Session["Contact"] = GT_login.Contact;

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

            }

            return RedirectToAction("Index", "Index");

        }

      
    }


}
    
