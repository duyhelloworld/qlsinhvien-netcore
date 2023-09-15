using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface ILopMonHocService
{
    public Task<IEnumerable<LopMonHoc>> GetAllAsync();    
    public Task<IEnumerable<LopMonHoc>> GetWithSiSoAsync();
    public Task<LopMonHoc?> GetByIdAsync(int maLopMonHoc);
    public Task<IEnumerable<LopMonHoc>> GetByGiangVienAsync(int magiangvien);
    public Task<IEnumerable<LopMonHoc>> GetByTenAsync(string tenLopMonHoc);
    public Task<LopMonHoc> AddNewAsync(LopMonHocDto lopMonHocDto);
    public Task<LopMonHoc> UpdateAsync(int maLopMonHoc, LopMonHocDto lopMonHocDto);
    public Task RemoveAsync(int maLopMonHoc);
    public Task RemoveTheoMonHoc(int maMonHoc);
}