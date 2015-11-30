using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Models.ViewModels;

namespace TDMT_DOAN.Controllers
{
    public class CartController : Controller
    {
        public TMDT_DB3Entities db = new TMDT_DB3Entities();
        //
        // GET: /Cart/
        [ChildActionOnly]
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult CartContent()
        {
            string username = SessionHelper.GetUserSession();
            if (username != null)
            {
                if (SessionHelper.GetCartSession(username) == null)
                {
                    return View();
                }
                else
                {
                  
                    List<CartSession> cartsessionlist = SessionHelper.GetCartSession(username);
                    return View(cartsessionlist);

                }
            }

            return View();

        }

        public ActionResult AddCart(string id)
        {
            string username = SessionHelper.GetUserSession();
            if (username != null)
            {
                if (SessionHelper.GetCartSession(username) == null)
                {
                    CartSession cartsession = new CartSession();
                    cartsession.sp = db.SANPHAMs.Where(sp => sp.MA.Equals(id) && sp.DAXOA.Value.Equals(false) && sp.SANPHAMBAN.Value.Equals(true)).SingleOrDefault();
                    cartsession.soluong = 1;
                    List<CartSession> cartsessionlist = new List<CartSession>();
                    cartsessionlist.Add(cartsession);
                    SessionHelper.SetCartSession(username, cartsessionlist);
                }
                else
                {
                    CartSession cartsession = new CartSession();
                    cartsession.sp = db.SANPHAMs.Where(sp => sp.MA.Equals(id) && sp.DAXOA.Value.Equals(false) && sp.SANPHAMBAN.Value.Equals(true)).SingleOrDefault();
                    cartsession.soluong = 1;
                    List<CartSession> cartsessionlist = SessionHelper.GetCartSession(username);
                    cartsessionlist.Add(cartsession);
                    SessionHelper.SetCartSession(username, cartsessionlist);

                }
            }

            return RedirectToAction("Index", "Home");
        }

    }
}