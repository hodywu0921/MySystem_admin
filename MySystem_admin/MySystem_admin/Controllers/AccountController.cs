using MySystem_admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using static MySystem_admin.Attributes.MultiButton;

namespace MySystem_admin.Controllers
{
    public class AccountController : Controller
    {
        public MySystemDBEntities db = new MySystemDBEntities();

        //[AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [MultiButton("sign")]
        public ActionResult Login(FormCollection ftmp)
        {
            string userId = ftmp["userid"];
            string password = ftmp["password"];

            var userInfo = (from u in db.User select u).Where(u => u.UserId == userId && u.Password == password).FirstOrDefault();

            if (userInfo == null)
            {
                ViewBag.LoginMsg = "Invalid User Id or Password";
                //如無對應使用者導頁
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //Request.GetOwinContext().Authentication.SignOut("SSBConfirm");
                //ClaimsIdentity identity = new ClaimsIdentity
                //(
                //    new[] {
                //        new Claim(ClaimTypes.Name, userInfo.UserName),
                //        new Claim("UserId", userInfo.UserId),
                //        new Claim(ClaimTypes.Role, userInfo.RoleId)
                //    },
                //    "SSBConfirm"
                //);
                //Request.GetOwinContext().Authentication.SignIn(identity);


                //return RedirectToAction("Index", "Home");
                switch (userInfo.RoleId.ToString())
                {
                    case "admin":
                        return RedirectToAction("Index", "Home");
                    case "user":
                        return RedirectToAction("About", "Home");
                    case "another":
                        return RedirectToAction("Contact", "Home");
                    default:
                        return RedirectToAction("Login", "Account");
                }

            }
        }

        [HttpPost]
        [MultiButton("register")]
        public ActionResult Register(FormCollection rtmp)
        {
            string userId = rtmp["r_userid"];
            string password = rtmp["r_password"];
            string groupId = rtmp["r_groupid"];
            string factoryId = rtmp["r_factoryid"];
            string email = rtmp["r_email"];
            string roleid = "user";
            string username = rtmp["r_username"];

            if (userId != null && password != null && groupId != null && factoryId != null)
            {
                User user = new User() { UserId = userId, Password = password, UserName = username, GroupId = groupId, FactoryId = factoryId, Email = email, RoleId = roleid };
                db.User.Add(user);
                db.SaveChanges();
                ViewBag.RegisterMsg = "Register successful.";
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.RegisterMsg = "Register failed.";
            }

            return View();
        }

    }
}