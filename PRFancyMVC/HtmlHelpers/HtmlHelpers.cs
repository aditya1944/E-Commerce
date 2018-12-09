using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRFancyMVC.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Images(this HtmlHelper htmlHelper, string id, string alt, int num)
        {
            var urlHelper = ((Controller)htmlHelper.ViewContext.Controller).Url;
            var photoUrl = urlHelper.Action("GetPhoto", "Admin", new { productId = id,i = num });
            var img = new TagBuilder("img");
            img.MergeAttribute("src", photoUrl);
            img.MergeAttribute("alt", alt);
            img.MergeAttribute("class", "image");
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }
    }
}