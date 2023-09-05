using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IBoMonService
{
    public Task<IEnumerable<BoMon>> GetAllAsync();
}