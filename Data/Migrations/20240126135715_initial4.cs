using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLB_HTSV.Data.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoTenDem",
                table: "ThanhVien");

            migrationBuilder.RenameColumn(
                name: "VaiTro",
                table: "ThanhVien",
                newName: "MaChucVu");

            migrationBuilder.RenameColumn(
                name: "Ten",
                table: "ThanhVien",
                newName: "HoTen");

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    MaChucVu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.MaChucVu);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVien_MaChucVu",
                table: "ThanhVien",
                column: "MaChucVu");

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhVien_ChucVu_MaChucVu",
                table: "ThanhVien",
                column: "MaChucVu",
                principalTable: "ChucVu",
                principalColumn: "MaChucVu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThanhVien_ChucVu_MaChucVu",
                table: "ThanhVien");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropIndex(
                name: "IX_ThanhVien_MaChucVu",
                table: "ThanhVien");

            migrationBuilder.RenameColumn(
                name: "MaChucVu",
                table: "ThanhVien",
                newName: "VaiTro");

            migrationBuilder.RenameColumn(
                name: "HoTen",
                table: "ThanhVien",
                newName: "Ten");

            migrationBuilder.AddColumn<string>(
                name: "HoTenDem",
                table: "ThanhVien",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
