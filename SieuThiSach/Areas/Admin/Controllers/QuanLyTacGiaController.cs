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
    public class QuanLyTacGiaController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /Admin/TacGia/
        public ActionResult Index(int ? page)
        {
            QUANTRIADMIN qt = (QUANTRIADMIN)Session["Admin"];
            if (qt == null || qt.ToString() == "")
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.TACGIAs.OrderBy(m => m.MaTG).ToList().ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(TACGIA tg)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ThongBao = "Thêm mới tác giả thành công.";
                db.TACGIAs.Add(tg);
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSua(int matacgia)
        {
            TACGIA tg = db.TACGIAs.SingleOrDefault(n => n.MaTG == matacgia);
            if (tg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tg);
        }
        [HttpPost]
        public ActionResult ChinhSua(TACGIA tg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tg).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tg); 
        }
        public ActionResult HienThi(int matacgia)
        {
            TACGIA tg = db.TACGIAs.SingleOrDefault(n => n.MaTG == matacgia);
            if (tg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tg);
        }
        [HttpGet]
        public ActionResult Xoa(int matacgia)
        {
            TACGIA tg = db.TACGIAs.SingleOrDefault(n => n.MaTG == matacgia);
            if (tg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tg);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int matacgia)
        {
            TACGIA tg = db.TACGIAs.SingleOrDefault(n => n.MaTG == matacgia);
            if (tg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.TACGIAs.Remove(tg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}