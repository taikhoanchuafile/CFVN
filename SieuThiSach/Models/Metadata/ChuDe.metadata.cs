using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SieuThiSach.Models
{
    [MetadataTypeAttribute(typeof(CHUDEMetadata))]
    public partial class CHUDE
    {
        internal sealed class CHUDEMetadata
        {
            [Display(Name = "Mã chủ đề")]
            public int MaCD { get; set; }

            [Display(Name = "Tên chủ đề")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public string Tenchude { get; set; }
        }
    }
}