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
        public required string TenLopMonHoc { get; set; }

        [Required]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey("MaMonHoc")]
        public MonHoc MonHoc { get; set; } = null!;

        public int MaMonHoc {get; set; }

        [Required]
        [ForeignKey("MaGiangVien")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public GiangVien GiangVien { get; set; } = null!;

        public ICollection<DiemSinhVien>? DiemSinhViens { get; set; } = new HashSet<DiemSinhVien>();
    }
}