using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qlsinhvien.Migrations
{
    /// <inheritdoc />
    public partial class quyenDungNvarcharLamPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quyen_VaiTro_Quyen_ TenQuyen",
                table: "Quyen_VaiTro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quyen_VaiTro",
                table: "Quyen_VaiTro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quyen",
                table: "Quyen");

            migrationBuilder.DropColumn(
                name: " TenQuyen",
                table: "Quyen_VaiTro");

            migrationBuilder.DropColumn(
                name: " TenQuyen",
                table: "Quyen");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "Quyen",
                newName: "GhiChu");

            migrationBuilder.AddColumn<string>(
                name: "TenQuyen",
                table: "Quyen_VaiTro",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TenQuyen",
                table: "Quyen",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quyen_VaiTro",
                table: "Quyen_VaiTro",
                columns: new[] { "TenQuyen", "TenVaiTro" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quyen",
                table: "Quyen",
                column: "TenQuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_Quyen_VaiTro_Quyen_TenQuyen",
                table: "Quyen_VaiTro",
                column: "TenQuyen",
                principalTable: "Quyen",
                principalColumn: "TenQuyen",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quyen_VaiTro_Quyen_TenQuyen",
                table: "Quyen_VaiTro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quyen_VaiTro",
                table: "Quyen_VaiTro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quyen",
                table: "Quyen");

            migrationBuilder.DropColumn(
                name: "TenQuyen",
                table: "Quyen_VaiTro");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "Quyen",
                newName: "MoTa");

            migrationBuilder.AddColumn<int>(
                name: " TenQuyen",
                table: "Quyen_VaiTro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TenQuyen",
                table: "Quyen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: " TenQuyen",
                table: "Quyen",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quyen_VaiTro",
                table: "Quyen_VaiTro",
                columns: new[] { " TenQuyen", "TenVaiTro" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quyen",
                table: "Quyen",
                column: " TenQuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_Quyen_VaiTro_Quyen_ TenQuyen",
                table: "Quyen_VaiTro",
                column: " TenQuyen",
                principalTable: "Quyen",
                principalColumn: " TenQuyen",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
