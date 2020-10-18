using System.Linq;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["adminId"]!=null)
            {
                Session.Abandon();
            }
            using (DbModels dbModel = new DbModels())
            {
                
                var locations = dbModel.Locations.ToList();


                return View(locations);

            }
        }

        public ActionResult About()
        {
            
            
            ViewBag.Message = "Your application description page.";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}