using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using escortagram.Models;
using AutoMapper;
using escortagram.Common;
using System.IO;
using System.Drawing;
namespace escortagram.Controllers
{
    public class ModelDashboardController : Controller
    {
        // GET: ModalDashboard
        EscortagramEntities db = new EscortagramEntities();
        public ActionResult Profile()
        {
            int Uid = Convert.ToInt32(Session["UserID"]);

           var md = (from a in db.UserMasters join n in db.CountryTbs on a.Nationality equals n.CountryID where a.UserID == Uid 
                     select new  
                     {  a, n.CountryName }).FirstOrDefault();
            var Country = (from a in db.CountryTbs
                           select new
                           {
                               CountryID = a.CountryID,
                               CountryName = a.CountryName
                           }).ToList();
            SelectList list = new SelectList(Country, "CountryID", "CountryName");
            ViewBag.Country = list;

            if (md != null)
            {
                UserMasterCustom User = new UserMasterCustom();
                User.Age = md.a.Age;
                User.Description = md.a.Description;
                User.FirstName = md.a.FirstName;
                User.LastName = md.a.LastName;
                User.CreatedDate = md.a.CreatedDate;
                if (md.a.Active == true)
                {
                    User.Active = "Yes";
                }
                else
                {
                    User.Active = "No";
                }
                User.Email = md.a.Email;
                User.Age = md.a.Age;
                if(md.a.LogoGuid!=null)
                { 
                User.LogoGuid = md.a.LogoGuid;
                }
                else
                {
                    User.LogoGuid = "";
                }
                User.MobileNo = md.a.MobileNo;
                User.Nationality = md.CountryName;
                User.Nationalityupdate = (int)md.a.Nationality;
                User.Languages = md.a.Languages;
                User.Measurements = md.a.Measurements;
                User.DressSize = md.a.DressSize;
                User.Height = md.a.Height;
                User.HairColor = md.a.HairColor;
                User.EyeColor = md.a.EyeColor;
                User.Availability = md.a.Availability;
                User.Location = md.a.Location;
                User.Orientation = md.a.Orientation;
                User.FavouritePerfume = md.a.FavouritePerfume;
                User.FavouriteCuisine = md.a.FavouriteCuisine;
                if (md.a.UKtravel == null)
                {
                    User.UKtravelupdate = false;
                }

                if (md.a.UKtravel == true)
                {
                    User.UKtravel = "Yes";
                }
                else
                {
                    User.UKtravel = "No";
                }
                var Images = (from a in db.ModelImages where a.ModelID == Uid select new { a,
                      Imag =  a.BannerImageGuid == null ? false : a.BannerImageGuid 
                }).ToList();
                images obj = new images();
                List<images> ilist = new List<images>();
                foreach (var item in Images)
                {
                    if (item.Imag != null)
                    {
                        if (item.Imag == true)
                        {
                            User.BannerImage = item.a.OtherImages;
                        }
                    }
                    
                    images o = new images();
                    o.OtherImages = item.a.OtherImages;
                    ilist.Add(o);
                }

                User.ImagesList = ilist;
                ViewBag.Success = "";
                return View(User);
            }

            return View();
        }
        [HttpPost]
        public ActionResult Profile(UserMasterCustom User)
        {
            // HttpPostedFileBase files = Request.Files["file"];

            int Uid = Convert.ToInt32(Session["UserID"]);
            //Mapper.creat<UserMaster, UserMaster>();
            UserMaster md = (from a in db.UserMasters where a.UserID == Uid select a).FirstOrDefault();
            if (md != null)
            {
                md.Age = User.Age;
                md.FirstName = User.FirstName;
                md.LastName = User.LastName;
                md.CreatedDate = User.CreatedDate;
                md.Email = User.Email;
                md.Age = User.Age;
                md.MobileNo = User.MobileNo;
                md.Nationality = User.Nationalityupdate;
                md.Languages = User.Languages;
                md.Measurements = User.Measurements;
                md.DressSize = User.DressSize;
                md.Height = User.Height;
                md.HairColor = User.HairColor;
                md.EyeColor = User.EyeColor;
                md.Availability = User.Availability;
                md.Location = User.Location;
                md.Orientation = User.Orientation;
                md.FavouritePerfume = User.FavouritePerfume;
                md.FavouriteCuisine = User.FavouriteCuisine;
                md.UKtravel = User.UKtravelupdate;
                md.Description = User.Description;
                db.SaveChanges();
                ViewBag.Success = "Saved Success";
            }
            var Country = (from a in db.CountryTbs
                           select new
                           {
                               CountryID = a.CountryID,
                               CountryName = a.CountryName
                           }).ToList();
            SelectList list = new SelectList(Country, "CountryID", "CountryName");
            ViewBag.Country = list;
            return View(User);
        }
        [HttpPost]
        public ActionResult deopzone(HttpPostedFileBase[] file)
        {
            int Uid = Convert.ToInt32(Session["UserID"]);

            foreach (var item in file)
            {
                string Type = "OtherPics";
                ModelImage imageobj = new ModelImage();
                string guid = Guid.NewGuid().ToString();
                CommonFunction cmn = new CommonFunction();
                // HttpPostedFileBase file = User.attachment;
                cmn.SaveFile(item, guid, Type);
                imageobj.ModelID = Uid;
                imageobj.OtherImages = guid;
                
                db.ModelImages.Add(imageobj);
                db.SaveChanges();
            }


            return Json(1);
        }
        public ActionResult SetBannerImage(string Guid)
        {
            int Uid = Convert.ToInt32(Session["UserID"]);
            var OldBanner = (from a in db.ModelImages where a.BannerImageGuid == true && a.ModelID==Uid select a).FirstOrDefault();
            if (OldBanner != null)
            {
                OldBanner.BannerImageGuid = false;
                db.SaveChanges();
            }
            var Data = (from a in db.ModelImages where a.OtherImages == Guid && a.ModelID == Uid select a).FirstOrDefault();
            if (Data != null)
            {
                Data.BannerImageGuid = true;

                db.SaveChanges();
            }
            return Json(Guid);
        }
        public ActionResult ProfilePic(HttpPostedFileBase file)
        {
            try
            {
                int Uid = Convert.ToInt32(Session["UserID"]);

                var ProfilePic = (from a in db.UserMasters where a.UserID == Uid select a).FirstOrDefault();
                string guid = "";

                if (ProfilePic != null && ProfilePic.LogoGuid == null || ProfilePic.LogoGuid == "")
                {
                     guid = Guid.NewGuid().ToString();
                     string Type = "ProfilePicNew";
                    CommonFunction cmn = new CommonFunction();                    
                    cmn.SaveFile(file, guid, Type);
                    ProfilePic.LogoGuid = guid;
                    db.SaveChanges();
                }
                else if (ProfilePic != null && ProfilePic.LogoGuid != null || ProfilePic.LogoGuid != "")
                {
                    guid=ProfilePic.LogoGuid;
                    string Type = "ProfilePicExist";
                    CommonFunction cmn = new CommonFunction();
                    cmn.SaveFile(file, guid, Type);

                }
                return Json(guid);
            }
            catch
            {
                return Json(0);
            }

        }

    }
}