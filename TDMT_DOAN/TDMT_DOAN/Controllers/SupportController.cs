using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TDMT_DOAN.Controllers
{
    public class SupportController : Controller
    {
        //
        // GET: /Support/
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Newsletter()
        {
            return PartialView();
        }
	}
}