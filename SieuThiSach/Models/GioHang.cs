using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SieuThiSach.Models
{
    public class GioHang
    {
        QLBansachEntities db = new QLBansachEntities();
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien { get{ return iSoLuong * dDonGia;} }
        public GioHang(int masach)
        {
            iMaSP = masach;
            SACH sach = db.SACHes.Single(m => m.Masach == iMaSP);
            sTenSP = sach.Tensach;
            dDonGia = double.Parse(sach.Dongia.ToString());
            iSoLuong = 1;
        }
    }
}