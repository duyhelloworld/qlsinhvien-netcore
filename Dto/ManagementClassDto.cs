namespace qlsinhvien.Dto;

public class ManagementClassDto
{
    public int ManagementClassId { get; set; }
    public string TenManagementClass { get; set; } = null!;

    public int FacultyId { get; set; }
    public int? InstructorId { get; set; }
}