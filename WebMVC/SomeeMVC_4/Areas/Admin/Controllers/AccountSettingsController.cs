using System.Linq;
using System.Web.Mvc;
using SomeeMVC_4.Models;
using SomeeMVC_4.Utilities;

namespace SomeeMVC_4.Areas.Admin.Controllers
{
    public class AccountSettingsController : Controller
    {
        // Thông tin hồ sơ
        public ActionResult AccountInfo()
        {
            if (Session["UserLogin"] == null)
                return RedirectToAction("Login", "Home");

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
                return RedirectToAction("Login", "Home");

            User user = (User)Session["UserLogin"];

            string username = user.Username;
            string currentPassowrd = user.Password;
            string password = Sha256.Hash(um.Password);
            string newPassword = Sha256.Hash(um.NewPassword);
            string confirmNewPassword = Sha256.Hash(um.ConfirmPassword);

            using (var db = new augblogsEntities())
            {
                if (string.IsNullOrEmpty(username)
                    || string.IsNullOrEmpty(password)
                    || string.IsNullOrEmpty(newPassword)
                    || string.IsNullOrEmpty(confirmNewPassword))
                {
                    ModelState.AddModelError("", "Hãy điền đầy đủ các trường thông tin!");
                }
                else if (!confirmNewPassword.Equals(newPassword))
                {
                    ModelState.AddModelError("ConfirmPassword", "Xác nhận mật khẩu mới không khớp!");
                }
                else
                {
                    if (!password.Equals(currentPassowrd))
                        ModelState.AddModelError("Password", "Mật khẩu hiện tại không chính xác!");
                    else
                    {
                        var userEdit = (from u in db.Users
                                        where u.Username == username
                                        select u).FirstOrDefault();
                        if (userEdit != null)
                        {
                            userEdit.Password = newPassword;

                            int updated = db.SaveChanges();
                            if (updated > 0)
                                ViewBag.UpdateResult = "Cập nhật mật khẩu thành công.";
                            else
                                ViewBag.UpdateResult = "Cập nhật mật khẩu không thành công!";
                        }
                    }
                }
            }

            return View(um);
        }

    }
}
