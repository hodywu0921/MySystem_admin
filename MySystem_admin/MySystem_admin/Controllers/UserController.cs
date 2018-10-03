using MySystem_admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MySystem_admin.Attributes.MultiButton;

namespace MySystem_admin.Controllers
{
    public class UserController : Controller
    {
        public MySystemDBEntities db = new MySystemDBEntities();

        public ActionResult UserInfo()
        {
            //List<UserViewModel> userVMList = db.User.Select(x => new UserViewModel
            //{
            //    GroupId = x.GroupId,
            //    FactoryId = x.FactoryId,
            //    UserId = x.UserId,
            //    UserName = x.UserName,
            //    Password = x.Password,
            //    RoleId = x.RoleId,
            //    Email = x.Email
            //}).ToList();

            //ViewBag.userList = userVMList;

            //return View(userVMList);
            return View();
        }
        public JsonResult UserData()
        {
            List<UserViewModel> userlist = db.User.Select(x => new UserViewModel
            {
                GroupId = x.GroupId,
                FactoryId = x.FactoryId,
                UserId = x.UserId,
                UserName = x.UserName,
                Password = x.Password,
                RoleId = x.RoleId,
                Email = x.Email
            }).ToList();

            return Json(userlist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserDetail(string groupid, string factoryid, string userid)
        {
            List<UserViewModel> userDtl = db.User.Where(u => u.GroupId == groupid && u.FactoryId == factoryid && u.UserId == userid).Select(u => new UserViewModel { UserName = u.UserName, Password = u.Password, RoleId = u.RoleId, Email = u.Email }).ToList();

            ViewBag.UserDtl = userDtl;

            return PartialView("UserDetailPartial");
        }

        public ActionResult EditUser(string groupid, string factoryid, string userid)
        {
            UserViewModel model = new UserViewModel();
            if (groupid != null && factoryid != null && userid != null)
            {
                User user = db.User.SingleOrDefault(u => u.GroupId == groupid && u.FactoryId == factoryid && u.UserId == userid);
                model.GroupId = user.GroupId;
                model.FactoryId = user.FactoryId;
                model.UserId = user.UserId;
                model.UserName = user.UserName;
                model.Password = user.Password;
                model.RoleId = user.RoleId;
                model.Email = user.Email;
            }

            return PartialView("UserEditPartial", model);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserViewModel model)
        {
            try
            {
                string status;
                if (model.GroupId != null && model.FactoryId != null && model.UserId != null)
                {
                    User user = db.User.SingleOrDefault(u => u.GroupId == model.GroupId && u.FactoryId == model.FactoryId && u.UserId == model.UserId);
                    user.GroupId = model.GroupId;
                    user.FactoryId = model.FactoryId;
                    user.UserId = model.UserId;
                    user.UserName = model.UserName;
                    user.Password = model.Password;
                    user.RoleId = model.RoleId;
                    user.Email = model.Email;
                    db.SaveChanges();
                    status = "true";
                }
                else
                {
                    status = "fasle";
                }
                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public ActionResult UpdateUser(UserViewModel model)
        //{
        //    try
        //    {
        //        if (model.GroupId != null && model.FactoryId != null && model.UserId != null)
        //        {
        //            User user = db.User.SingleOrDefault(u => u.GroupId == model.GroupId && u.FactoryId == model.FactoryId && u.UserId == model.UserId);
        //            user.GroupId = model.GroupId;
        //            user.FactoryId = model.FactoryId;
        //            user.UserId = model.UserId;
        //            user.UserName = model.UserName;
        //            user.Password = model.Password;
        //            user.RoleId = model.RoleId;
        //            user.Email = model.Email;
        //            db.SaveChanges();
        //        }

        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public ActionResult DelUser(string groupid, string factoryid, string userid)
        {
            UserViewModel model = new UserViewModel();
            if (groupid != null && factoryid != null && userid != null)
            {
                User user = db.User.SingleOrDefault(u => u.GroupId == groupid && u.FactoryId == factoryid && u.UserId == userid);
                model.GroupId = user.GroupId;
                model.FactoryId = user.FactoryId;
                model.UserId = user.UserId;
                model.UserName = user.UserName;
                model.Password = user.Password;
                model.RoleId = user.RoleId;
                model.Email = user.Email;
            }

            return PartialView("UserDelPartial", model);
        }
        [HttpPost]
        //public ActionResult DeleteUser(UserViewModel model)
        //{
        //    try
        //    {
        //        if (model.GroupId != null && model.FactoryId != null && model.UserId != null)
        //        {
        //            User user = db.User.SingleOrDefault(u => u.GroupId == model.GroupId && u.FactoryId == model.FactoryId && u.UserId == model.UserId);
        //            db.User.Remove(user);
        //            db.SaveChanges();
        //        }
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public JsonResult DeleteUser(UserViewModel model)
        {
            try
            {
                string status;
                if (model.GroupId != null && model.FactoryId != null && model.UserId != null)
                {
                    User user = db.User.SingleOrDefault(u => u.GroupId == model.GroupId && u.FactoryId == model.FactoryId && u.UserId == model.UserId);
                    db.User.Remove(user);
                    db.SaveChanges();
                    status = "true";
                }
                else
                {
                    status = "false";
                }

                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}