using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qlsinhvien.Migrations
{
    /// <inheritdoc />
    public partial class taobang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoMon",
                columns: table => new
                {
                    MaBoMon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBoMon = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMon", x => x.MaBoMon);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    MaKhoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    MaMonHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SoTinChi = table.Column<byte>(type: "tinyint", nullable: false),
                    BatBuoc = table.Column<bool>(type: "bit", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaMonTienQuyet = table.Column<int>(type: "int", nullable: true),
                    MaBoMon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.MaMonHoc);
                    table.ForeignKey(
                        name: "FK_MonHoc_BoMon_MaBoMon",
                        column: x => x.MaBoMon,
                        principalTable: "BoMon",
                        principalColumn: "MaBoMon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonHoc_MonHoc_MaMonTienQuyet",
                        column: x => x.MaMonTienQuyet,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc");
                });

            migrationBuilder.CreateTable(
                name: "BoMonKhoa",
                columns: table => new
                {
                    BoMonsMaBoMon = table.Column<int>(type: "int", nullable: false),
                    KhoaMaKhoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMonKhoa", x => new { x.BoMonsMaBoMon, x.KhoaMaKhoa });
                    table.ForeignKey(
                        name: "FK_BoMonKhoa_BoMon_BoMonsMaBoMon",
                        column: x => x.BoMonsMaBoMon,
                        principalTable: "BoMon",
                        principalColumn: "MaBoMon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoMonKhoa_Khoa_KhoaMaKhoa",
                        column: x => x.KhoaMaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopQuanLi",
                columns: table => new
                {
                    MaLopQuanLi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLopQuanLi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaKhoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopQuanLi", x => x.MaLopQuanLi);
                    table.ForeignKey(
                        name: "FK_LopQuanLi_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    MaGiangVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBoMon = table.Column<int>(type: "int", nullable: false),
                    MaLopQuanLi = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    DiaChiThuongTru = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    QueQuan = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangVien", x => x.MaGiangVien);
                    table.ForeignKey(
                        name: "FK_GiangVien_BoMon_MaBoMon",
                        column: x => x.MaBoMon,
                        principalTable: "BoMon",
                        principalColumn: "MaBoMon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiangVien_LopQuanLi_MaLopQuanLi",
                        column: x => x.MaLopQuanLi,
                        principalTable: "LopQuanLi",
                        principalColumn: "MaLopQuanLi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSinhVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayVaoTruong = table.Column<DateTime>(type: "date", nullable: false),
                    MaLopQuanLi = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    DiaChiThuongTru = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    QueQuan = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSinhVien);
                    table.ForeignKey(
                        name: "FK_SinhVien_LopQuanLi_MaLopQuanLi",
                        column: x => x.MaLopQuanLi,
                        principalTable: "LopQuanLi",
                        principalColumn: "MaLopQuanLi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopMonHoc",
                columns: table => new
                {
                    MaLopMonHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLopMonHoc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaMonHoc = table.Column<int>(type: "int", nullable: false),
                    MaGiangVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopMonHoc", x => x.MaLopMonHoc);
                    table.ForeignKey(
                        name: "FK_LopMonHoc_GiangVien_MaGiangVien",
                        column: x => x.MaGiangVien,
                        principalTable: "GiangVien",
                        principalColumn: "MaGiangVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LopMonHoc_MonHoc_MaMonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiemSinhVien",
                columns: table => new
                {
                    MaLopMonHoc = table.Column<int>(type: "int", nullable: false),
                    MaSinhVien = table.Column<int>(type: "int", nullable: false),
                    DiemChuyenCan = table.Column<float>(type: "real", nullable: false),
                    DiemGiuaKi = table.Column<float>(type: "real", nullable: false),
                    DiemCuoiKi = table.Column<float>(type: "real", nullable: false),
                    HocKi = table.Column<byte>(type: "tinyint", nullable: false),
                    GhiChu = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemSinhVien", x => new { x.MaLopMonHoc, x.MaSinhVien });
                    table.ForeignKey(
                        name: "FK_DiemSinhVien_LopMonHoc_MaLopMonHoc",
                        column: x => x.MaLopMonHoc,
                        principalTable: "LopMonHoc",
                        principalColumn: "MaLopMonHoc");
                    table.ForeignKey(
                        name: "FK_DiemSinhVien_SinhVien_MaSinhVien",
                        column: x => x.MaSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "MaSinhVien");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoMonKhoa_KhoaMaKhoa",
                table: "BoMonKhoa",
                column: "KhoaMaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_DiemSinhVien_MaSinhVien",
                table: "DiemSinhVien",
                column: "MaSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_Email_SoDienThoai",
                table: "GiangVien",
                columns: new[] { "Email", "SoDienThoai" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaBoMon",
                table: "GiangVien",
                column: "MaBoMon");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaLopQuanLi",
                table: "GiangVien",
                column: "MaLopQuanLi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopMonHoc_MaGiangVien",
                table: "LopMonHoc",
                column: "MaGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_LopMonHoc_MaMonHoc",
                table: "LopMonHoc",
                column: "MaMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LopQuanLi_MaKhoa",
                table: "LopQuanLi",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaBoMon",
                table: "MonHoc",
                column: "MaBoMon");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaMonTienQuyet",
                table: "MonHoc",
                column: "MaMonTienQuyet");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_Email_SoDienThoai",
                table: "SinhVien",
                columns: new[] { "Email", "SoDienThoai" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaLopQuanLi",
                table: "SinhVien",
                column: "MaLopQuanLi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoMonKhoa");

            migrationBuilder.DropTable(
                name: "DiemSinhVien");

            migrationBuilder.DropTable(
                name: "LopMonHoc");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "GiangVien");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "LopQuanLi");

            migrationBuilder.DropTable(
                name: "BoMon");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
