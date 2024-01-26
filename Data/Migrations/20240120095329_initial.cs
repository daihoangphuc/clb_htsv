using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLB_HTSV.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DangKySuKien",
                columns: table => new
                {
                    MaDangKy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaSuKien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaThanhVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaDangKy = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKySuKien", x => x.MaDangKy);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnhs",
                columns: table => new
                {
                    MaAnh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaSuKien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaTinTuc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DuongDanAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnhs", x => x.MaAnh);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Khoa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "SuKien",
                columns: table => new
                {
                    MaSuKien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ToChucBoi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuKien", x => x.MaSuKien);
                });

            migrationBuilder.CreateTable(
                name: "TinTuc",
                columns: table => new
                {
                    MaTinTuc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiDang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTuc", x => x.MaTinTuc);
                });

            migrationBuilder.CreateTable(
                name: "ThanhVien",
                columns: table => new
                {
                    MaThanhVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HoTenDem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaSinhVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayGiaNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaLop = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhVien", x => x.MaThanhVien);
                    table.ForeignKey(
                        name: "FK_ThanhVien_LopHoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaThanhVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TenDangNhap = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Quyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.MaTaiKhoan);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_ThanhVien_MaThanhVien",
                        column: x => x.MaThanhVien,
                        principalTable: "ThanhVien",
                        principalColumn: "MaThanhVien");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_MaThanhVien",
                table: "TaiKhoan",
                column: "MaThanhVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVien_MaLop",
                table: "ThanhVien",
                column: "MaLop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangKySuKien");

            migrationBuilder.DropTable(
                name: "HinhAnhs");

            migrationBuilder.DropTable(
                name: "SuKien");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "TinTuc");

            migrationBuilder.DropTable(
                name: "ThanhVien");

            migrationBuilder.DropTable(
                name: "LopHoc");
        }
    }
}
