using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomHelper
{
    public static class ViewTestimonial
    {
        public static MvcHtmlString Image(this HtmlHelper htmlHelper,
            string source, string alternativeText)
        {
            //declare the html helper 
            var builder = new TagBuilder("image");
            //hook the properties and add any required logic
            builder.MergeAttribute("src", source);
            builder.MergeAttribute("alt", alternativeText);
            //create the helper with a self closing capability
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}