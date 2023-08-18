using System.Text.Json.Serialization;
using qlsinhvien.Entities;

namespace qlsinhvien.Dto;

public class LopQuanLiDto
{
    [JsonRequired]
    public int MaLopQuanLi { get; set; }

    [JsonRequired]
    public string TenLopQuanLi { get; set; }

    [JsonRequired]
    public int MaKhoa { get; set; }
    // [JsonRequired]
    public GiangVien? giangVien{ get; set; }
}