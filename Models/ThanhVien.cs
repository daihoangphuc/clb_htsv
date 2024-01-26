using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLB_HTSV.Models
{
    public class ThanhVien
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Mã Thành Viên")]
        public string? MaThanhVien { get; set; }

        [StringLength(255)]
        [Display(Name = "Họ và Tên")]
        public string? HoTen { get; set; }

        [StringLength(20)]
        [Display(Name = "Mã Số Sinh Viên")]
        public string? MaSinhVien { get; set; }

        [StringLength(255)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày Gia Nhập")]
        public DateTime NgayGiaNhap { get; set; }


        [StringLength(20)]
        [ForeignKey("ChucVu")]
        [Display(Name = "Chức vụ")]
        public string? MaChucVu { get; set; }
        public ChucVu? ChucVu { get; set; }


        [StringLength(20)]
        [ForeignKey("LopHoc")]
        [Display(Name = "Mã Lớp")]
        public string? MaLop { get; set; }
        public LopHoc? LopHoc { get; set; }

    }
}
