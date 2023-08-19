using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;

namespace qlsinhvien.Services;

public interface IMonHocService
{
    public Task<ActionResult> GetAllAsync();
    public Task<ActionResult> GetByIdAsync(int maSoMonHoc);
    public Task<ActionResult> GetByTenMonAsync(string tenMonHoc);
    public Task<ActionResult> AddNewAsync(MonHocDto monHocDto);
    public Task<ActionResult> UpdateAsync(int maSoMonHoc, MonHocDto monHocDto);
    public Task<ActionResult> RemoveAsync(int maSoMonHoc);
    public Task<ActionResult> RemoveRangeAsync(ICollection<int> maSoMonHocs);
}