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
    
    public partial class LOAITHANHVIEN
    {
        public LOAITHANHVIEN()
        {
            this.THANHVIENs = new HashSet<THANHVIEN>();
        }
    
        public int LoaiTV { get; set; }
        public string TENLOAI { get; set; }
        public Nullable<bool> DAXOA { get; set; }
    
        public virtual ICollection<THANHVIEN> THANHVIENs { get; set; }
    }
}
