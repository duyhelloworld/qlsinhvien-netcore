using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class KhoaDto
{
    [JsonRequired]
    public int MaKhoa { get; set; }
    public string TenKhoa { get; set; }

    public ICollection<int> MaBoMons { get; set; }
    public ICollection<int> MaLopQuanLis { get; set; }
}