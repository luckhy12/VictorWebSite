using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using escortagram.Models;
using System.Security.Cryptography;
namespace escortagram.Controllers
{
    public class LoginController : Controller
    {
        EscortagramEntities db = new EscortagramEntities();
        // GET: Login
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users users)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                string username = users.Emails;
                string password = users.Passwords;

                // var str = dbContext.spGetUserLogin(username, password).ToList();
                var validlogin = (from a in db.UserMasters where a.Email == username select a).FirstOrDefault();

                if (validlogin != null)
                {
                    byte[] saltBytes = new byte[8];

                    saltBytes = Convert.FromBase64String(validlogin.PasswordSalt);

                    if (ENCDEC.ComputeHash(password, "MD5", saltBytes) == validlogin.PasswordHash)
                    {
                        Session["UserID"] = validlogin.UserID;
                        Session["FirstName"] = validlogin.FirstName;
                        Session["UserType"] = validlogin.UserType;
                        if (validlogin.UserType == 1)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (validlogin.UserType == 2)
                        {
                            return RedirectToAction("Profile", "ModelDashboard");
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Sorry, we didn't recognise that email address. Are you sure you didn't use a different one?";
                        return View();
                    }

                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.Error = "Sorry, wrong password.";
            return View();
        }
        public ActionResult Logout() 
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UsersMaster Users)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            UserMaster obj = new UserMaster();
            obj.FirstName = Users.FirstName;
            obj.MobileNo = Users.MobileNo;
            obj.Email = Users.Email;
            obj.CreatedDate = DateTime.Now;
            obj.Active = true;
            obj.Age = Users.Age;
            obj.LastName = Users.LastName;
            obj.UserType = 1;
            byte[] salt = new byte [8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);
            var HASH = ENCDEC.ComputeHash(Users.Password, "MD5", salt);
            obj.PasswordSalt = Convert.ToBase64String(salt);
            obj.PasswordHash=HASH;
            db.UserMasters.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}