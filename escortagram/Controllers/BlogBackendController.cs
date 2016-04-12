using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using escortagram.Models;
namespace escortagram.Controllers
{
    public class BlogBackendController : Controller
    {
        // GET: BlogBackend
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult AddBlog(HttpPostedFileBase file, FormCollection fc)
        {
            int Uid = Convert.ToInt32(Session["UserID"]);
            
            blog_post blog = new blog_post();
            blog.authorId = Uid;
            //blog.article=
            return Json(1);
        }
    }
}