using System.Web.Mvc;

namespace Tour.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        public ActionResult AdminHomeView()
        {
            return View();
        }
        public ActionResult Location()
        {
            return RedirectToAction("List", "AdminLocation");
        }
        public ActionResult Hotel()
        {
            return RedirectToAction("List", "AdminHotel");
        }
        public ActionResult TourGuide()
        {
            return RedirectToAction("List", "AdminTourGuide");
        }

        public ActionResult Blog()
        {
            return RedirectToAction("Index", "AdminBlog");
        }

    }
}