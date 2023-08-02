using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [Table("SinhVien")]
    // [Index(nameof(MaLopQuanLi), IsUnique = true)]
    public class SinhVien : ConNguoi
    {
        [Key]
        [Column(Order = 1)]
        public int MaSinhVien { get; set; }

        [DataType(DataType.Date)]
        public DateTime NgayVaoTruong { get; set; }

        // [Required]
        public int MaLopQuanLi {get; set;}
        [ForeignKey("MaLopQuanLi")]
        [JsonIgnore]
        public LopQuanLi LopQuanLi { get; set; }
    }
}