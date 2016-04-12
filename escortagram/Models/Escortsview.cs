using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace escortagram.Models
{
    public class Escortsview
    {
        public int UserID { get; set; }
        public string BannerImageGuid { get; set; }
        public string FirstName { get; set; }
        public int PageID { get; set; }
        public string PageName { get; set; }
        public int TestimonialID { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialDesc { get; set; }
        public string TestimonialImage { get; set; }

        public List<Escortsview> Menu { get; set; }
        public List<Escortsview> Testi { get; set; }
        public List<Escortsview> List { get; set; }
    }
}