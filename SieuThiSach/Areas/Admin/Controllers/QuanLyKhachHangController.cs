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
    public class QuanLyKhachHangController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /Admin/KhachHang/
        public ActionResult Index(int ? page)
        {
            QUANTRIADMIN qt = (QUANTRIADMIN)Session["Admin"];
            if (qt == null || qt.ToString() == "")
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.KHACHHANGs.OrderBy(m => m.MaKH).ToList().ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ThongBao = "Thêm mới khách hàng thành công.";
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSua(int makh)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost]
        public ActionResult ChinhSua(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kh);
        }
        public ActionResult HienThi(int makh)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpGet]
        public ActionResult Xoa(int makh)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int makh)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KHACHHANGs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}