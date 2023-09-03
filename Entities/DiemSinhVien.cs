using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [Table("DiemSinhVien")]
    [PrimaryKey(nameof(MaLopMonHoc), nameof(MaSinhVien))]
    public class DiemSinhVien
    {
        public int MaLopMonHoc { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public LopMonHoc LopMonHoc { get; set; } = null!;

        public int MaSinhVien { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public SinhVien SinhVien { get; set; } = null!;

        public float DiemChuyenCan { get; set; }

        public float DiemGiuaKi { get; set; }

        public float DiemCuoiKi { get; set; }

        [Column(TypeName = "tinyint")]
        public int HocKi { get; set; }

        [Column(TypeName = "text")]
        public string? GhiChu { get; set; }
    }
}
