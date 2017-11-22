using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class ForgetpasswordController : Controller
    {
        //private AzurePredatabaseEntities db = new AzurePredatabaseEntities();
        private PredatabaseEntities db = new PredatabaseEntities();
        // GET: Forgetpassword
        public ActionResult EmailPage()
        {
            string email_FG = Request.Form["email"];
            var check = db.Profiles.Where(b => b.Email.Equals(email_FG)).FirstOrDefault<Profile>();
            if(check != null)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                check.Password = finalString;
                db.SaveChanges();
                using (MailMessage mm = new MailMessage("elearning.dpu@gmail.com", check.Email))
                {
                    mm.Subject = "Reset Password";
                    
                    mm.Body = "รหัสผ่านใหม่ของคุณคือ : " + check.Password;


                    mm.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("elearning.dpu@gmail.com", "dearbenzjj");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);

                    }
                }
                return RedirectToAction("NextStep", "Forgetpassword");
            }

            return View();
          
        }

        public ActionResult NextStep()
        {
            return View();
        }
    }
}