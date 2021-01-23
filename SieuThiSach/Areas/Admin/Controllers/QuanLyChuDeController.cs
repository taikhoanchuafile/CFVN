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
    public class QuanLyChuDeController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /Admin/ChuDe/
        public ActionResult Index(int ? page)
        {
            QUANTRIADMIN qt = (QUANTRIADMIN)Session["Admin"];
            if (qt == null || qt.ToString() == "")
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.CHUDEs.OrderBy(m => m.MaCD).ToList().ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(CHUDE cd)
        {
            if(ModelState.IsValid)
            {
                ViewBag.ThongBao = "Thêm mới chủ đề thành công.";
                db.CHUDEs.Add(cd);
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSua(int machude)
        {

            CHUDE cd = db.CHUDEs.SingleOrDefault(n => n.MaCD == machude);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            
            return View(cd);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(CHUDE cd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cd).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cd);
        }
        public ActionResult HienThi(int machude)
        {
            CHUDE cd = db.CHUDEs.SingleOrDefault(n => n.MaCD == machude);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(cd);
        }
        [HttpGet]
        public ActionResult Xoa(int machude)
        {
            CHUDE cd = db.CHUDEs.SingleOrDefault(n => n.MaCD == machude);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cd);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int machude)
        {
            CHUDE cd = db.CHUDEs.SingleOrDefault(n => n.MaCD == machude);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.CHUDEs.Remove(cd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}