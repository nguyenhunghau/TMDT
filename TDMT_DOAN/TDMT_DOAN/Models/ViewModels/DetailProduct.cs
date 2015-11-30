using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Models.ViewModels
{
    public class DetailProduct
    {
        public SANPHAM detailProduct { get; set; }
        public float detailProductPromotion { get; set; }
        public string manufactoryName { get; set; }
        public string typeProduct { get; set; }
        public List<SANPHAM> relativeList { get; set; }
        public List<float> relativeListPromotion { get; set; }

        public List<string> subjectDescription { get; set; }
        public List<string> contentDescription { get; set; }

        public DetailProduct()
        {
            detailProduct = new SANPHAM();
            detailProductPromotion = 0;
            manufactoryName = "";
            typeProduct = "";
            relativeList = new List<SANPHAM>();
            relativeListPromotion = new List<float>();
            subjectDescription = new List<string>();
            contentDescription = new List<string>();
        }
    }
}