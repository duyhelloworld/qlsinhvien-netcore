using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities
{
    public class Student : AbstractHuman
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayVaoTruong { get; set; }

        public int ManagementClassId { get; set; }
        [ForeignKey("ManagementClassId")]
        public ManagementClass ManagementClass { get; set; } = null!;

        public ICollection<StudentMark>? StudentMarks { get; set; } = new HashSet<StudentMark>();
    }
}