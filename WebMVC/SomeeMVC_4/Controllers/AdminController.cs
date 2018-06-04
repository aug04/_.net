using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SomeeMVC_4.Models;
using SomeeMVC_4.Utilities;

namespace SomeeMVC_4.Controllers
{
    public class AdminController : Controller
    {
        // Trang mặc định Administrator
        // GET: /Admin/

        public ActionResult Index()
        {
            if (Session["UserLogin"] != null)
                return View();

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        // Xử lý dữ liệu đăng nhập
        [HttpPost]
        public ActionResult Login(UsersModel user)
        {
            using (augblogsEntities db = new augblogsEntities())
            {
                if (user != null
                    && !String.IsNullOrEmpty(user.Username)
                    && !String.IsNullOrEmpty(user.Password))
                {
                    var username = user.Username;
                    var password = Sha256.Hash(user.Password);
                    var userLogin = (from u in db.Users
                                        where u.Username == username && u.Password == password
                                        select u).FirstOrDefault();

                    if (userLogin != null)
                    {
                        Session["UserLogin"] = userLogin;

                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
            }

            return View();
        }

        // Đăng xuất
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }

        // Thông tin hồ sơ
        public ActionResult ViewAccountInfo()
        {
            if (Session["UserLogin"] == null)
                return RedirectToAction("Login");

            User user = (User)Session["UserLogin"];

            return View(user);
        }

        // Đổi mật khẩu
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(UsersModel um)
        {
            if (Session["UserLogin"] == null)
                return RedirectToAction("Login");

            using (augblogsEntities db = new augblogsEntities())
            {
                string username = um.Username;
                string password = um.Password;
                var userEdit = (from u in db.Users where u.Username == username 
                                    select u).FirstOrDefault();
                if (userEdit != null)
                {
                    userEdit.Password = Sha256.Hash(um.Password);
                    int updated = db.SaveChanges();
                    if (updated > 0)
                        ViewBag.UpdateResult = "Cập nhật mật khẩu thành công.";
                    else
                        ViewBag.UpdateResult = "Cập nhật mật khẩu không thành công!";
                }
            }

            return View(um);
        }
    }
}
