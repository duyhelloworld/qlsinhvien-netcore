using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Services.Impl;

public class QuyenService : IQuyenService
{
    private readonly ApplicationContext _context;

    public QuyenService(ApplicationContext context)
    {
        _context = context;
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
        try
        {
            var quyen = new Quyen()
            {
                TenQuyen = quyenDto.TenQuyen,
                GhiChu = quyenDto.GhiChu
            };
            await _context.Quyens.AddAsync(quyen);
            await _context.SaveChangesAsync();
            await context.CommitAsync();
        }
        catch (Exception e)
        {
            await context.RollbackAsync();
            throw new Exception(e.Message);
        }
    }

    public async Task CapNhatQuyen(string TenQuyen, QuyenDto quyenDto)
    {
        using var context = _context.Database.BeginTransaction();
        try
        {
            var quyen = await _context.Quyens.FindAsync(TenQuyen) 
                ?? throw new Exception("Không tìm thấy quyền");
            quyen.TenQuyen = quyenDto.TenQuyen;
            quyen.GhiChu = quyenDto.GhiChu;
            await _context.SaveChangesAsync();
            await context.CommitAsync();
        }
        catch (Exception e)
        {
            await context.RollbackAsync();
            throw new Exception(e.Message);
        }
    }

    public async Task XoaQuyen(string TenQuyen)
    {
        using var context = _context.Database.BeginTransaction();
        try
        {
            var quyen = await _context.Quyens.FindAsync(TenQuyen) 
                ?? throw new Exception("Không tìm thấy quyền");
            _context.QuyenVaiTros.RemoveRange(_context.QuyenVaiTros.Where(qvt => qvt.TenQuyen == TenQuyen));
            _context.Quyens.Remove(quyen);
            await _context.SaveChangesAsync();
            await context.CommitAsync();
        }
        catch (Exception e)
        {
            await context.RollbackAsync();
            throw new Exception(e.Message);
        }
    }
}