using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SieuThiSach.Models;
//Thêm thư viện gửi mail
using System.Net.Mail;
using System.Net;

namespace SieuThiSach.Controllers
{
    public class GioHangController : Controller
    {
        QLBansachEntities db = new QLBansachEntities();
        //
        // GET: /GioHang/
        
        #region Giỏ Hàng
        //Lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hảng chưa tồn tại thì mình tiến hành khởi tạo list giỏ hàng(SessionGioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMaSach, string strURL) //biến strURL giữ đường link của trang để khi mua hàng nó sẽ không nhảy qua trang khác mà chỉ thêm sản phẩm vào giỏ hàng
        {
            //kiểm tra xem mã sách truyền vào có giống như mã sách trong csdl hay không?
            SACH sach = db.SACHes.SingleOrDefault(m => m.Masach == iMaSach);
            //nếu truyền sai thì báo lỗi 404
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();

            //Kiểm tra sách này đã tồn tại trong Session["GioHang"] hay chưa
            GioHang sanpham = lstGioHang.Find(n => n.iMaSP == iMaSach);

            //nếu giỏ hàng không tồn tại sản phẩm nào
            if (sanpham == null)
            {
                //thì HỆ THỐNG sẽ khởi tạo giỏ hàng
                sanpham = new GioHang(iMaSach);
                //add sản phẩm mới thêm vào list
                lstGioHang.Add(sanpham);
                //truyền link vào thông qua Redirect(strURL)
                return Redirect(strURL);
            }
            else
            {
                //Giỏ hàng đã có sản phẩm thì HỆ THỐNG sẽ cộng thêm lên
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }

        //Cập nhật giỏ hàng
        public ActionResult CapNhatGioHang(int iMaSach, FormCollection f)
        {
            //kiểm tra xem mã sách truyền vào có giống như mã sách trong csdl hay không?
            SACH sach = db.SACHes.SingleOrDefault(m => m.Masach == iMaSach);
            //nếu truyền sai thì trả về trang lỗi 404
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng từ Session["GioHang"]
            List<GioHang> lstGioHang = LayGioHang();

            //Kiểm tra xem sản phẩm có tồn tại trong Session["GioHang"] hay chưa
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSP == iMaSach);

            //Nếu tồn tại thì chúng ta cho NGƯỜI DÙNG sửa
            if (sanpham != null)
            {
                ViewBag.ThongBao = "Cập nhật thành công.";
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        //Xóa giỏ hàng 
        public ActionResult XoaGioHang(int iMaSach)
        {
            //kiểm tra xem mã sách truyền vào có giống như mã sách trong csdl hay không?
            SACH sach = db.SACHes.SingleOrDefault(m => m.Masach == iMaSach);
            //nếu truyền sai thì báo lỗi 404
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            //Lấy giỏ hàng từ Session["GioHang"]
            List<GioHang> lstGioHang = LayGioHang();

            //Kiểm tra xem sản phẩm có tồn tại trong Session["GioHang"] hay chưa
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSP == iMaSach);

            //Nếu tồn tại thì chúng ta cho NGƯỜI DÙNG xóa
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSP == iMaSach);
            }
            //Nếu giỏ hàng không còn gì thì về trang chủ
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }

        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }

        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return dTongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //xây dựng 1 view cho người dùng chỉnh sữa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //Xóa toàn bộ giỏ hàng
        public ActionResult XoaToanBo()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (Session["GioHang"] != null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return RedirectToAction("Index","Home");
        }
        #endregion

        #region Đặt hàng
        [HttpGet]
        public ActionResult ThongTinDonHang()
        {

           
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            KHACHHANG kh = (KHACHHANG)Session["TaiKhoan"];
            ViewBag.HoTen = kh.HotenKH;
            ViewBag.DiaChi = kh.DiachiKH;
            ViewBag.DienThoai = kh.DienthoaiKH;
            ViewBag.Email = kh.Email;

            ViewBag.TongTien = TongTien();
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang() ;
            ViewBag.lstGioHang = lstGioHang;

            return View();
           
        }
        [HttpPost]
        public ActionResult ThongTinDonHang(DONDATHANG ddh)
        {


            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            KHACHHANG kh = (KHACHHANG)Session["TaiKhoan"];
            //ViewBag.HoTen = kh.HotenKH;
            //ViewBag.DiaChi = kh.DiachiKH;
            //ViewBag.DienThoai = kh.DienthoaiKH;
            //ViewBag.Email = kh.Email;


            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.TongTien = TongTien();
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.lstGioHang = lstGioHang;

            if(ModelState.IsValid)
            {
                DONDATHANG donhang = new DONDATHANG();
                donhang.MaKH = kh.MaKH;
                donhang.Ngaydathang = DateTime.Now;
                donhang.Ngaygiaohang = ddh.Ngaygiaohang;
                donhang.Tennguoinhan = ddh.Tennguoinhan;
                donhang.Diachinhan = ddh.Diachinhan;
                donhang.Dienthoainhan = ddh.Dienthoainhan;
                donhang.HTThanhtoan = ddh.HTThanhtoan;
                donhang.HTGiaohang = ddh.HTGiaohang;
                donhang.Trigia = (decimal)ViewBag.TongTien;
                db.DONDATHANGs.Add(donhang);

                foreach (var item in lstGioHang)
                {
                    CTDATHANG ctdh = new CTDATHANG();
                    ctdh.SoDH = ddh.SoDH;
                    ctdh.Masach = item.iMaSP;
                    ctdh.Soluong = item.iSoLuong;
                    ctdh.Dongia = item.dDonGia;
                    ctdh.Thanhtien = item.dThanhTien;
                    db.CTDATHANGs.Add(ctdh);
                }
                db.SaveChanges();

                ////gửi mail 
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/Email.html"));
                content = content.Replace("{{HoTen}}",kh.HotenKH);
                content = content.Replace("{{DienThoai}}", kh.DienthoaiKH);
                content = content.Replace("{{Email}}", kh.Email);
                content = content.Replace("{{DiaChi}}", kh.DiachiKH);
                content = content.Replace("{{SoLuong}}",""+TongSoLuong());
                content = content.Replace("{{TriGia}}", TongTien().ToString());
                SendMail("Đơn hàng mới từ ShopABC", content);
                //MailMessage mm = new MailMessage("vu654987@gmail.com",kh.Email);
                //mm.Subject ="Đơn đặt hàng";
                //mm.Body ="Họ và tên khách hàng:" + kh.HotenKH + "\nEmail:"+kh.Email+"\nĐịa chỉ:"+kh.DiachiKH+"Số điện thoại:"+kh.DienthoaiKH;
                //mm.IsBodyHtml = true;

                //SmtpClient sc = new SmtpClient();
                //sc.Host = "smtp.gmail.com";
                //sc.Port = 587;
                //sc.EnableSsl = true;

                //NetworkCredential nc = new NetworkCredential("vu654987@gmail.com", "asdasd0003");
                //sc.UseDefaultCredentials = true;
                //sc.Credentials = nc;
                //sc.Send(mm);

                return RedirectToAction("XacNhanDonHang");
            }
            return View();

        }
        //xây dựng phương thức gửi mail
        public void SendMail(string subject,string body)
        {
            KHACHHANG kh = Session["TaiKhoan"] as KHACHHANG;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("vu654987@gmail.com");
            mm.To.Add(new MailAddress(kh.Email));
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = !string.IsNullOrEmpty(""+587) ? Convert.ToInt32(587) : 0;
            client.Credentials = new NetworkCredential("vu654987@gmail.com", "asdasd0003");
            client.EnableSsl = true;
            client.Send(mm);
        }
        public ActionResult XacNhanDonHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        #endregion

    }
}