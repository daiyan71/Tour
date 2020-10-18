using System.Linq;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            UserTable userModel = new UserTable();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(UserTable userModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.UserTables.Any(x => x.Email == userModel.Email))
                {
                    ViewBag.DuplicateMessage = "Email already exist!";
                    return View("AddOrEdit", userModel);
                }
                dbModel.UserTables.Add(userModel);
                dbModel.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Success!";
            return View("AddOrEdit", new UserTable());
        }
    }
}