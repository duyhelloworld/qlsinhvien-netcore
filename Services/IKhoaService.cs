using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;

namespace qlsinhvien.Services;

public interface IKhoaService
{
    public Task<ActionResult> GetAllAsync();
    public Task<ActionResult> GetByIdAsync(int maKhoa);
    public Task<ActionResult> GetByTenAsync(string tenKhoa);
    public Task<ActionResult> AddNewAsync(KhoaDto KhoaDto);
    public Task<ActionResult> UpdateAsync(int maKhoa, KhoaDto KhoaDto);
    public Task<ActionResult> RemoveAsync(int maKhoa);
}