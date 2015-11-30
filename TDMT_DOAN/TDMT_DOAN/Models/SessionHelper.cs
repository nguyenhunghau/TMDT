using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models.ViewModels;

namespace TDMT_DOAN.Models
{
    public class SessionHelper
    {
        public static string GetUserSession()
        {
            var session = HttpContext.Current.Session["username"];

            if (session == null)
                return null;
            else
            {
                return session as string;
            }
        }

        public static void SetUserSession(string user)
        {
            HttpContext.Current.Session["username"] = user;
        }

        public static List<CartSession> GetCartSession(string username)
        {
            var session = HttpContext.Current.Session[username];

            if (session == null)
                return null;
            else
            {
                return session as List<CartSession>;
            }
        }

        public static void SetCartSession(string username,List<CartSession> listCartSession)
        {
            HttpContext.Current.Session[username] = listCartSession;
        }


    }
}