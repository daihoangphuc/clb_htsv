using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLB_HTSV.Models
{
    public class HinhAnh
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Mã Ảnh")]
        public string? MaAnh { get; set; }

        [StringLength(20)]
        [ForeignKey("SuKien")]
        [Display(Name = "Mã Sự Kiện")]
        public string? MaSuKien { get; set; }
        public SuKien? SuKien { get; set; }

        [StringLength(20)]
        [ForeignKey("TinTuc")]
        [Display(Name = "Mã Tin Tức")]
        public string? MaTinTuc { get; set; }
        public TinTuc? TinTuc { get; set; }

        [StringLength(255)]
        [Display(Name = "Đường Dẫn Ảnh")]
        public string? DuongDanAnh { get; set; }
    }
}
