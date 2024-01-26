using CLB_HTSV.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CLB_HTSV.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ThanhVien> ThanhVien { get; set; }
        public DbSet<LopHoc> LopHoc { get; set;}
        public DbSet<TinTuc> TinTuc { get; set;}
        public DbSet<SuKien> SuKien { get; set; }
        public DbSet<DangKySuKien> DangKySuKien { get; set; }
        public DbSet<HinhAnh> HinhAnh { get; set; }
        public DbSet<CLB_HTSV.Models.ChucVu>? ChucVu { get; set; }
    }
}