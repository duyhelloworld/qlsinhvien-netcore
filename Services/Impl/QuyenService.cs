using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Services.Impl;

public class QuyenService : IQuyenService
{
    private readonly ApplicationContext _context;

    public QuyenService(ApplicationContext applicationContext)
    {
        _context = applicationContext;
    }

    public async Task<IEnumerable<Quyen>> LayTatCa()
    {
        return await _context.Quyens.ToListAsync();
    }

    public async Task<Quyen?> LayTheoTen(string TenQuyen)
    {
        return await _context.Quyens.FindAsync(TenQuyen);
    }

    public async Task ThemQuyen(QuyenDto quyenDto)
    {
        using var context = _context.Database.BeginTransaction();
        await Task.CompletedTask;
    }

    public Task XoaQuyen(string TenQuyen)
    {
        throw new NotImplementedException();
    }
}