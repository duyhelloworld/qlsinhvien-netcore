using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IDiemSinhVienService
{
    public Task<IEnumerable<DiemSinhVien>> GetAllAsync();
    public Task<IEnumerable<DiemSinhVienDetail>> GetByIdAsync(int maSinhVien);
    public Task<IEnumerable<DiemSinhVienDetail>> GetByLopQuanLiAsync(int maLopQuanLi);
    public Task<IEnumerable<DiemSinhVienDetail>> GetByLopMonHocAsync(int maLopMonHoc);
    // public Task<DiemSinhVien> AddNewAsync(DiemSinhVienDto diemSinhVienDto);
    public Task<DiemSinhVien> UpdateAsync(int maSinhVien, DiemSinhVienDto diemSinhVienDto);
    public Task<DiemSinhVien> RemoveAsync(int maSinhVien, DiemSinhVienDto diemSinhVienDto);
    // public Task<DiemSinhVien> RemoveRangeAsync(ICollection<int> maDiemSinhViens);
}