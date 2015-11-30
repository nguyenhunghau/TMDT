using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Models.ViewModels;

namespace TDMT_DOAN.Controllers
{
    public class ProductController : Controller
    {

        public TMDT_DB3Entities db = new TMDT_DB3Entities();
        // GET: Product
        public ActionResult Index(string name , int id)
        {

            ProductList productList = new ProductList();

            if (name.Equals("Default")) //hiển thị tất cả sản phẩm
            {
                productList.productList = db.SANPHAMs.Where(sp => sp.DAXOA.Value.Equals(false) && sp.SANPHAMBAN.Value.Equals(true)).ToList();
            }

            if (name.Equals("Category")) //lấy theo category
            {
                var category = db.LOAISANPHAMs.Where(lsp => lsp.MA == id && lsp.DAXOA.Value.Equals(false)).SingleOrDefault();
                productList.path = category.TEN;
                productList.productList = db.SANPHAMs.Where(sp => sp.DAXOA.Value.Equals(false) && sp.SANPHAMBAN.Value.Equals(true) && sp.LOAISANPHAM == id).ToList();
            }

            if (name.Equals("Manufactory")) //lấy theo nhà sản xuất
            {
                var manufactory = db.NHASANXUATs.Where(nsx => nsx.MA == id && nsx.DAXOA.Value.Equals(false)).SingleOrDefault();
                productList.path = manufactory.TEN;
                productList.productList = db.SANPHAMs.Where(sp => sp.DAXOA.Value.Equals(false) && sp.SANPHAMBAN.Value.Equals(true) && sp.NHASANXUAT == id).ToList();
            }


            for (int i = 0; i < productList.productList.Count; i++)
            {
                int makhuyenmai = productList.productList[i].MAKHUYENMAI.Value;
                if (makhuyenmai != 0)
                {
                    var _mkm = db.KHUYENMAIs.Where(km => km.DAXOA.Value.Equals(false) && km.MA.Equals(makhuyenmai)).SingleOrDefault();
                    float dongiagiam = (float)(productList.productList[i].DONGIABAN * (100 - _mkm.NOIDUNG.Value)) / 100;
                    productList.productListPromotion.Add(dongiagiam);
                }
                else
                {
                    productList.productListPromotion.Add(0);
                }
            }
            return View(productList);
        }
        public ActionResult Details(string id) // nhan id de biet dang hien thi detail san pham nao
        {
            DetailProduct detailProduct = new DetailProduct();

            //xu ly cho 1 san pham
            detailProduct.detailProduct = db.SANPHAMs.Where(sp => sp.MA.Equals(id) && sp.DAXOA.Value.Equals(false) && sp.SANPHAMBAN.Value.Equals(true)).SingleOrDefault();
            int makhuyenmai = detailProduct.detailProduct.MAKHUYENMAI.Value;
            if (makhuyenmai != 0)
            {
                var _mkm = db.KHUYENMAIs.Where(km => km.DAXOA.Value.Equals(false) && km.MA.Equals(makhuyenmai)).SingleOrDefault();
                float dongiagiam = (float)(detailProduct.detailProduct.DONGIABAN * (100 - _mkm.NOIDUNG.Value)) / 100;
                detailProduct.detailProductPromotion = dongiagiam;
            }
            else
            {
                detailProduct.detailProductPromotion = 0;
            }

            int manhasanxuat = detailProduct.detailProduct.NHASANXUAT.Value;
            var nhasanxuat = db.NHASANXUATs.Where(nsx => nsx.DAXOA.Value.Equals(false) && nsx.MA.Equals(manhasanxuat) ).SingleOrDefault();
            detailProduct.manufactoryName = nhasanxuat.TEN;

            int maloaisanpham = detailProduct.detailProduct.LOAISANPHAM.Value;
            var loaisanpham = db.LOAISANPHAMs.Where(lsp => lsp.DAXOA.Value.Equals(false) && lsp.SANPHAMBAN.Value.Equals(true) && lsp.MA.Equals(maloaisanpham)).SingleOrDefault();
            detailProduct.typeProduct = loaisanpham.TEN;


            //tach chuoi lay mo ta
            /*
            string mota = detailProduct.detailProduct.MOTA;
            string[] arrListStr = mota.Split('-');
            foreach (var item in arrListStr)
            {
                if (!item.Equals(""))
                {

                }
            }
             */



            //xu ly cho san pham lien quan
            //xu ly cho 1 san pham
            int _loaisanpham = detailProduct.detailProduct.LOAISANPHAM.Value;
            string _madetail = detailProduct.detailProduct.MA;
            detailProduct.relativeList = db.SANPHAMs.Where(sp => sp.LOAISANPHAM.Value == _loaisanpham && !sp.MA.Equals(_madetail) && sp.DAXOA.Value.Equals(false) && sp.SANPHAMBAN.Value.Equals(true)).Take(3).ToList() ;

            for (int i = 0; i < detailProduct.relativeList.Count; i++)
            {
                int mkm = detailProduct.relativeList[i].MAKHUYENMAI.Value;
                if (mkm != 0)
                {
                    var _mkm_tt = db.KHUYENMAIs.Where(km => km.DAXOA.Value.Equals(false) && km.MA.Equals(makhuyenmai)).SingleOrDefault();
                    float dgg = (float)(detailProduct.relativeList[i].DONGIABAN * (100 - _mkm_tt.NOIDUNG.Value)) / 100;
                    detailProduct.relativeListPromotion.Add(dgg);
                }
                else
                {
                    detailProduct.relativeListPromotion.Add(0);
                }
            }


            return View(detailProduct);
        }

        [ChildActionOnly]
        public ActionResult NewProduct()
        {
            return PartialView();
        }


        [ChildActionOnly]
        public ActionResult SpecialProduct()
        {
            return PartialView();
        }

        
    }
}