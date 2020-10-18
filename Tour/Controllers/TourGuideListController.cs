using System.Linq;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class TourGuideListController : Controller
    {
        // GET: TourGuideList
        public ActionResult TourGuideListView(int id)
        {
            TourGuide tg = new TourGuide();
            using (DbModels dbModel = new DbModels())
            {

                var guides = dbModel.TourGuides.Where(x => x.LocationId == id).ToList();
                return View(guides); ;



                //  dbModel.UserTables.Add(userModel);
                // dbModel.SaveChanges();

            }
        }
    }
}