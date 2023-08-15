using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities
{
    [Table("BoMon")]
    public class BoMon
    {
        [Key]
        public int MaBoMon { get; set; }

        [Required]
        [StringLength(80)]
        public string? TenBoMon { get; set; }

        public List<MonHoc> MonHocs { get; set; }

        public List<GiangVien> GiangViens { get; set; }

        public List<Khoa> Khoa { get; set; }
    }
}