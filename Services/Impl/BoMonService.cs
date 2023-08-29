using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Controllers;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;
using qlsinhvien.Services;

namespace qlsinhvien.Services.Impl;
public class BoMonService : IBoMonService
{
    private readonly ApplicationContext _context;

    public BoMonService(ApplicationContext context)
    {
        _context = context;
    }

    async Task<IEnumerable<BoMon>> IBoMonService.GetAllAsync()
    {
        return await _context.BoMons.ToListAsync();
    }
}