using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qlsinhvien.Migrations
{
    /// <inheritdoc />
    public partial class checkChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_VaiTro_MaVaiTro",
                table: "NguoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyenVaiTro_VaiTro_VaiTrosMaVaiTro",
                table: "QuyenVaiTro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VaiTro",
                table: "VaiTro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuyenVaiTro",
                table: "QuyenVaiTro");

            migrationBuilder.DropIndex(
                name: "IX_QuyenVaiTro_VaiTrosMaVaiTro",
                table: "QuyenVaiTro");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDung_MaVaiTro",
                table: "NguoiDung");

            migrationBuilder.DropColumn(
                name: "MaVaiTro",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "VaiTrosMaVaiTro",
                table: "QuyenVaiTro");

            migrationBuilder.DropColumn(
                name: "MaVaiTro",
                table: "NguoiDung");

            migrationBuilder.AlterColumn<string>(
                name: "TenVaiTro",
                table: "VaiTro",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "VaiTro",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaiTrosTenVaiTro",
                table: "QuyenVaiTro",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "Quyen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenHienThi",
                table: "NguoiDung",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenVaiTro",
                table: "NguoiDung",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaiTro",
                table: "VaiTro",
                column: "TenVaiTro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuyenVaiTro",
                table: "QuyenVaiTro",
                columns: new[] { "QuyensMaQuyen", "VaiTrosTenVaiTro" });

            migrationBuilder.CreateIndex(
                name: "IX_QuyenVaiTro_VaiTrosTenVaiTro",
                table: "QuyenVaiTro",
                column: "VaiTrosTenVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_TenVaiTro",
                table: "NguoiDung",
                column: "TenVaiTro");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_VaiTro_TenVaiTro",
                table: "NguoiDung",
                column: "TenVaiTro",
                principalTable: "VaiTro",
                principalColumn: "TenVaiTro");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyenVaiTro_VaiTro_VaiTrosTenVaiTro",
                table: "QuyenVaiTro",
                column: "VaiTrosTenVaiTro",
                principalTable: "VaiTro",
                principalColumn: "TenVaiTro",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_VaiTro_TenVaiTro",
                table: "NguoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyenVaiTro_VaiTro_VaiTrosTenVaiTro",
                table: "QuyenVaiTro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VaiTro",
                table: "VaiTro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuyenVaiTro",
                table: "QuyenVaiTro");

            migrationBuilder.DropIndex(
                name: "IX_QuyenVaiTro_VaiTrosTenVaiTro",
                table: "QuyenVaiTro");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDung_TenVaiTro",
                table: "NguoiDung");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "VaiTrosTenVaiTro",
                table: "QuyenVaiTro");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "Quyen");

            migrationBuilder.DropColumn(
                name: "TenHienThi",
                table: "NguoiDung");

            migrationBuilder.DropColumn(
                name: "TenVaiTro",
                table: "NguoiDung");

            migrationBuilder.AlterColumn<string>(
                name: "TenVaiTro",
                table: "VaiTro",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "MaVaiTro",
                table: "VaiTro",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "VaiTrosMaVaiTro",
                table: "QuyenVaiTro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaVaiTro",
                table: "NguoiDung",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaiTro",
                table: "VaiTro",
                column: "MaVaiTro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuyenVaiTro",
                table: "QuyenVaiTro",
                columns: new[] { "QuyensMaQuyen", "VaiTrosMaVaiTro" });

            migrationBuilder.CreateIndex(
                name: "IX_QuyenVaiTro_VaiTrosMaVaiTro",
                table: "QuyenVaiTro",
                column: "VaiTrosMaVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_MaVaiTro",
                table: "NguoiDung",
                column: "MaVaiTro");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_VaiTro_MaVaiTro",
                table: "NguoiDung",
                column: "MaVaiTro",
                principalTable: "VaiTro",
                principalColumn: "MaVaiTro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuyenVaiTro_VaiTro_VaiTrosMaVaiTro",
                table: "QuyenVaiTro",
                column: "VaiTrosMaVaiTro",
                principalTable: "VaiTro",
                principalColumn: "MaVaiTro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
