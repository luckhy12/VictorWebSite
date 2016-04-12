using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace escortagram.Common
{
    public class CommonFunction
    {
       
        public void SaveFile(HttpPostedFileBase file,string Guid , string Type)
        {
            var NewFolder = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            
            string savePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"\\Upload\\ModelImages\\" + NewFolder + "\\"));
            if(Type=="OtherPics")
            {
                //int fileCount = Directory.GetFiles(savePath).Length;
            string fileName = Guid;
            

             string pathToCheck = savePath;

                if (Directory.Exists(pathToCheck))
                {
                    savePath += fileName + ".jpg";
                    file.SaveAs(savePath);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(savePath);
                    savePath += fileName + ".jpg";
                    file.SaveAs(savePath);
                }
                }
            if(Type=="ProfilePicExist")
            {
                savePath += Guid + ".jpg";
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                    file.SaveAs(savePath);
                }
                else
                {
                    file.SaveAs(savePath);
                }
            }
            if (Type == "ProfilePicNew")
            {
                savePath += Guid + ".jpg";
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                    file.SaveAs(savePath);
                }
                else
                {
                    file.SaveAs(savePath);
                }
            }
            if(Type=="BannerImage")
            {
                string ImagePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"\\Upload\\BannerImage\\"));
                if (Directory.Exists(ImagePath))
                {
                    string fileName = Guid;
                    ImagePath += fileName + ".jpg";
                    File.Delete(ImagePath);
                    file.SaveAs(ImagePath);
                }
                          
            }
            if (Type == "BannerImageNew")
            {
                string ImagePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"\\Upload\\BannerImage\\"));
                if (Directory.Exists(ImagePath))
                {
                    string fileName=Guid;

                    ImagePath += fileName + ".jpg";
                   file.SaveAs(ImagePath);
                }
               

            }
            if(Type=="TestimonialImage")
            {
                string ImagePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"\\Upload\\TestimonialImages\\"));
                if (Directory.Exists(ImagePath))
                {
                    string fileName = Guid;

                    ImagePath += fileName + ".jpg";
                    file.SaveAs(ImagePath);
                }
            }
            }

        public void DeleteFile(string Guid)
        {
            string ImagePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"\\Upload\\TestimonialImages\\"));
            if (Directory.Exists(ImagePath))
            {
                string fileName = Guid;
                ImagePath += fileName + ".jpg";
                File.Delete(ImagePath);
                
            }
        }

        }
    }
