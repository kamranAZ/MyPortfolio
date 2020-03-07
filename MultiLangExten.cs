using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio_CV
{
    public static class MultiLangExten
    {
        public static string Language(this HttpCookieCollection cookie)
            {
            return cookie["kamran"]?.Value;
            }
    }
}