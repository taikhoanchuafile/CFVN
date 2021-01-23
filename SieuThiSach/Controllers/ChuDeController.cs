using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SieuThiSach.Models;

namespace SieuThiSach.Controllers
{
    public class ChuDeController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /ChuDe/
        public PartialViewResult ChuDePartial()
        {
            List<CHUDE> cd = db.CHUDEs.OrderBy(n=>n.Tenchude).ToList();
            return PartialView(cd);
        }
        public ActionResult SachTheoChuDe(int machude)
        {
            CHUDE cd = db.CHUDEs.SingleOrDefault(m => m.MaCD == machude);
            if(cd == null)
            {
                ViewBag.ThongBao = "Không tìm thấy sách loại này!";
                return View();
            }
            List<SACH> sach = db.SACHes.Where(n=>n.MaCD == machude).ToList();
            return View(sach);
        }
	}
}