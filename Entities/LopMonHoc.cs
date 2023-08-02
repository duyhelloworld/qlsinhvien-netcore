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
        public string TenLopMonHoc { get; set; }

        [Required]
        // Khóa ngoại MaMonHoc
        public int MaMonHoc { get; set; }
        [ForeignKey("MaMonHoc")]
        public MonHoc MonHoc { get; set; }

        [Required]
        // Khóa ngoại MaGiangVien
        public int MaGiangVien { get; set; }
        [ForeignKey("MaGiangVien")]
        public GiangVien GiangVien { get; set; }
    }
}