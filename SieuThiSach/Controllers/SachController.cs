using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SieuThiSach.Models;

namespace SieuThiSach.Controllers
{
    public class SachController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /Sach/
        public PartialViewResult SachBanChayPartial()
        {
            List<SACH> sach = db.SACHes.OrderBy(n => n.Soluongban).Take(4).ToList();
            return PartialView(sach);
        }
        public ActionResult XemChiTiet(int masach)
        {
            SACH sach = db.SACHes.SingleOrDefault(m => m.Masach == masach);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
	}
}