using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeukonstChecklistLibDb;

namespace NeukonstChecklistWebHTML.Controllers
{
    public class BaseController : Controller
    {
        protected NeukonstChecklistDataModelContainer db = new NeukonstChecklistDataModelContainer();

        private static String UserIdKey = "UserId";
        public User setUser()
        {

            int? userId = Session[UserIdKey] as int?;
            if (userId == null) return null;
            User res = db.Users.Find(userId);
            if (res == null) return null;
            ViewBag.User = res;
            _LoggedInUser = res;
            return res;

        }
        private User _LoggedInUser = null;
        protected User LoggedInUser => _LoggedInUser ?? setUser();
        protected bool hasUser()
        {
            return LoggedInUser != null;
        }
        protected void setUserId(int userId)
        {
            Session[UserIdKey] = userId;
            ViewBag.Initialen = LoggedInUser.Initialen;
        }
        public bool getRoleAdmin()
        {
            
                return LoggedInUser.Admin;
            
        }

        public string getName()
        {
            if (LoggedInUser != null) {
                return LoggedInUser.Initialen;
            }
            return null;
        }

    }
}