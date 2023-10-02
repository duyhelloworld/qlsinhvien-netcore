namespace qlsinhvien.Dto;

public class CourseDto
{
    
    public int CourseId { get; set; }
    
    public string TenMonHoc { get; set; } = null!;
    
    public short SoTinChi { get; set; }
    
    public bool BatBuoc { get; set; }

    public string? MoTa { get; set; }

    public int? MaMonTienQuyet { get; set; }
    
    public int DepartmentId { get; set; }

    public int CourseClassId { get; set; }
}