namespace qlsinhvien.Dto;

public class InstructorDto : AbstractHumanDto
{
    public int InstructorId { get; set; }
    
    public int DepartmentId { get; set; }

    public int? ManagementClassId { get; set; }

    public ICollection<int>? CourseClassIds { get; set; }
}