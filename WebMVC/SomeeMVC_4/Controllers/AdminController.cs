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
        //
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

        [HttpPost]
        public ActionResult Login(UsersModel user)
        {
            using (augblogsEntities db = new augblogsEntities())
            {
                if (user != null && !String.IsNullOrEmpty(user.Username))
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

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
