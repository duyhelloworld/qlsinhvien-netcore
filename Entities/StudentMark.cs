using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [PrimaryKey(nameof(CourseClassId), nameof(StudentId))]
    public class StudentMark
    {
        public int CourseClassId { get; set; }
        
        public int StudentId { get; set; }

        public float DiemChuyenCan { get; set; }

        public float DiemGiuaKi { get; set; }

        public float DiemCuoiKi { get; set; }

        [Column(TypeName = "tinyint")]
        public int HocKi { get; set; }

        [Column(TypeName = "text")]
        public string? GhiChu { get; set; }

        [ForeignKey("CourseClassId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public CourseClass CourseClass { get; set; } = null!;

        [ForeignKey("StudentId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Student Student { get; set; } = null!;
    }
}
