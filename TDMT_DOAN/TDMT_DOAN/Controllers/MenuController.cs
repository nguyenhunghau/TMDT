using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Models.ViewModels;

namespace TDMT_DOAN.Controllers
{
    public class MenuController : Controller
    {

        public TMDT_DB3Entities db = new TMDT_DB3Entities();

        //
        // GET: /Menu/
        [ChildActionOnly]
        public ActionResult Index()
        {
            //Get data from database
            

            //get loai san pham haven't deleted yet and save to sell.
            MenuList menulist = new MenuList();
            menulist.listDanhMuc = db.LOAISANPHAMs.Where(dm => dm.DAXOA.Value.Equals(false) && dm.SANPHAMBAN.Value.Equals(true)).ToList() ;

            return PartialView(menulist);
        }
	}
}