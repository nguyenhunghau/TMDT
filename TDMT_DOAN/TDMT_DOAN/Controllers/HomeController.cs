using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Models.ViewModels;
using PagedList;
using System.Web.Mvc.Html;

namespace TDMT_DOAN.Controllers
{
    public class HomeController : Controller
    {

        public TMDT_DB3Entities db = new TMDT_DB3Entities();


        public ActionResult Index()
        {
            HomeList homeList = new HomeList();
         
            //New list
            homeList.newList = db.SANPHAMs.Where(sp => sp.DAXOA.Value.Equals(false) && sp.SANPHAMBAN.Value.Equals(true) && sp.SANPHAMMOI.Value.Equals(true)).ToList();
            for (int i = 0; i < homeList.newList.Count; i++)
            {
                int makhuyenmai = homeList.newList[i].MAKHUYENMAI.Value;
                if ( makhuyenmai != 0)
                {
                    var _mkm = db.KHUYENMAIs.Where(km => km.DAXOA.Value.Equals(false) && km.MA.Equals(makhuyenmai)).SingleOrDefault();
                    float dongiagiam = (float)(homeList.newList[i].DONGIABAN * (100 - _mkm.NOIDUNG.Value)) / 100;
                    homeList.newListPromotion.Add(dongiagiam);
                }
                else
                {
                    homeList.newListPromotion.Add(0);
                }
            }
            
            //Special List
            homeList.specialList = db.SANPHAMs.Where(sp => sp.DAXOA.Value.Equals(false) && sp.SANPHAMBAN.Value.Equals(true) && sp.SANPHAMBANCHAY.Value.Equals(true)).ToList();
            for (int i = 0; i < homeList.specialList.Count; i++)
            {
                int makhuyenmai = homeList.specialList[i].MAKHUYENMAI.Value;
                if (makhuyenmai != 0)
                {
                    var _mkm = db.KHUYENMAIs.Where(km => km.DAXOA.Value.Equals(false) && km.MA.Equals(makhuyenmai)).SingleOrDefault();
                    float dongiagiam = (float)(homeList.specialList[i].DONGIABAN * (100 - _mkm.NOIDUNG.Value)) / 100;
                    homeList.specialListPromotion.Add(dongiagiam);
                }
                else
                {
                    homeList.specialListPromotion.Add(0);
                }
            }

           

            return View(homeList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
    }
}