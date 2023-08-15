using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;

public class LopQuanLiDto
{
    [JsonRequired]
    public int MaLopQuanLi { get; set; }

    [JsonRequired]
    public string TenLopQuanLi { get; set; }

    [JsonRequired]
    public int MaKhoa { get; set; }
}