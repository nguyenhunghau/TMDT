using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Models.ViewModels;

namespace TDMT_DOAN.Controllers
{
    public class ManufactoryController : Controller
    {

        public TMDT_DB3Entities db = new TMDT_DB3Entities();
        //
        // GET: /manufactory/
        [ChildActionOnly]
        public ActionResult Index()
        {
            ManufactoryList manufactoryList = new ManufactoryList();
            manufactoryList.listNhaSanXuat = db.NHASANXUATs.Where(nsx => nsx.DAXOA.Value.Equals(false)).ToList();
            return PartialView(manufactoryList);
        }
	}
}