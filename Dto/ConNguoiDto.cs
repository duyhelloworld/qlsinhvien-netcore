using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;

public abstract class ConNguoiDto
{
    public string HoTen { get; set; }

    public bool GioiTinh { get; set; }

    public DateTime NgaySinh { get; set; }

    public string? DiaChiThuongTru { get; set; }

    public string? QueQuan { get; set; }

    [JsonRequired]
    public string Email { get; set; } = "";

    [JsonRequired]
    public string SoDienThoai { get; set; } = "";
}