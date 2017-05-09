using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLThuVien
{
    public static class SessionExtensions
    {
        public static object Pull(this HttpSessionStateBase session, string name)
        {
            var tmp = session[name];
            session.Remove(name);
            return tmp;
        }

        public static bool Has(this HttpSessionStateBase session, string name)
        {
            return session[name] != null;
        }
    }
}