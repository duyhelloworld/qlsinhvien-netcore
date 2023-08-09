namespace qlsinhvien.Dto;

public class KhoaDto
{
    public string TenKhoa {get; set;}

    public ICollection<MonHocDto>? MonHocs {get; set;}

    public ICollection<LopQuanLiDto>? LopQuanLi  {get; set;}
    
}
