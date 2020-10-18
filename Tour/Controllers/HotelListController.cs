using System.Linq;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class HotelListController : Controller
    {

        // GET: HotelList
        public ActionResult HotelListView(int id)
        {
            Hotel hotl = new Hotel();
            using (DbModels dbModel = new DbModels())
            {

                var hotels = dbModel.Hotels.Where(x => x.LocationId == id).ToList();
                return View(hotels); ;



                //  dbModel.UserTables.Add(userModel);
                // dbModel.SaveChanges();

            }
        }
    }
}