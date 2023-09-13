using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities.SecurityModels;

public class ModelDangKi
{
    public string TenNguoiDung { get; set; } = null!;
    public string MatKhau { get; set; } = null!;
    public string? TenHienThi { get; set; } = null!;
}