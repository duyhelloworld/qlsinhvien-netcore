using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;

namespace qlsinhvien.Services;

public interface IDiemSinhVienService
{
    public Task<ActionResult> GetAllAsync();
    public Task<ActionResult> GetByIdAsync(int maDiemSinhVien);
    public Task<ActionResult> GetByLopQuanLiAsync(int maDiemSinhVien);
    public Task<ActionResult> GetByLopMonHocAsync(ICollection<int> maDiemSinhViens);
    public Task<ActionResult> AddNewAsync(DiemSinhVienDto diemSinhVienDto);
    public Task<ActionResult> UpdateAsync(int maDiemSinhVien);
    public Task<ActionResult> RemoveAsync(int maDiemSinhVien);
    public Task<ActionResult> RemoveRangeAsync(ICollection<int> maDiemSinhViens);
}