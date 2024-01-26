using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLB_HTSV.Models
{
    public class ChucVu
    {
        [Key]

        [StringLength(20)]
        public string? MaChucVu {  get; set; }


        [StringLength(255)]
        [Display(Name = "Chức vụ")]
        public string? TenChucVu { get; set; }
    }
}
