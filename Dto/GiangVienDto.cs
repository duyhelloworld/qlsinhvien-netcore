using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;

public class GiangVienDto : ConNguoiDto
{
    [JsonRequired]
    public int MaGiangVien { get; set; }

    [JsonRequired]
    public int MaBoMon { get; set; }

    [JsonRequired]
    public int MaLopQuanLi { get; set; }
}