using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLB_HTSV.Models
{
    public class DangKySuKien
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Mã Đăng Ký")]
        public string? MaDangKy { get; set; }

        [StringLength(20)]
        [ForeignKey("SuKien")]
        [Display(Name = "Mã Sự Kiện")]
        public string? MaSuKien { get; set; }
        public SuKien? SuKien { get; set; }

        [StringLength(20)]
        [ForeignKey("ThanhVien")]
        [Display(Name = "Mã Thành Viên")]
        public string? MaThanhVien { get; set; }
        public ThanhVien? ThanhVien { get; set; }

        [Display(Name = "Ngày Đăng Ký")]
        public DateTime NgayDangKy { get; set; }

        [Display(Name = "Đã Đăng Ký")]
        public bool DaDangKy { get; set; }
    }
}
