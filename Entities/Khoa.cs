using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace qlsinhvien.Entities
{
    [Table("Khoa")]
    public class Khoa
    {
        [Key]
        public int MaKhoa { get; set; }

        [Required]
        [StringLength(80)]
        public string? TenKhoa { get; set; }

        public List<LopQuanLi> LopQuanLis { get; set; }

        public List<BoMon> BoMons { get; set; }
    }
}