using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour.Models;

namespace Tour.multiDataClass
{
    public class userBlog
    {

            public IEnumerable<UserTable> users { get; set; }
            public IEnumerable<Blog> blogs { get; set; }
        
    }
}