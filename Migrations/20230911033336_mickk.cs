using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qlsinhvien.Migrations
{
    /// <inheritdoc />
    public partial class mickk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoMonKhoa_Khoa_KhoaMaKhoa",
                table: "BoMonKhoa");

            migrationBuilder.DropForeignKey(
                name: "FK_LopMonHoc_GiangVien_MaGiangVien",
                table: "LopMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopQuanLi_GiangVien_MaGiangVien",
                table: "LopQuanLi");

            migrationBuilder.DropIndex(
                name: "IX_LopQuanLi_MaGiangVien",
                table: "LopQuanLi");

            migrationBuilder.RenameColumn(
                name: "KhoaMaKhoa",
                table: "BoMonKhoa",
                newName: "KhoasMaKhoa");

            migrationBuilder.RenameIndex(
                name: "IX_BoMonKhoa_KhoaMaKhoa",
                table: "BoMonKhoa",
                newName: "IX_BoMonKhoa_KhoasMaKhoa");

            migrationBuilder.AlterColumn<bool>(
                name: "GioiTinh",
                table: "SinhVien",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaSinhVien",
                table: "SinhVien",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 1)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MaGiangVien",
                table: "LopQuanLi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "GioiTinh",
                table: "GiangVien",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Khoa_BoMon",
                columns: table => new
                {
                    MaKhoa = table.Column<int>(type: "int", nullable: false),
                    MaBoMon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa_BoMon", x => new { x.MaBoMon, x.MaKhoa });
                    table.ForeignKey(
                        name: "FK_Khoa_BoMon_BoMon_MaBoMon",
                        column: x => x.MaBoMon,
                        principalTable: "BoMon",
                        principalColumn: "MaBoMon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Khoa_BoMon_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    TenQuyen = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.TenQuyen);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    TenVaiTro = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.TenVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    TenNguoiDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaGiangVien = table.Column<int>(type: "int", nullable: true),
                    MaSinhVien = table.Column<int>(type: "int", nullable: true),
                    TenVaiTro = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenHienThi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.TenNguoiDung);
                    table.ForeignKey(
                        name: "FK_NguoiDung_VaiTro_TenVaiTro",
                        column: x => x.TenVaiTro,
                        principalTable: "VaiTro",
                        principalColumn: "TenVaiTro");
                });

            migrationBuilder.CreateTable(
                name: "Quyen_VaiTro",
                columns: table => new
                {
                    TenQuyen = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenVaiTro = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen_VaiTro", x => new { x.TenQuyen, x.TenVaiTro });
                    table.ForeignKey(
                        name: "FK_Quyen_VaiTro_Quyen_TenQuyen",
                        column: x => x.TenQuyen,
                        principalTable: "Quyen",
                        principalColumn: "TenQuyen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quyen_VaiTro_VaiTro_TenVaiTro",
                        column: x => x.TenVaiTro,
                        principalTable: "VaiTro",
                        principalColumn: "TenVaiTro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LopQuanLi_MaGiangVien",
                table: "LopQuanLi",
                column: "MaGiangVien",
                unique: true,
                filter: "[MaGiangVien] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_BoMon_MaKhoa",
                table: "Khoa_BoMon",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_TenVaiTro",
                table: "NguoiDung",
                column: "TenVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_Quyen_VaiTro_TenVaiTro",
                table: "Quyen_VaiTro",
                column: "TenVaiTro");

            migrationBuilder.AddForeignKey(
                name: "FK_BoMonKhoa_Khoa_KhoasMaKhoa",
                table: "BoMonKhoa",
                column: "KhoasMaKhoa",
                principalTable: "Khoa",
                principalColumn: "MaKhoa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LopMonHoc_GiangVien_MaGiangVien",
                table: "LopMonHoc",
                column: "MaGiangVien",
                principalTable: "GiangVien",
                principalColumn: "MaGiangVien");

            migrationBuilder.AddForeignKey(
                name: "FK_LopQuanLi_GiangVien_MaGiangVien",
                table: "LopQuanLi",
                column: "MaGiangVien",
                principalTable: "GiangVien",
                principalColumn: "MaGiangVien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoMonKhoa_Khoa_KhoasMaKhoa",
                table: "BoMonKhoa");

            migrationBuilder.DropForeignKey(
                name: "FK_LopMonHoc_GiangVien_MaGiangVien",
                table: "LopMonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LopQuanLi_GiangVien_MaGiangVien",
                table: "LopQuanLi");

            migrationBuilder.DropTable(
                name: "Khoa_BoMon");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "Quyen_VaiTro");

            migrationBuilder.DropTable(
                name: "Quyen");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropIndex(
                name: "IX_LopQuanLi_MaGiangVien",
                table: "LopQuanLi");

            migrationBuilder.RenameColumn(
                name: "KhoasMaKhoa",
                table: "BoMonKhoa",
                newName: "KhoaMaKhoa");

            migrationBuilder.RenameIndex(
                name: "IX_BoMonKhoa_KhoasMaKhoa",
                table: "BoMonKhoa",
                newName: "IX_BoMonKhoa_KhoaMaKhoa");

            migrationBuilder.AlterColumn<bool>(
                name: "GioiTinh",
                table: "SinhVien",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "MaSinhVien",
                table: "SinhVien",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MaGiangVien",
                table: "LopQuanLi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "GioiTinh",
                table: "GiangVien",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_LopQuanLi_MaGiangVien",
                table: "LopQuanLi",
                column: "MaGiangVien",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BoMonKhoa_Khoa_KhoaMaKhoa",
                table: "BoMonKhoa",
                column: "KhoaMaKhoa",
                principalTable: "Khoa",
                principalColumn: "MaKhoa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LopMonHoc_GiangVien_MaGiangVien",
                table: "LopMonHoc",
                column: "MaGiangVien",
                principalTable: "GiangVien",
                principalColumn: "MaGiangVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LopQuanLi_GiangVien_MaGiangVien",
                table: "LopQuanLi",
                column: "MaGiangVien",
                principalTable: "GiangVien",
                principalColumn: "MaGiangVien",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
