using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class KhoaDto
{
    [JsonRequired]
    public int MaKhoa { get; set; }
    [JsonRequired]
    public string TenKhoa { get; set; }

}