using System.Linq;
using System.Web.Mvc;
using Tour.Models;
using Tour.multiDataClass;

namespace Tour.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult BlogView()
        {
            Blog blog = new Blog();
            using (DbModels dbModel = new DbModels())
            {
                var alldata = new userBlog();
                alldata.blogs = dbModel.Blogs.OrderByDescending(m => m.BlogId).ToList();
                alldata.users = dbModel.UserTables.ToList();
                return View(alldata);



               /* var blogs = dbModel.Blogs.ToList();
                var users = dbModel.UserTables.ToList();
                return View(blogs);*/
            }
        }
        
        

    }
}
