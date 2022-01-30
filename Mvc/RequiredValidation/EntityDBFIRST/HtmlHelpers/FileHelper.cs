using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityDBFIRST.HtmlHelpers
{
    public static class FileHelper
     {
         public static MvcHtmlString file(this HtmlHelper htmlHelper, string cssClassname)
         {

             TagBuilder tag = new TagBuilder("input");
             tag.MergeAttribute("type", "file");
             tag.MergeAttribute("id", "image");
             tag.MergeAttribute("name", "Photo");
             tag.MergeAttribute("class", "cssClassname");

             return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
         }





     }

}