using System.Linq;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult Autherize(AdminTable adminModel)
        {
            using (DbModels dbModel = new DbModels())
            {

                var adminDetails = dbModel.AdminTables.Where(x => x.Email == adminModel.Email && x.Password == adminModel.Password).FirstOrDefault();
                if (adminDetails == null)
                {
                    adminModel.LoginErrorMessage = "Wrong email or password";
                    return View("AdminLogin", adminModel); ;
                }
                else
                {
                    Session["adminId"] = adminDetails.AdminId;
                    
                    Session["FirstName"] = adminDetails.FirstName;
                    return RedirectToAction("AdminHomeView", "AdminHome");
                }

                //  dbModel.UserTables.Add(userModel);
                // dbModel.SaveChanges();

            }
            // ModelState.Clear();
            //ViewBag.SuccessMessage = "Success!";
            // return View();
        }
    }
}