using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SieuThiSach.Models
{
    [MetadataTypeAttribute(typeof(CTDATHANGMetadata))]
    public partial class CTDATHANG
    {
        internal sealed class CTDATHANGMetadata
        {
            [Display(Name = "Số đơn hàng")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public int SoDH { get; set; }

            [Display(Name = "Mã sách")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public int Masach { get; set; }

            [Display(Name = "Số lượng")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public Nullable<int> Soluong { get; set; }

            [Display(Name = "Đơn giá")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public Nullable<double> Dongia { get; set; }

            [Display(Name = "Thành tiền")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public Nullable<double> Thanhtien { get; set; }
        }
    }
}