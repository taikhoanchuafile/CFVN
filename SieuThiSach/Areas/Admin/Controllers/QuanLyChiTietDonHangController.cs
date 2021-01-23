using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SieuThiSach.Models;
using PagedList;
using PagedList.Mvc;

namespace SieuThiSach.Areas.Admin.Controllers
{
    public class QuanLyChiTietDonHangController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /Admin/QuanLyChiTietDonHang/
        public ActionResult Index(int ? page)
        {
            QUANTRIADMIN qt = (QUANTRIADMIN)Session["Admin"];
            if (qt == null || qt.ToString() == "")
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.CTDATHANGs.OrderBy(m => m.SoDH).ToList().ToPagedList(pageNumber, pageSize));
        }
	}
}