using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IBoMonService
{
    public Task<IEnumerable<BoMon>> GetAllAsync();
    public Task<BoMon?> GetTheoMa(int MaBoMon);
    public Task<BoMon> Add(BoMonDto boMon);
    public Task<BoMon> Update(int MaBoMon, BoMonDto boMon);
    public Task Remove(int MaBoMon);
}