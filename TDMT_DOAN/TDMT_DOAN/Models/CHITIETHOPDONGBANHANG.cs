//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TDMT_DOAN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHITIETHOPDONGBANHANG
    {
        public int MA { get; set; }
        public string MAHOPDONG { get; set; }
        public string MASANPHAM { get; set; }
        public Nullable<bool> DAXOA { get; set; }
    
        public virtual SANPHAM SANPHAM { get; set; }
    }
}
