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
    public class QuanLyDonDatHangController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /Admin/DonDatHang/
        public ActionResult Index(int ? page)
        {
            QUANTRIADMIN qt = (QUANTRIADMIN)Session["Admin"];
            if (qt == null || qt.ToString() == "")
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.DONDATHANGs.OrderBy(n=>n.SoDH).ToList().ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs.OrderBy(n => n.HotenKH), "MaKH", "HotenKH");
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(DONDATHANG ddh)
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs.OrderBy(n => n.HotenKH), "MaKH", "HotenKH");
            if (ModelState.IsValid)
            {
                ViewBag.ThongBao = "Thêm mới đơn hàng thành công.";
                db.DONDATHANGs.Add(ddh);
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSua(int maddh)
        {

            DONDATHANG ddh = db.DONDATHANGs.SingleOrDefault(n => n.SoDH == maddh);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs.OrderBy(n => n.HotenKH), "MaKH", "HotenKH");
            return View(ddh);
        }
        [HttpPost]
        public ActionResult ChinhSua(DONDATHANG ddh)
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs.OrderBy(n => n.HotenKH), "MaKH", "HotenKH");
            if (ModelState.IsValid)
            {
                db.Entry(ddh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(ddh);
        }
        public ActionResult HienThi(int maddh)
        {
            DONDATHANG ddh = db.DONDATHANGs.SingleOrDefault(n => n.SoDH == maddh);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ddh);
        }
        [HttpGet]
        public ActionResult Xoa(int maddh)
        {
            DONDATHANG ddh = db.DONDATHANGs.SingleOrDefault(n => n.SoDH == maddh);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ddh);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int maddh)
        {
            List<CTDATHANG> ctdh = db.CTDATHANGs.Where(n => n.SoDH == maddh).ToList();
            if(ctdh.Count > 0)
            {
                ctdh.RemoveAll(n => n.SoDH == maddh);
            }
            DONDATHANG ddh = db.DONDATHANGs.SingleOrDefault(n => n.SoDH == maddh);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DONDATHANGs.Remove(ddh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult SoDH()
        {

            ViewBag.SoLuong = db.DONDATHANGs.ToList().Count;
            return PartialView();
        }
	}
}