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
        public string TenBoMon { get; set; } = null!;

        public ICollection<MonHoc> MonHocs { get; set; } = new HashSet<MonHoc>();

        public ICollection<GiangVien> GiangViens { get; set; } = new HashSet<GiangVien>();

        public ICollection<Khoa> Khoa { get; set; } = new HashSet<Khoa>();
    }
}