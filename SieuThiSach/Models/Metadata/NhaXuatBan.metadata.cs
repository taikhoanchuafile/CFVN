using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SieuThiSach.Models
{
    [MetadataTypeAttribute(typeof(NHAXUATBANMetadata))]
    public partial class NHAXUATBAN
    {
        internal sealed class NHAXUATBANMetadata
        {
            [Display(Name = "Mã nhà xuất bản")]
            public int MaNXB { get; set; }

            [Display(Name = "Tên nhà xuất bản")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public string TenNXB { get; set; }

            [Display(Name = "Địa chỉ nhà xuất bản")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public string DiachiNXB { get; set; }

            [Display(Name = "Điện thoại nhà xuất bản")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "{0} không hợp lệ")]
            public string DienthoaiNXB { get; set; }
        }
    }
}