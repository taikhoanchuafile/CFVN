using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SieuThiSach
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DangNhap",
                url: "Dang-nhap",
                defaults: new { controller = "NguoiDung", action = "DangNhap", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DangKy",
                url: "Dang-Ky",
                defaults: new { controller = "NguoiDung", action = "DangKy", id = UrlParameter.Optional }
            );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
