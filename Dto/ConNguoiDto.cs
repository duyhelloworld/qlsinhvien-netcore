namespace qlsinhvien.Dto;

public abstract class ConNguoiDto
{
    public string HoTen { get; set; } = null!;

    public bool GioiTinh { get; set; }

    public DateTime NgaySinh { get; set; }

    public string? DiaChiThuongTru { get; set; }

    public string? QueQuan { get; set; }

    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;
}