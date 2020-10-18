using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class AdminContactUsController : Controller
    {
        // GET: AdminContactUs
        public ActionResult AdminContactUsView()
        {
            using (DbModels dbModel = new DbModels())
            {
                var blogs = dbModel.ContactUs.OrderByDescending(m => m.ContactUsId).ToList();
                return View(blogs);
            }
        }
    }
}