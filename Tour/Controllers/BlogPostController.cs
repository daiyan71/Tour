using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class BlogPostController : Controller
    {
        // GET: BlogPost
        [HttpGet]
        public ActionResult BlogPostView(int id = 0)
        {


            Blog blogModel = new Blog();
            return View(blogModel);
        } 

        [HttpPost]
        public ActionResult BlogPostView(Blog blogModel)
            {
              using (DbModels dbModel = new DbModels())
                {
                blogModel.UserId = (int)Session["userId"];
                dbModel.Blogs.Add(blogModel);
                dbModel.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Success!";
                return View();
            }
        
    }
}