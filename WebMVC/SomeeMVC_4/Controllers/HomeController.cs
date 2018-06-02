using System.Web.Mvc;
using SomeeMVC_4.Models;
using System.Linq;

namespace SomeeMVC_4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            UsersModel um = null;
            using (augblogsEntities db = new augblogsEntities())
            {
                var user = (from u in db.Users where u.Username.Equals("aug") select u).FirstOrDefault();
                if (user != null)
                {
                    um = new UsersModel();
                    um.Id = user.Id;
                    um.Username = user.Username;
                    um.Password = user.Password;
                    um.Email = user.Email;
                    um.DisplayName = user.DisplayName;
                    um.Status = user.Status;
                }
            }

            return View(um);
        }

    }
}
