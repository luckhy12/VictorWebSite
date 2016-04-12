using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using escortagram.Models;
using escortagram.Common;
using GridMvc.Html;

namespace escortagram.Controllers
{
    public class HomeController : Controller
    {
        EscortagramEntities db = new EscortagramEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            List<PageModel> Lst = new List<PageModel>();

            PageModel obj = new PageModel();
            var Pagedata = (from a in db.PageTBs select a).ToList();
            foreach (var item in Pagedata)
            {
                PageModel dummy = new PageModel();
                dummy.CreatedDate = item.CreatedDate;
                dummy.ModifiedDate = item.ModifiedDate;
                dummy.PageName = item.PageName;
                dummy.PageOrder = item.PageOrder;
                dummy.PageURL = item.PageURL;
                dummy.Status = item.Status;
                dummy.PageID = item.PageID;
                Lst.Add(dummy);
            }
            obj.List = Lst;
            return View(obj);
        }
        public JsonResult UpdateHome(string PageName, int PageOrder, bool? PageStatus, string PageUrl, int PageID)
        {
            try
            {
                var HomeData = (from a in db.PageTBs where a.PageID == PageID select a).FirstOrDefault();
                HomeData.PageName = PageName;
                HomeData.PageOrder = PageOrder;
                HomeData.Status = PageStatus;
                HomeData.PageURL = PageUrl;
                db.SaveChanges();
                return Json(PageID);
            }
            catch (Exception ex)
            {
                return Json(0);
            }
        }
        public JsonResult BannerImage(HttpPostedFileBase file)
        {
            string guid = "";
            CommonFunction cm = new CommonFunction();
            var Image = (from a in db.BannerImageTBs select a).FirstOrDefault();
            if (Image != null)
            {
                guid = Image.BannerImage;
                string Type = "BannerImage";
                CommonFunction cmn = new CommonFunction();
                cmn.SaveFile(file, guid, Type);
                Image.BannerImage = guid;
                db.SaveChanges();
            }
            if (Image == null)
            {
                guid = Guid.NewGuid().ToString();
                string Type = "BannerImageNew";
                CommonFunction cmn = new CommonFunction();
                cmn.SaveFile(file, guid, Type);
                BannerImageTB Obj = new BannerImageTB();
                Obj.BannerImage = guid;
                db.BannerImageTBs.Add(Obj);
                db.SaveChanges();
            }
            return Json(1);
        }

        public JsonResult Testimonials(HttpPostedFileBase file, string Title, string Desc)
        {
            Testimonial Test = new Testimonial();

            string guid = Guid.NewGuid().ToString();
            string Type = "TestimonialImage";
            CommonFunction cmn = new CommonFunction();
            cmn.SaveFile(file, guid, Type);
            Test.TestimonialDesc = Desc;
            Test.TestimonialTitle = Title;
            Test.Active=true;
            Test.TestimonialImage = guid;
            db.Testimonials.Add(Test);
            db.SaveChanges();
            return Json(1);
        }

        public ActionResult ViewTestimonial()
        {
            var ViewData = db.Testimonials.ToList();

            return View(ViewData);
        }
        public JsonResult DeleteDestimonial(int ID)
        {
            try
            {
                var Testimonial = db.Testimonials.Where(x => x.TestimonialID == ID).FirstOrDefault();
                if (Testimonial != null)
                {
                    CommonFunction cm = new CommonFunction();
                    cm.DeleteFile(Testimonial.TestimonialImage);
                    db.Testimonials.Remove(Testimonial);
                    db.SaveChanges();
                    
                    return Json(1);
                }
                else
                {
                    return Json("error");
                }
            }
            catch
            {
                return Json(0);
            }


        }

        public ActionResult UpdateTestimonial(int ID,bool Status)
        {
            try
            {
                var Testimonial = db.Testimonials.Where(x => x.TestimonialID == ID).FirstOrDefault();
                if (Testimonial != null)
                {
                    Testimonial.Active = Status;
                    db.SaveChanges();

                    return Json(1);
                }
                else
                {
                    return Json("error");
                }
            }
            catch
            {
                return Json(0);
            }
        }
    }
}
