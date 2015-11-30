using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace TDMT_DOAN.Models.ViewModels
{
    public class HomeList
    {
        public List<SANPHAM> newList { get; set; }
        public List<float> newListPromotion { get; set; }
        public List<SANPHAM> specialList { get; set; }
        public List<float> specialListPromotion { get; set; }

        public HomeList()
        {
            newList = new List<SANPHAM>();   
            newListPromotion = new List<float>();
            specialList = new List<SANPHAM>();
            specialListPromotion = new List<float>();

        }
    }
}