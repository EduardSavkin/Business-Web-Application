﻿using DS3_Sprint1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DS3_Sprint1.Controllers
{
    public abstract class ApplicationBaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    string fullName = user.fullname;
                    ViewData.Add("FullName", fullName);
                }
            }
            base.OnActionExecuted(filterContext);
        }

        public ApplicationBaseController()
        {

        }
    }
}