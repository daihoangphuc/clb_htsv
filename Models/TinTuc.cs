using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLB_HTSV.Models
{
    public class TinTuc
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Mã Tin Tức")]
        public string? MaTinTuc { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tiêu Đề")]
        public string? TieuDe { get; set; }

        [MaxLength]
        [Display(Name = "Nội Dung")]
        public string? NoiDung { get; set; }

        [Required]
        [Display(Name = "Ngày Đăng")]
        public DateTime NgayDang { get; set; }

        [StringLength(20)]
        [ForeignKey("ThanhVien")]
        [Display(Name = "Người Đăng")]
        public string? NguoiDang { get; set; }
        public ThanhVien? ThanhVien { get; set; }
    }
}
