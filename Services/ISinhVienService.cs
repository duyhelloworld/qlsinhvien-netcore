using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;

namespace qlsinhvien.Services;
public interface SinhVienService
{
    public Task<ActionResult> GetAllAsync();
    public Task<ActionResult> GetByIdAsync(int maSoSinhVien);
    public Task<ActionResult> GetByLopQuanLiAsync(int maLopQuanLi);
    public Task<ActionResult> AddNewAsync(SinhVienDto sinhVienDto);
    public Task<ActionResult> UpdateAsync(SinhVienDto sinhVienDto);
    public Task<ActionResult> RemoveAsync(int maSoSinhVien);
    public Task<ActionResult> RemoveRangeAsync(ICollection<int> maSoSinhViens);
}