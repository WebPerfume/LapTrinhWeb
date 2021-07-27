using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTrinhWeb.Areas.Admin.code
{
    public class SessionHelper
    {
        public static void SetSession(UserSession s)
        {
            HttpContext.Current.Session["loginSession"] = s;
        }
        public static UserSession GetSession()
        {
            var s = HttpContext.Current.Session["loginSession"];
            if (s == null)
                return null;
            else
            {
                return s as UserSession;
            }
        }
    }
}