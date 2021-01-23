using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SieuThiSach.Models
{
    [MetadataTypeAttribute(typeof(TACGIAMetadata))]
    public partial class TACGIA
    {
        internal sealed class TACGIAMetadata
        {
            [Display(Name="Mã tác giả")]
            public int MaTG { get; set; }

             [Display(Name = "Tên tác giả")]
             [Required(ErrorMessage = "{0} không được rỗng")]
            public string TenTG { get; set; }

             [Display(Name = "Địa chỉ tác giả")]
             [Required(ErrorMessage = "{0} không được rỗng")]
            public string DiachiTG { get; set; }

             [Display(Name = "Điện thoại tác giả")]
             [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage="{0} không hợp lệ")]
             [Required(ErrorMessage = "{0} không được rỗng")]
            public string DienthoaiTG { get; set; }
        }
    }
}