using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class KhoaDto
{
    [JsonRequired]
    public int MaKhoa { get; set; }
    public string TenKhoa { get; set; }
}