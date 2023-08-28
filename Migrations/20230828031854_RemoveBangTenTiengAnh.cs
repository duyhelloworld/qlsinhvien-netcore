using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qlsinhvien.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBangTenTiengAnh : Migration
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
                name: "NguoiDung",
                columns: table => new
                {
                    TenNguoiDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.TenNguoiDung);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    TenVaiTro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenVaiTroCuThe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.TenVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    MaGiangVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBoMon = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
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
                name: "NguoiDung_VaiTro",
                columns: table => new
                {
                    TenNguoiDung = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TenVaiTro = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung_VaiTro", x => new { x.TenNguoiDung, x.TenVaiTro });
                    table.ForeignKey(
                        name: "FK_NguoiDung_VaiTro_NguoiDung_TenNguoiDung",
                        column: x => x.TenNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "TenNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiDung_VaiTro_VaiTro_TenVaiTro",
                        column: x => x.TenVaiTro,
                        principalTable: "VaiTro",
                        principalColumn: "TenVaiTro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopQuanLi",
                columns: table => new
                {
                    MaLopQuanLi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLopQuanLi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaGiangVien = table.Column<int>(type: "int", nullable: true),
                    MaKhoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopQuanLi", x => x.MaLopQuanLi);
                    table.ForeignKey(
                        name: "FK_LopQuanLi_GiangVien_MaGiangVien",
                        column: x => x.MaGiangVien,
                        principalTable: "GiangVien",
                        principalColumn: "MaGiangVien");
                    table.ForeignKey(
                        name: "FK_LopQuanLi_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa",
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
                        principalColumn: "MaGiangVien");
                    table.ForeignKey(
                        name: "FK_LopMonHoc_MonHoc_MaMonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc");
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSinhVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayVaoTruong = table.Column<DateTime>(type: "date", nullable: false),
                    LopQuanLiMaLopQuanLi = table.Column<int>(type: "int", nullable: false),
                    MaLopQuanLi = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
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
                        name: "FK_SinhVien_LopQuanLi_LopQuanLiMaLopQuanLi",
                        column: x => x.LopQuanLiMaLopQuanLi,
                        principalTable: "LopQuanLi",
                        principalColumn: "MaLopQuanLi",
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
                name: "IX_GiangVien_Email",
                table: "GiangVien",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaBoMon",
                table: "GiangVien",
                column: "MaBoMon");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_SoDienThoai",
                table: "GiangVien",
                column: "SoDienThoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_TenKhoa",
                table: "Khoa",
                column: "TenKhoa",
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
                name: "IX_LopQuanLi_MaGiangVien",
                table: "LopQuanLi",
                column: "MaGiangVien",
                unique: true,
                filter: "[MaGiangVien] IS NOT NULL");

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
                name: "IX_NguoiDung_VaiTro_TenVaiTro",
                table: "NguoiDung_VaiTro",
                column: "TenVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_Email",
                table: "SinhVien",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_LopQuanLiMaLopQuanLi",
                table: "SinhVien",
                column: "LopQuanLiMaLopQuanLi");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_SoDienThoai",
                table: "SinhVien",
                column: "SoDienThoai",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoMonKhoa");

            migrationBuilder.DropTable(
                name: "DiemSinhVien");

            migrationBuilder.DropTable(
                name: "NguoiDung_VaiTro");

            migrationBuilder.DropTable(
                name: "LopMonHoc");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "LopQuanLi");

            migrationBuilder.DropTable(
                name: "GiangVien");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "BoMon");
        }
    }
}
