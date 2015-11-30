﻿using System.Web.Mvc;

namespace TDMT_DOAN.Areas.B2B
{
    public class B2BAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "B2B";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "B2B_default",
                "B2B/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}