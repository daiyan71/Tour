using System.Linq;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult HotelView(int id)
        {
            Hotel hotl = new Hotel();
            using (DbModels dbModel = new DbModels())
            {

                var hotels = dbModel.Hotels.Where(x => x.HotelId == id).ToList();
                return View(hotels); ;



                //  dbModel.UserTables.Add(userModel);
                // dbModel.SaveChanges();

            }
        }
    }
}