using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [Table("LopMonHoc")]
    public class LopMonHoc
    {
        [Key]
        public int MaLopMonHoc { get; set; }

        [Required]
        [StringLength(10)]
        public string? TenLopMonHoc { get; set; }

        [Required]
        [ForeignKey("MaMonHoc")]
        public MonHoc MonHoc { get; set; }

        [Required]
        [ForeignKey("MaGiangVien")]
        public GiangVien GiangVien { get; set; }

        public List<DiemSinhVien>? DiemSinhViens { get; set; }
    }
}