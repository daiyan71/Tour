using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class AdminBlogController : Controller
    {
        // GET: AdminBlog
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {

                var blog = dbModel.Blogs.ToList();


                return View(blog);
            }
        }

        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                var query = dbModel.Blogs.Where(x => x.BlogId == id).First();
                dbModel.Blogs.Remove(query);
                dbModel.SaveChanges();

                var list = dbModel.Blogs.ToList();
                return View("Index", list);
            }
        }




    }
       
        
    
}