using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SieuThiSach.Models;
using System.IO;
using PagedList;
using PagedList.Mvc;

namespace SieuThiSach.Areas.Admin.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /Admin/QuanLySanPham/
        public ActionResult Index(int ? page)
        {
            QUANTRIADMIN qt = (QUANTRIADMIN)Session["Admin"];
            if(qt == null || qt.ToString() == "")
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.SACHes.OrderBy(m => m.Masach).ToList().ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            
            ViewBag.MaCD = new SelectList(db.CHUDEs.OrderBy(n => n.Tenchude).ToList(), "MaCD", "Tenchude");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.OrderBy(n => n.TenNXB).ToList(), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(SACH sach,HttpPostedFileBase fileUpload)
        {
            ViewBag.MaCD = new SelectList(db.CHUDEs.OrderBy(n => n.Tenchude).ToList(), "MaCD", "Tenchude");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.OrderBy(n => n.TenNXB).ToList(), "MaNXB", "TenNXB");
            if(fileUpload == null)
            {
                ViewBag.ThongBao = "Chưa nhập file hình.Vui lòng nhập file hình.";
                return View();
            }
            if(ModelState.IsValid)
            {
                var tenFile = Path.GetFileName(fileUpload.FileName);
                var duongDan = Path.Combine(Server.MapPath("~/HinhAnhSP/"),tenFile);
                if(System.IO.File.Exists(duongDan))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    return View();
                }
                else
                {
                    ViewBag.ThongBaoTC = "Thêm thành công";
                    fileUpload.SaveAs(duongDan);
                }
                sach.Hinhminhhoa = fileUpload.FileName;
                db.SACHes.Add(sach);
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSua(int masach)
        {

            SACH sach = db.SACHes.SingleOrDefault(n => n.Masach == masach);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaCD = new SelectList(db.CHUDEs.OrderBy(n => n.Tenchude).ToList(), "MaCD", "Tenchude",sach.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.OrderBy(n => n.TenNXB).ToList(), "MaNXB", "TenNXB",sach.MaNXB);
            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(SACH sach)
        {
            ViewBag.MaCD = new SelectList(db.CHUDEs.OrderBy(n => n.Tenchude).ToList(), "MaCD", "Tenchude", sach.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.OrderBy(n => n.TenNXB).ToList(), "MaNXB", "TenNXB", sach.MaNXB);
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sach);
           
        }
        public ActionResult HienThi(int masach)
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.Masach == masach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpGet]
        public ActionResult Xoa(int masach)
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.Masach == masach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(int masach)
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.Masach == masach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SACHes.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}