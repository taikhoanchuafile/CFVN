using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SieuThiSach.Models.Metadata
{
     [MetadataTypeAttribute(typeof(THAMGIAMetadata))]
    public partial class THAMGIA
    {
         internal sealed class THAMGIAMetadata
         {
             [Display(Name = "Mã sách")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             public int Masach { get; set; }

             [Display(Name = "Mã tác giả")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             public int MaTG { get; set; }

             [Display(Name = "Vai trò")]
             [Required(ErrorMessage = "{0} không được rỗng")]
             public string Vaitro { get; set; }
         }
    }
}