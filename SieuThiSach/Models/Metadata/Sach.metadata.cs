using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SieuThiSach.Models
{
    [MetadataTypeAttribute(typeof(SACHMetadata))]
    public partial class SACH
    {
        internal sealed class SACHMetadata
        {
            [Display(Name="Mã sách")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public int Masach { get; set; }

            [Display(Name = "Tên sách")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public string Tensach { get; set; }

            [Display(Name = "Đơn giá")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public Nullable<int> Dongia { get; set; }

            [Display(Name = "Đơn vị tính")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public string Donvitinh { get; set; }

            [Display(Name = "Mô tả")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public string Mota { get; set; }

            [Display(Name = "Hình minh họa")]
            public string Hinhminhhoa { get; set; }

            [Display(Name = "Mã chủ đề")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public Nullable<int> MaCD { get; set; }

            [Display(Name = "Mã Nhà xuấ bản")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public Nullable<int> MaNXB { get; set; }

            [Display(Name = "Ngày cập nhật")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString="{0:dd/MM/yyy}",ApplyFormatInEditMode=true)]
            public Nullable<System.DateTime> Ngaycapnhat { get; set; }

            [Display(Name = "Số lượng bán")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public Nullable<int> Soluongban { get; set; }

            [Display(Name = "Số lần xem")]
            [Required(ErrorMessage = "{0} không được rỗng")]
            public Nullable<int> Solanxem { get; set; }
        }
    }
}