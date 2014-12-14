using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutionWeb1.Helpers
{
    public static class MyHtmlHelpers
    {
        public static MvcHtmlString LoadingIcon(this System.Web.Mvc.HtmlHelper helper, string Id,string style)
        {
            return new MvcHtmlString(String.Format("<img src='/Images/loading.gif' id='{0}' style='{1}'/>", Id,style));

        }
    }
}