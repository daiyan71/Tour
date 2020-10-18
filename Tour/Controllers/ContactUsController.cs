using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class ContactUsController : Controller
    {
        [HttpGet]
        public ActionResult ContactUsView(int id=0)
        {
            ContactU model = new ContactU();
            return View(model);
        }
        [HttpPost]
        public ActionResult ContactUsView(ContactU model)
        {
            using (DbModels dbModel = new DbModels())
            {
                dbModel.ContactUs.Add(model);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Success!";
            return View();
        
        }
    }
}