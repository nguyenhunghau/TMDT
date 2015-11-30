using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Models.ViewModels
{
    public class MenuList
    {
        public List<LOAISANPHAM> listDanhMuc { get; set; }

        public MenuList()
        {
            listDanhMuc = new List<LOAISANPHAM>();
        }
    }
}