using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TDMT_DOAN.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        [ChildActionOnly]
        public ActionResult Index()
        {
            return PartialView();
        }
	}
}