using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IMonHocService
{
    public Task<IEnumerable<MonHoc>> GetAll();
    public Task<MonHoc?> GetById(int maSoMonHoc);
    public Task<IEnumerable<MonHoc>> GetByTenMon(string tenMonHoc);
    public Task<MonHoc> AddNew(MonHocDto monHocDto);
    public Task<MonHoc> Update(int maSoMonHoc, MonHocDto monHocDto);
    public Task Remove(int maSoMonHoc);
}