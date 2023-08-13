using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [Table("Khoa-MonHoc")] // Ánh xạ lớp với bảng "Khoa-MonHoc" trong cơ sở dữ liệu
    [PrimaryKey(nameof(MaKhoa), nameof(MaMonHoc))]
    public class KhoaMonHoc
    {
        public int MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public Khoa? Khoa { get; set; }

        public int MaMonHoc { get; set; }
        [ForeignKey("MaMonHoc")]
        public MonHoc? MonHoc { get; set; }
    }
}

