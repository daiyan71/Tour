using System.Linq;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(UserTable userModel)
        {
            using (DbModels dbModel = new DbModels())
            {

                var userDetails = dbModel.UserTables.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong email or password";
                    return View("LoginView", userModel); ;
                }
                else
                {
                    Session["userId"] = userDetails.UserId;
                    Session["FirstName"] = userDetails.FirstName;
                    return RedirectToAction("Index", "Home");
                }

                //  dbModel.UserTables.Add(userModel);
                // dbModel.SaveChanges();

            }
            // ModelState.Clear();
            //ViewBag.SuccessMessage = "Success!";
            // return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("LoginView", "Login");
        }
    }
}