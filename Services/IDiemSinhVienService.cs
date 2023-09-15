using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IDiemSinhVienService
{
    public Task<IEnumerable<DiemSinhVienDetail>> GetAll();
    public Task<IEnumerable<DiemSinhVienDetail>> GetById(int maSinhVien);
    public Task<IEnumerable<DiemSinhVienDetail>> GetByLopQuanLi(int maLopQuanLi);
    public Task<IEnumerable<DiemSinhVienDetail>> GetByLopMonHoc(int maLopMonHoc);
    public Task<DiemSinhVienDetail> ThemMoi(DiemSinhVienDto diemSinhVienDto);
    public Task<DiemSinhVienDetail> SuaDiemVaGhiChu(int maSinhVien, DiemSinhVienDto diemSinhVienDto);
    public Task XoaTheoLopMonHoc(int maSinhVien, int MaLopMonHoc);
    public Task XoaKhoiLopMonHoc(int maSinhVien, int MaLopMonHoc);
    public Task XoaLopMonHoc(int maLopMonHoc);
    public Task XoaSinhVien(int maSinhVien);

}