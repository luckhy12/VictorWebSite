using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace escortagram.Models
{
    public class UserMasterCustom
    {
        public int UserID { get; set; }
        public Nullable<int> UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Active { get; set; }
        public bool ActiveUpdate { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> MobileNo { get; set; }
        public string Nationality { get; set; }
        public int Nationalityupdate { get; set; }
        public string Languages { get; set; }
        public string Measurements { get; set; }
        public Nullable<int> DressSize { get; set; }
        public Nullable<int> Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Availability { get; set; }
        public Nullable<int> Location { get; set; }
        public string Orientation { get; set; }
        public string FavouritePerfume { get; set; }
        public string FavouriteCuisine { get; set; }
        public string UKtravel { get; set; }
        public bool UKtravelupdate { get; set; }
        public HttpPostedFileBase attachment { get; set; }
        public List<images> ImagesList { get; set; }
        public string BannerImage { get; set; }
        public string LogoGuid { get; set; }
        public string Description { get; set; }

    }
    public class images
    {
        public string OtherImages { get; set; }

    }
}