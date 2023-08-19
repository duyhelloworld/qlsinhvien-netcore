using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IGiangVienService
{
    public Task<IEnumerable<GiangVien>> GetAllAsync();
    public Task<GiangVien?> GetByIdAsync(int maSoGiangVien);
    public Task<IEnumerable<GiangVien>> GetByTenAsync(string tenGiangVien);
    public Task<GiangVien?> GetByLopQuanLiAsync(int maLopQuanLi);
    public Task<GiangVien?> GetByLopMonHocAsync(int maLopMonHoc);
    public Task<GiangVien?> GetByLopMonHocAsync(IEnumerable<int> maLopMonHocs);
    public Task<IEnumerable<GiangVien>> GetByBoMonAsync(int maBoMon);
    public Task<GiangVien> AddNewAsync(GiangVienDto giangVienDto);
    public Task<GiangVien> UpdateAsync(int maGiangVien, GiangVienDto giangVienDto);
    public Task RemoveAsync(int maGiangVien);
    public Task<int> RemoveRangeAsync(ICollection<int> maGiangViens);
}