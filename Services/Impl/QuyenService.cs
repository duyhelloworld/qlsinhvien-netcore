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

    public async Task<Quyen?> LayTheoId(int MaQuyen)
    {
        return await _context.Quyens.FindAsync(MaQuyen);
    }

    public async Task ThemQuyen(QuyenDto quyenDto)
    {
        using var context = _context.Database.BeginTransaction();
        await Task.CompletedTask;
    }

    public Task XoaQuyen(int MaQuyen)
    {
        throw new NotImplementedException();
    }
}