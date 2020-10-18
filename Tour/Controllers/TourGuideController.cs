using System.Linq;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class TourGuideController : Controller
    {
        // GET: TourGuide
        public ActionResult TourGuideView(int id)
        {
            TourGuide guide = new TourGuide();
            using (DbModels dbModel = new DbModels())
            {

                var guides = dbModel.TourGuides.Where(x => x.TourGuideId == id).ToList();
                return View(guides); ;



                //  dbModel.UserTables.Add(userModel);
                // dbModel.SaveChanges();

            }
        }
    }
}