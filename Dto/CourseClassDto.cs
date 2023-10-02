namespace qlsinhvien.Dto;

public class CourseClassDto
{
    public int CourseClassId { get; set; }
    
    public string TenCourseClass { get; set; } = null!;

    public int CourseId { get; set; }
    
    public int InstructorId { get; set; }
}