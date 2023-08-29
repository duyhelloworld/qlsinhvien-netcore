using qlsinhvien.Entities.SecurityModels;

namespace qlsinhvien.Services;

public interface ITaiKhoanService
{
    public Task<string> DangKi(ModelDangKi model);

    public Task<ModelTraVe> DangNhap(ModelDangNhap model);
    public Task DangXuat(string token);
}