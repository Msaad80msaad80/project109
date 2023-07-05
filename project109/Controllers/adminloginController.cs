using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using System.Data.Entity;
using System.Reflection;
using System.Configuration;
using System.Data.SqlClient;
using project109.Models;

namespace project109.Controllers
{
    public class adminloginController : Controller
    {
        private msaadtestEntities db = new msaadtestEntities();
        EncryptionHelper enchlpr = new EncryptionHelper();
        // GET: adminlogin
        public ActionResult Index()
        {
            //if (Request.Cookies["loginCookie1"] != null && Request.Cookies["loginCookie2"] != null)
            //{
            //    return RedirectToAction("Details", "UsersAdmins", new { GID = Request.Cookies["loginCookie1"].Value });
            //}
            return PartialView();
        }
        [HttpPost]
       
        public ActionResult Index(string txtusrnm2, string txtpswrd2)
        {
           
            string encpass = enchlpr.Encrypt(txtpswrd2);
            var x = db.UsersAdmins.Where(a => a.Username == txtusrnm2 && a.Password == encpass).FirstOrDefault();
            if (x != null)
            {

                if (Request["chkrem2"] == "on")
                {
                    HttpCookie loginCookie3 = new HttpCookie("loginCookie3");
                    loginCookie3.Value = txtusrnm2;
                    loginCookie3.Expires = DateTime.Now.AddDays(50);
                    Response.SetCookie(loginCookie3);

                    HttpCookie loginCookie4 = new HttpCookie("loginCookie4");
                    loginCookie4.Value = txtpswrd2;
                    loginCookie4.Expires = DateTime.Now.AddDays(50);
                    Response.SetCookie(loginCookie4);
                }
                Session["isAdmin"] = x.IsAdmin; Session["adminid"] = x.Id; Session["adminname"] = x.RealName;
                ViewBag.succ = Session["adminname"];
                ViewBag.fail = "";
                //return PartialView();
                // return RedirectToAction("fogetpass1", "adminlogin", new { Id = x.Id });
            }
            else
            {
                //return RedirectToAction("Index", "adminlogin", new { loginfail2 = "loginfail" });
                //return RedirectToAction("Index", "Home", new { loginfail2 = "loginfail" });
                //ViewBag.succ = "";
                ViewBag.fail = "loginfail";

            }
            return PartialView();
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            ViewBag.succ = "";
            ViewBag.fail = "";
            // return PartialView();
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult fogetpass1()
        {
            //***********
            // MailMessage msgMail = new MailMessage();
            // MailMessage myMessage = new MailMessage();
            // myMessage.From = new MailAddress("tendersalert@amcham.org.eg", "TAS - comment");
            // myMessage.To.Add("msaad@amcham.org.eg");
            //// myMessage.Bcc.Add("msaad@amcham.org.eg");

            // myMessage.IsBodyHtml = true;
            // string Body = "", link = "";


            // Body = "msmsmmemcdk";
            // myMessage.Subject = "TAS comment";

            // myMessage.Body = Body;
            // SmtpClient mySmtpClient = new SmtpClient();

            // mySmtpClient.Host = "mail.amcham.org.eg";
            // mySmtpClient.UseDefaultCredentials = false;
            // mySmtpClient.ServicePoint.MaxIdleTime = 1;
            // mySmtpClient.Send(myMessage);
            // myMessage.Dispose();



            return View();
        }
        [HttpPost]
        public ActionResult fogetpass1(string txtmailchk)
        {
            var x = db.UsersAdmins.Where(a => a.Email == txtmailchk && a.Active == true).FirstOrDefault();
            if (x != null)
            {
                string SiteUrl = HttpContext.Application["SiteUrl"].ToString(); string SiteUrl2 = HttpContext.Application["SiteUrl2"].ToString(); string SiteMail = HttpContext.Application["SiteMail"].ToString(); string SiteMailPassword = HttpContext.Application["SiteMailPassword"].ToString();
                var fromAddress = new MailAddress(SiteMail, "American Chamber");
                var toAddress = new MailAddress(txtmailchk, x.RealName);

                string fromPassword = SiteMailPassword;
                //const string subject = "Your Password Recovery";
                string body = "";
                body = body + "<table border=1 align=center cellpadding=0 cellspacing=0>  <tr> ";
                body = body + "<td align=center nowrap=nowrap>&nbsp;<img src=" + SiteUrl2 + "assets/images/logos/amcham_logo.png></td>  </tr><tr> ";
                body = body + "<td align=left nowrap=nowrap>To Change Password</td>  </tr>  <tr>";
                body = body + "<td nowrap=nowrap align=left><a href="+ SiteUrl + "adminlogin/fogetpass2?resid=" + enchlpr.Encrypt(x.Username) + x.Id + "&newres=" + enchlpr.Encrypt("" + x.Id) + " target=_blank>Click Here</a></td></tr> ";
                body = body + "</table>";
                //body = "<pre>" + HttpUtility.HtmlEncode(body) + "</pre>";
                //var smtp = new SmtpClient
                //{
                //    Host = "smtp.gmail.com",
                //    Port = 587,
                //    EnableSsl = true,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = false,
                //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                //};
                //using (var message = new MailMessage(fromAddress, toAddress)
                //{
                //    Subject = subject,
                //    Body = body

                //})

                //{
                //    message.IsBodyHtml = true;
                //    smtp.Send(message);
                //}



                MailMessage msgMail = new MailMessage();
                MailMessage myMessage = new MailMessage();

                // myMessage.From = new MailAddress(MailFrom, MailDisplayName);
                myMessage.From = new MailAddress(SiteMail, "AmCham TAS");

                myMessage.To.Add(toAddress);
                myMessage.To.Add("msaad@amcham.org.eg");
                myMessage.IsBodyHtml = true;
               
               
              
               myMessage.Subject = "Your Password Recovery";
                myMessage.Body = body;
                SmtpClient mySmtpClient = new SmtpClient();

                mySmtpClient.Host = "mail.amcham.org.eg";
                mySmtpClient.UseDefaultCredentials = false;
                try
                {
                    mySmtpClient.ServicePoint.MaxIdleTime = 1;
                    mySmtpClient.Send(myMessage);
                    myMessage.Dispose();

                }
                catch { }




                return RedirectToAction("Waitforsend");
            }
            else
            {
                return RedirectToAction("fogetpass1", new { s = "no" });
            }
        }
        public ActionResult Waitforsend()
        {

            return View();
        }
        public ActionResult fogetpass2(string newres)
        {
            int newsres2 = Convert.ToUInt16(enchlpr.Decrypt(newres));
            var x = db.UsersAdmins.Where(a => a.Id == newsres2).FirstOrDefault();
            if (x != null)
            {
                ViewBag.hid = newsres2;
            }
            return View();
        }
        [HttpPost]
        public ActionResult fogetpass2(UsersAdmins UsersAdmins, string txtpswrd)
        {
            //if (ModelState.IsValid)
            //{
            //    string[] inctoupd = new string[] {"Id", "Password","ConfirmPassword" };
            //    db.Entry(UsersAdmins).State = EntityState.Modified;
            //    var PropertyInfos = UsersAdmins.GetType().GetProperties();
            //    var r = UsersAdmins.GetType().GetProperties();
            //    foreach (PropertyInfo pInfo in PropertyInfos)
            //    {
            //        if (!(inctoupd.Contains(pInfo.Name)))
            //        {
            //            db.Entry(UsersAdmins).Property(pInfo.Name).IsModified = false;
            //        }
            //    }
            //    UsersAdmins.Password =enchlpr.Encrypt(txtpswrd);
            //    db.Configuration.ValidateOnSaveEnabled = false; ;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(UsersAdmins);
            //}
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmdUsersAdmins = new SqlCommand();
            cmdUsersAdmins.Connection = conn;
            conn.Open();

            cmdUsersAdmins.CommandText = "UPDATE  UsersAdmins set Password='" + enchlpr.Encrypt(txtpswrd) + "'  where Id=" + Request["hidid"] + "";
            cmdUsersAdmins.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("donesend");

        }
        public ActionResult donesend()
        {

            return View();
        }

        public ActionResult checsessions()
        {
            if (Session["logedin"] == "" && Session["iscomp"] != "1") { return RedirectToAction("Index", "Home"); }
            else { return View(); }
        }
    }
}