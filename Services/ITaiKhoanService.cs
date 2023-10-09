using qlsinhvien.Entities.SecurityModels;

namespace qlsinhvien.Services;

public interface ITaiKhoanService
{
    // Luồng đăng nhập
    public Task TaoTaiKhoanTrong(ModelDangKi model);
    public Task<ModelTraVe> DangNhap(ModelDangNhap model);
    public Task DangXuat(HttpContext context);
}