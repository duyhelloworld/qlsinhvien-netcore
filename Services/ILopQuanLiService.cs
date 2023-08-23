using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface ILopQuanLiService
{
    public Task<LopQuanLi> GetAll();
    public Task<LopQuanLi> GetWithSiSo();
    public Task<LopQuanLi> GetById(int maLopQuanLi);
    public Task<LopQuanLi> GetByTen(string tenLopQuanLi);
    public Task<LopQuanLi> AddNew(LopQuanLiDto lopQuanLiDto);
    public Task<LopQuanLi> Update(int maLopQuanLi, LopQuanLiDto lopQuanLiDto);
    public Task<LopQuanLi> Remove(int maLopQuanLi);
    public Task<LopQuanLi> RemoveRange(ICollection<int> maLopQuanLis);
}