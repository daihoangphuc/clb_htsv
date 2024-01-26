using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLB_HTSV.Data.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HinhAnhs",
                table: "HinhAnhs");

            migrationBuilder.RenameTable(
                name: "HinhAnhs",
                newName: "HinhAnh");

            migrationBuilder.AlterColumn<string>(
                name: "DuongDanAnh",
                table: "HinhAnh",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HinhAnh",
                table: "HinhAnh",
                column: "MaAnh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HinhAnh",
                table: "HinhAnh");

            migrationBuilder.RenameTable(
                name: "HinhAnh",
                newName: "HinhAnhs");

            migrationBuilder.AlterColumn<string>(
                name: "DuongDanAnh",
                table: "HinhAnhs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HinhAnhs",
                table: "HinhAnhs",
                column: "MaAnh");

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaThanhVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Quyen = table.Column<int>(type: "int", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
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
        }
    }
}
