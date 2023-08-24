using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;

namespace qlsinhvien.Services;

public interface ILopMonHocService
{
    public Task<ActionResult> GetAllAsync();
    public Task<ActionResult> GetWithSiSoAsync();
    public Task<ActionResult> GetByIdAsync(int maLopMonHoc);
    public Task<ActionResult> GetByTenAsync(string tenLopMonHoc);
    public Task<ActionResult> AddNewAsync(LopMonHocDto lopMonHocDto);
    public Task<ActionResult> UpdateAsync(int maLopMonHoc, LopMonHocDto lopMonHocDto);
    public Task RemoveAsync(int maLopMonHoc);
    public Task<ActionResult> RemoveRangeAsync(ICollection<int> maLopMonHocs);
    public Task RemoveTheoMonHoc(int maMonHoc);
}