using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SieuThiSach.Models
{
    [MetadataTypeAttribute(typeof(KHACHHANGMetadata))]
    public partial class KHACHHANG
    {
        internal sealed class KHACHHANGMetadata
        {
            [Display(Name = "Mã khách hàng")]
            public int MaKH { get; set; }

             [Display(Name = "Họ tên khách hàng")]
             [Required(ErrorMessage = "{0} không được rỗng")]
            public string HotenKH { get; set; }

             [Display(Name = "Địa chỉ khách hàng")]
             [Required(ErrorMessage = "{0} không được rỗng")]
            public string DiachiKH { get; set; }

             [Display(Name = "Điện thoại khách hàng")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "{0} không hợp lệ")]
            public string DienthoaiKH { get; set; }

             [Display(Name = "Tên đăng nhập")]
             [Required(ErrorMessage = "{0} không được rỗng")]
            public string TenDN { get; set; }

             [Display(Name = "Mật khẩu")]
             [Required(ErrorMessage = "{0} không được rỗng")]
            public string Matkhau { get; set; }

             [Display(Name = "Ngày sinh")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             [DataType(DataType.Date)]
             [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}",NullDisplayText="Sai cmnr")]
            public Nullable<System.DateTime> Ngaysinh { get; set; }

             [Display(Name = "Giới tính")]
             [Required(ErrorMessage = "{0} không được rỗng")]
            public bool Gioitinh { get; set; }

             [Display(Name = "Email khách hàng")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",ErrorMessage="{0} không hợp lệ")]
            public string Email { get; set; }
        }
    }
}