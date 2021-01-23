using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SieuThiSach.Models;
using PagedList;
using PagedList.Mvc;

namespace SieuThiSach.Controllers
{
    public class HomeController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /Home/
        public ActionResult Index(int ? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            IEnumerable<SACH> sach = db.SACHes.ToList().ToPagedList(pageNumber,pageSize);
            return View(sach);
        }
        
        public ActionResult GioiThieu()
        {
            return View();
        }
        
	}
}