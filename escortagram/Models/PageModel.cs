using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace escortagram.Models
{
    public class PageModel
    {
        public int PageID { get; set; }
        public string PageName { get; set; }
        public Nullable<int> PageOrder { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public string PageURL { get; set; }
        public List<PageModel> List { get; set; }
    }
}