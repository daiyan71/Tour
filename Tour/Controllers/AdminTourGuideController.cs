using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Tour.Models;
namespace Tour.Controllers
{
    public class AdminTourGuideController : Controller
    {
        // GET: AdminTourGuide
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {

                var tourguide = dbModel.TourGuides.ToList();


                return View(tourguide);
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TourGuide model)
        {

            String filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            String extension = Path.GetExtension(model.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            model.Image = "~/Content/img/" + filename;
            filename = Path.Combine(Server.MapPath("~/Content/img/"), filename);
            model.ImageFile.SaveAs(filename);
            using (DbModels dbModel = new DbModels())
            {
                TourGuide obj = new TourGuide();


                obj.LocationId = model.LocationId;
                obj.TourGuideId = model.TourGuideId;
                obj.FirstName = model.FirstName;
                obj.LastName = model.LastName;
                obj.LocationId = model.LocationId;
                obj.MaxCharge = model.MaxCharge;
                obj.MinCharge = model.MinCharge;
                obj.Phone = model.Phone;




                if (model.TourGuideId == 0)
                {
                    dbModel.TourGuides.Add(model);
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
            TourGuide obj = new TourGuide();
            using (DbModels dbModel = new DbModels())
            {
                //obj = db.images.Where(x => x.id == id).First();
                var list = dbModel.TourGuides.ToList();
                return View(list);
            }
        }
        public ActionResult Edit(TourGuide obj)
        {

            return View(obj);

        }

        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                var query = dbModel.TourGuides.Where(x => x.TourGuideId == id).First();
                dbModel.TourGuides.Remove(query);
                dbModel.SaveChanges();

                var list = dbModel.TourGuides.ToList();
                return View("List", list);
            }
        }
    }
}