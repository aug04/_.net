using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SomeeMVC_4.Models;
using SomeeMVC_4.Utilities;

namespace SomeeMVC_4.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserLogin"] != null)
                return View();

            return RedirectToAction("Login", "Home");
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

                        return RedirectToAction("Index", "Home");
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

            return RedirectToAction("Login", "Home");
        }

    }
}
