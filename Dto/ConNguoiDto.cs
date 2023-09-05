using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;

public abstract class ConNguoiDto
{
    public string HoTen { get; set; } = null!;

    public bool GioiTinh { get; set; }

    public DateTime NgaySinh { get; set; }

    public string? DiaChiThuongTru { get; set; }

    public string? QueQuan { get; set; }

    [RegularExpression(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$", ErrorMessage = "Email này không đúng định dạng")]
    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = "";
}