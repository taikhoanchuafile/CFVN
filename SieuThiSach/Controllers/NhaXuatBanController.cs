using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SieuThiSach.Models;

namespace SieuThiSach.Controllers
{
    public class NhaXuatBanController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /NhaXuatBan/
        public PartialViewResult NhaXuatBanPartial()
        {
            List<NHAXUATBAN> nxb = db.NHAXUATBANs.OrderBy(n=>n.TenNXB).ToList();
            return PartialView(nxb);
        }
        public ActionResult SachTheoNXB(int manxb)
        {
            NHAXUATBAN nxb = db.NHAXUATBANs.SingleOrDefault(m => m.MaNXB == manxb);
            if (nxb == null)
            {
                ViewBag.ThongBao = "Không tìm thấy sách loại này!";
                return View();
            }
            List<SACH> sach = db.SACHes.Where(n => n.MaNXB == manxb).ToList();
            return View(sach);
        }
	}
}