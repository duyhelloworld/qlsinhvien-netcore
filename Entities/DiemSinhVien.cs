using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [Table("DiemSinhVien")]
    [PrimaryKey(nameof(MaLopMonHoc), nameof(MaSinhVien))]
    public class DiemSinhVien
    {
        public int MaLopMonHoc { get; set; }
        [ForeignKey("MaLopMonHoc")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        [JsonIgnore]
        public LopMonHoc LopMonHoc { get; set; }

        public int MaSinhVien { get; set; }
        [ForeignKey("MaSinhVien")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        [JsonIgnore]
        public SinhVien SinhVien { get; set; }

        public float DiemChuyenCan { get; set; }
        public float DiemGiuaKi { get; set; }
        public float DiemCuoiKi { get; set; }

        public int HocKi { get; set; }

        [MaxLength]
        public string GhiChu { get; set; }
    }
}
