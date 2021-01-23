using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SieuThiSach.Models
{
     [MetadataTypeAttribute(typeof(QUANGCAOMetadata))]
    public partial class QUANGCAO
    {
         internal sealed class QUANGCAOMetadata
         {
             [Display(Name = "Số thứ tự")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             public int STT { get; set; }

             [Display(Name = "Tên công ty")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             public string TenCTy { get; set; }

             [Display(Name = "Hình minh họa")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             public string HinhMinhHoa { get; set; }

             [Display(Name = "Link quảng cáo")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             public string HREF { get; set; }

             [Display(Name = "Ngày bắt đầu")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             [DataType(DataType.Date)]
             [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
             public Nullable<System.DateTime> Ngaybatdau { get; set; }

             [Display(Name = "Ngày kết thúc")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             [DataType(DataType.Date)]
             [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
             public Nullable<System.DateTime> Ngayhethan { get; set; }
         }
    }
}