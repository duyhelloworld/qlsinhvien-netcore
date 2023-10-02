namespace qlsinhvien.Dto;

public class StudentMarkDto
{
    public int CourseClassId { get; set; }
    public int StudentId { get; set; }
    
    public float DiemChuyenCan { get; set; }
    
    public float DiemGiuaKi { get; set; }
    
    public float DiemCuoiKi { get; set; }
    
    public int HocKi { get; set; }
    public string? GhiChu { get; set; }
}