using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLB_HTSV.Models
{
    public class SuKien
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Mã Sự Kiện")]
        public string? MaSuKien { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tiêu Đề")]
        public string? TieuDe { get; set; }

        [MaxLength]
        [Display(Name = "Mô Tả")]
        public string? MoTa { get; set; }

        [Required]
        [Display(Name = "Thời Gian")]
        public DateTime ThoiGian { get; set; }

        [StringLength(255)]
        [Display(Name = "Địa Điểm")]
        public string? DiaDiem { get; set; }

        [StringLength(20)]
        [Display(Name = "Tổ Chức Bởi")]
        [ForeignKey("ThanhVien")]
        public string? ToChucBoi { get; set; }
        public ThanhVien? ThanhVien { get; set; }
    }
}
