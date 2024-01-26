using System.ComponentModel.DataAnnotations;

namespace CLB_HTSV.Models
{
    public class LopHoc
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Mã Lớp")]
        public string? MaLop { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên Lớp")]
        public string? TenLop { get; set; }

        [StringLength(100)]
        [Display(Name = "Khoa")]
        public string? Khoa { get; set; }
    }
}
