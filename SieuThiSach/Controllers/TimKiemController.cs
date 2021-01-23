using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SieuThiSach.Models;

namespace SieuThiSach.Controllers
{
    public class TimKiemController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /TimKiem/
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f)
        {
            string sTuKhoa = f["tsearch"].ToString();
            List<SACH> lstSach = db.SACHes.Where(n => n.Tensach.Contains(sTuKhoa)).ToList();
            if(lstSach.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy.";
                return View(lstSach);
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstSach.Count + " kết quả.";
            return View(lstSach);
        }
	}
}