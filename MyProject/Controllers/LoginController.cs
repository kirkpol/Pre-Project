using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using System.Web.Security;
using System.Data.Entity.Validation;
using System.Globalization;

namespace MyProject.Controllers
{
    public class LoginController : Controller
    {
        private PredatabaseEntities db = new PredatabaseEntities();


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Profile profile)
        {

            string Email_login = Request.Form["email"];
            string Password_login = Request.Form["password"];

            if (ModelState.IsValid)
            {
                if (Email_login != null & Password_login != null)
                {
                    var check = db.Profiles.Where(a => a.Email.Equals(Email_login) && a.Password.Equals(Password_login)).FirstOrDefault();

                    if (check != null)
                    {

                        DateTime now = DateTime.Now;
                        int age = now.Year - check.Birthday.Year;


                        /* var Cookie_Email = new HttpCookie("C_Email");
                         Cookie_Email.Value = check.Email;
                         Response.Cookies.Add(Cookie_Email);

                         var Cookie_Password = new HttpCookie("C_Password");
                         Cookie_Password.Value = check.Password;
                         Response.Cookies+		this	{MyProject.Controllers.LoginController}	MyProject.Controllers.LoginController
.Add(Cookie_Password);

                         var Cookie_Firstname = new HttpCookie("C_Firstname");
                         Cookie_Firstname.Value = check.Firstname;
                         Response.Cookies.Add(Cookie_Firstname);

                         var Cookie_Lastname = new HttpCookie("C_Lastname");
                         Cookie_Lastname.Value = check.Lastname;
                         Response.Cookies.Add(Cookie_Lastname);


                         
                         var Cookie_Birthday = new HttpCookie("C_Birthday");
                         Cookie_Birthday.Value = s;
                         Response.Cookies.Add(Cookie_Birthday);




                         var Cookie_Age = new HttpCookie("C_Age");
                         Cookie_Age.Value = Age_convert;
                         Response.Cookies.Add(Cookie_Age);

                         var Cookie_Sex = new HttpCookie("C_Sex");
                         Cookie_Sex.Value = check.Sex;
                         Response.Cookies.Add(Cookie_Sex);

                         var Cookie_Contact = new HttpCookie("C_Contact");
                         Cookie_Contact.Value = check.Contact;
                         Response.Cookies.Add(Cookie_Contact);
                         */
                        string Age_convert = age.ToString();
                        DateTime dt = DateTime.ParseExact(check.Birthday.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                        string s = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                        /*if (check.Sex != null)
                        {
                            string sex_new;
                            if (check.Sex == "M")
                            {
                                sex_new = "ชาย";
                                Session["Sex"] = sex_new;
                            }
                            else if (check.Sex == "F")
                            {
                                sex_new = "หญิง";
                                Session["Sex"] = sex_new;
                            }

                        }*/
                        
                        Session["Email"] = check.Email;
                        Session["Password"] = check.Password;
                        Session["Firstname"] = check.Firstname;
                        Session["Lastname"] = check.Lastname;
                        Session["Birthday"] = check.Birthday;
                        Session["Congenital"] = check.Congenital_disease;
                        Session["Age"] = Age_convert;
                        Session["Contact"] = check.Contact;

                        

                    }
                    else
                    {
                        ViewBag.Message = "อีเมลล์หรือรหัสผ่านไม่ถูกต้อง";
                        return View();
                    }
                }

            }

            return RedirectToAction("Index", "Index");

        }
    }
}

