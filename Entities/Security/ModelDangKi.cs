using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities.Security;

public class ModelDangKi
{
    public string TenNguoiDung { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string TenHienThi { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;
}