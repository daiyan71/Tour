using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class AdminHotelController : Controller
    {
        // GET: AdminHotel
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {

                var hotel = dbModel.Hotels.ToList();


                return View(hotel);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Hotel model)
        {
            String filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            String extension = Path.GetExtension(model.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            model.Image = "~/Content/img/" + filename;
            filename = Path.Combine(Server.MapPath("~/Content/img/"), filename);
            model.ImageFile.SaveAs(filename);

            using (DbModels dbModel = new DbModels())
            {
                Hotel obj = new Hotel();


                obj.LocationId = model.LocationId;
                obj.HotelId = model.HotelId;
                obj.HotelName = model.HotelName;
                obj.MaxPrice = model.MaxPrice;
                obj.MinPrice = model.MinPrice;
                obj.Phone = model.Phone;
                obj.Email = model.Email;
                obj.Address = model.Address;



                if (model.HotelId == 0)
                {
                    dbModel.Hotels.Add(model);
                    dbModel.SaveChanges();
                }
                else
                {

                    dbModel.Entry(obj).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }



                ModelState.Clear();
                return View("Create");

            }
        }
        [HttpGet]
        public ActionResult List()
        {
            Hotel obj = new Hotel();
            using (DbModels dbModel = new DbModels())
            {
                //obj = db.images.Where(x => x.id == id).First();
                var list = dbModel.Hotels.ToList();
                return View(list);
            }
        }
        public ActionResult Edit(Hotel obj)
        {

            return View(obj);

        }

        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                var query = dbModel.Hotels.Where(x => x.HotelId == id).First();
                dbModel.Hotels.Remove(query);
                dbModel.SaveChanges();

                var list = dbModel.Hotels.ToList();
                return View("List", list);
            }
        }
    }
}