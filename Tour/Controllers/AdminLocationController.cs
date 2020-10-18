using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class AdminLocationController : Controller
    {
        // GET: AdminLocation
        
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {

                var locations = dbModel.Locations.ToList();


                return View(locations);
            }

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Location model)
        {
            String filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            String extension = Path.GetExtension(model.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            model.Image = "~/Content/img/" + filename;
            filename = Path.Combine(Server.MapPath("~/Content/img/"), filename);
            model.ImageFile.SaveAs(filename);
            using (DbModels dbModel = new DbModels())
            {
                Location obj = new Location();



                obj.LocationId = model.LocationId;
                obj.LocationName = model.LocationName;
                obj.District = model.District;
                obj.Details = model.Details;
                obj.Image = model.Image;



                if (model.LocationId == 0)
                {
                    dbModel.Locations.Add(model);
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
            Location obj = new Location();
            using (DbModels dbModel = new DbModels())
            {
                //obj = db.images.Where(x => x.id == id).First();
                var list = dbModel.Locations.ToList();
                return View(list);
            }
        }

        public ActionResult Edit(Location obj)
        {

            return View(obj);

        }


        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                var query = dbModel.Locations.Where(x => x.LocationId == id).First();
                 var query1 = dbModel.Hotels.Where(x => x.LocationId == id).First();
                var query2 = dbModel.TourGuides.Where(x => x.LocationId == id).First();



                dbModel.Locations.Remove(query);

                dbModel.Hotels.Remove(query1);

                dbModel.TourGuides.Remove(query2);




                dbModel.SaveChanges();

                var list = dbModel.Locations.ToList();
                return View("List", list);
            }
        }
    }
}