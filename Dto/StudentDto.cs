namespace qlsinhvien.Dto;

public class StudentDto : AbstractHumanDto {
    public int StudentId { get; set;}

    public DateTime NgayVaoTruong { get; set; }
    
    public int ManagementClassId { get; set; }
}         