using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IDiemSinhVienService
{
    public Task<IEnumerable<DiemSinhVien>> GetAllAsync();
    public Task<IEnumerable<DiemSinhVienModel>> GetByIdAsync(int maSinhVien);
    public Task<IEnumerable<DiemSinhVienModel>> GetByLopQuanLiAsync(int maLopQuanLi);
    public Task<IEnumerable<DiemSinhVienModel>> GetByLopMonHocAsync(int maLopMonHoc);
    // public Task<DiemSinhVien> AddNewAsync(DiemSinhVienDto diemSinhVienDto);
    public Task<DiemSinhVien> UpdateAsync(int maSinhVien, DiemSinhVienDto diemSinhVienDto);
    public Task<DiemSinhVien> RemoveAsync(int maSinhVien, DiemSinhVienDto diemSinhVienDto);
    // public Task<DiemSinhVien> RemoveRangeAsync(ICollection<int> maDiemSinhViens);
    public Task<DiemSinhVien> UpdateTheoLopMonHoc(int maLopMonHoc, DiemSinhVienDto diemSinhVienDto);
    public Task<DiemSinhVien> RemoveTheoLopMonHoc(int maLopMonHoc, DiemSinhVienDto diemSinhVienDto);
    public Task DeleteByLopMonHoc(int maLopMonHoc);
}