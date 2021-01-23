using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SieuThiSach.Models
{
    [MetadataTypeAttribute(typeof(DONDATHANGMetadata))]
    public partial class DONDATHANG
    {
        internal sealed class DONDATHANGMetadata
        {
            [Display(Name = "Số đơn hàng")]
            public int SoDH { get; set; }

            [Display(Name = "Mã khách hàng")]
            public Nullable<int> MaKH { get; set; }

            [Display(Name = "Ngày đặt hàng")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
            public Nullable<System.DateTime> Ngaydathang { get; set; }

            [Display(Name = "Ngày giao hàng")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
            public Nullable<System.DateTime> Ngaygiaohang { get; set; }

            [Display(Name = "Tên người nhận")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public string Tennguoinhan { get; set; }

            [Display(Name = "Địa chỉ người nhận")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public string Diachinhan { get; set; }

            [Display(Name = "Điện thoại người nhận")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "{0} không hợp lệ")]
            public string Dienthoainhan { get; set; }

            [Display(Name = "Hình thức thành toán")]
            public Nullable<bool> HTThanhtoan { get; set; }

            [Display(Name = "Hình thức giao hàng")]
            public Nullable<bool> HTGiaohang { get; set; }

            [Display(Name = "Trị giá")]
            public Nullable<decimal> Trigia { get; set; }

            [Display(Name = "Đã giao hàng")]
            public bool Dagiaohang { get; set; }
        }
    }
}