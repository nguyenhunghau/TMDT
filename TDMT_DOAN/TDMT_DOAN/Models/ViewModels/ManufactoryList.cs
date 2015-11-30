using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Models.ViewModels
{
    public class ManufactoryList
    {

        public TMDT_DB3Entities db = new TMDT_DB3Entities();
         public List<NHASANXUAT> listNhaSanXuat { get; set; }

         public ManufactoryList()
        {
            listNhaSanXuat = new List<NHASANXUAT>();
        }
    }
}