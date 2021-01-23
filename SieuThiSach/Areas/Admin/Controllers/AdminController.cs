using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SieuThiSach.Models;

namespace SieuThiSach.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /Admin/Admin/
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTKAD"].ToString();
            string sMatKhau = f["txtMKAD"].ToString();
            QUANTRIADMIN qtad = db.QUANTRIADMINs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (qtad != null)
            {
                Session["Admin"] = qtad;
                return RedirectToAction("Index", "QuanLySanPham");

            }
            ViewBag.ThongBao = "Sai tài khoản hoặc mật khẩu.Vui lòng đăng nhập lại.";
            return View();
        }
        public PartialViewResult HienThiTKADPartial()
        {
            QUANTRIADMIN ad = (QUANTRIADMIN)Session["Admin"];
            if (ad == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.HoTen = ad.TenAD;
            return PartialView();
        }
        public ActionResult DangXuat()
        {
            QUANTRIADMIN ad = (QUANTRIADMIN)Session["Admin"];
            if (ad != null)
            {
                Session["Admin"] = null;
                return RedirectToAction("DangNhap");
            }
            return RedirectToAction("DangNhap");
        }
	}
}