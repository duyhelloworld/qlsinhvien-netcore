using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [Table("MonHoc")]
    public class MonHoc
    {
        [Key]
        public int MaMonHoc { get; set; }

        [Required]
        [StringLength(60)]
        public string? TenMonHoc { get; set; }

        [Column(TypeName = "tinyint")]
        public short SoTinChi { get; set; }

        public bool BatBuoc { get; set; }

        [MaxLength]
        public string? MoTa { get; set; }

        [ForeignKey("MaMonTienQuyet")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public MonHoc? MonTienQuyet { get; set; }

        [ForeignKey("MaBoMon")]
        public BoMon BoMon { get; set; }

        public ICollection<LopMonHoc> LopMonHocs { get; set; } = new HashSet<LopMonHoc>();
    }
}
