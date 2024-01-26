using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLB_HTSV.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TinTuc_NguoiDang",
                table: "TinTuc",
                column: "NguoiDang");

            migrationBuilder.CreateIndex(
                name: "IX_SuKien_ToChucBoi",
                table: "SuKien",
                column: "ToChucBoi");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_MaSuKien",
                table: "HinhAnh",
                column: "MaSuKien");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_MaTinTuc",
                table: "HinhAnh",
                column: "MaTinTuc");

            migrationBuilder.CreateIndex(
                name: "IX_DangKySuKien_MaSuKien",
                table: "DangKySuKien",
                column: "MaSuKien");

            migrationBuilder.CreateIndex(
                name: "IX_DangKySuKien_MaThanhVien",
                table: "DangKySuKien",
                column: "MaThanhVien");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKySuKien_SuKien_MaSuKien",
                table: "DangKySuKien",
                column: "MaSuKien",
                principalTable: "SuKien",
                principalColumn: "MaSuKien");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKySuKien_ThanhVien_MaThanhVien",
                table: "DangKySuKien",
                column: "MaThanhVien",
                principalTable: "ThanhVien",
                principalColumn: "MaThanhVien");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhAnh_SuKien_MaSuKien",
                table: "HinhAnh",
                column: "MaSuKien",
                principalTable: "SuKien",
                principalColumn: "MaSuKien");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhAnh_TinTuc_MaTinTuc",
                table: "HinhAnh",
                column: "MaTinTuc",
                principalTable: "TinTuc",
                principalColumn: "MaTinTuc");

            migrationBuilder.AddForeignKey(
                name: "FK_SuKien_ThanhVien_ToChucBoi",
                table: "SuKien",
                column: "ToChucBoi",
                principalTable: "ThanhVien",
                principalColumn: "MaThanhVien");

            migrationBuilder.AddForeignKey(
                name: "FK_TinTuc_ThanhVien_NguoiDang",
                table: "TinTuc",
                column: "NguoiDang",
                principalTable: "ThanhVien",
                principalColumn: "MaThanhVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKySuKien_SuKien_MaSuKien",
                table: "DangKySuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKySuKien_ThanhVien_MaThanhVien",
                table: "DangKySuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhAnh_SuKien_MaSuKien",
                table: "HinhAnh");

            migrationBuilder.DropForeignKey(
                name: "FK_HinhAnh_TinTuc_MaTinTuc",
                table: "HinhAnh");

            migrationBuilder.DropForeignKey(
                name: "FK_SuKien_ThanhVien_ToChucBoi",
                table: "SuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_TinTuc_ThanhVien_NguoiDang",
                table: "TinTuc");

            migrationBuilder.DropIndex(
                name: "IX_TinTuc_NguoiDang",
                table: "TinTuc");

            migrationBuilder.DropIndex(
                name: "IX_SuKien_ToChucBoi",
                table: "SuKien");

            migrationBuilder.DropIndex(
                name: "IX_HinhAnh_MaSuKien",
                table: "HinhAnh");

            migrationBuilder.DropIndex(
                name: "IX_HinhAnh_MaTinTuc",
                table: "HinhAnh");

            migrationBuilder.DropIndex(
                name: "IX_DangKySuKien_MaSuKien",
                table: "DangKySuKien");

            migrationBuilder.DropIndex(
                name: "IX_DangKySuKien_MaThanhVien",
                table: "DangKySuKien");
        }
    }
}
