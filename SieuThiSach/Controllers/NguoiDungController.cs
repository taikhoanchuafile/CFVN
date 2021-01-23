using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SieuThiSach.Models;

namespace SieuThiSach.Controllers
{
    public class NguoiDungController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /NguoiDung/
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection f,KHACHHANG kh)
        {
            String sTenDN = f["TenDN"].ToString();
            KHACHHANG s = db.KHACHHANGs.SingleOrDefault(n => n.TenDN == sTenDN);
            if(s!=null)
            {
                ViewBag.TaiKhoan = "Tài khoản đã tồn tại!";
                return View();
            }
            if(ModelState.IsValid)
            {
                ViewBag.ThongBao="Đăng ký thành công";
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
                return View();
            }
            ViewBag.ThongBao = "Đăng ký thất bại";
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string staiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(m => m.TenDN == staiKhoan && m.Matkhau == sMatKhau);
            if(kh == null)
            {
                ViewBag.ThongBao = "Sai tài khoản hoặc mật khẩu";
                return View();
            }
            Session["TaiKhoan"] = kh;
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoiMatKhau(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();
            string sMatKhauMoi = f["txtMatKhauMoi"].ToString();
            string sMatKhauMoiAgain = f["txtMatKhauMoiAgain"].ToString();

            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(m => m.TenDN == sTaiKhoan && m.Matkhau == sMatKhau);
            if (kh == null)
            {
                ViewBag.ThongBao = "Sai tài khoản hoặc mật khẩu";
                return View();
            }
            if(sMatKhauMoi != sMatKhauMoiAgain)
            {
                ViewBag.ThongBao = "Mật khẩu mới không trùng khớp.";
                return View();
            }
            if(ModelState.IsValid)
            {
                ViewBag.ThongBao = "Đổi mật khẩu thành công.";
                kh.Matkhau = sMatKhauMoi;
            }
            db.SaveChanges();
            return View();
        }
        public ActionResult DangXuat()
        {
            if((KHACHHANG)Session["TaiKhoan"]!=null)
            {
                Session["TaiKhoan"] = null;
                Session["GioHang"] = null;
                return RedirectToAction("DangNhap");
            }
            return RedirectToAction("DangNhap");
        }
	}
}