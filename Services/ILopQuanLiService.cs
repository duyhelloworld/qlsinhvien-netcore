using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;

namespace qlsinhvien.Services;

public interface ILopQuanLiService
{
    public Task<ActionResult> GetAllAsync();
    public Task<ActionResult> GetWithSiSoAsync();
    public Task<ActionResult> GetByIdAsync(int maLopQuanLi);
    public Task<ActionResult> GetByTenAsync(string tenLopQuanLi);
    public Task<ActionResult> AddNewAsync(LopQuanLiDto lopQuanLiDto);
    public Task<ActionResult> UpdateAsync(int maLopQuanLi, LopQuanLiDto lopQuanLiDto);
    public Task<ActionResult> RemoveAsync(int maLopQuanLi);
    public Task<ActionResult> RemoveRangeAsync(ICollection<int> maLopQuanLis);
}