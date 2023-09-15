using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Atributes;
using qlsinhvien.Context;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class QuyenService : IQuyenService
{
    private readonly ApplicationContext _context;

    public QuyenService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<QuyenDto>> LayTatCa()
    {
        return await _context.Quyens
            .Select(q => QuyenDto.Convert(q))
            .ToListAsync();
    }

    public async Task<IEnumerable<QuyenDto>> LayTheoTen(string TenQuyen)
    {
        return await _context.Quyens
            .Where(q => q.TenQuyen.Contains(TenQuyen))
            .Select(q => QuyenDto.Convert(q))
            .ToListAsync();
    }

    public async Task<IEnumerable<QuyenDto>> LayTheoVaiTro(string TenVaiTro)
    {
        var vaiTro = await _context.VaiTros.FindAsync(TenVaiTro)
            ?? throw new Exception("Vai trò không tồn tại");
        return await _context.QuyenVaiTros
            .Where(qvt => qvt.TenVaiTro == vaiTro.TenVaiTro)
            .Select(qvt => QuyenDto.Convert(qvt.Quyen))
            .ToListAsync();
    }

    public async Task<IEnumerable<string>> LayTatCaApiDangDung(string TenQuyen)
    {
        if (!await _context.Quyens.AnyAsync(q => q.TenQuyen == TenQuyen))
        {
            throw new ServiceException(404, "Quyền không tồn tại");
        }
        Enum.TryParse(typeof(PhanQuyen), TenQuyen, out var quyenEnum);
        if (quyenEnum == null)
        {
            throw new ServiceException(404, "Quyền không tồn tại");    
        }
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => typeof(ControllerBase).IsAssignableTo(t) && !t.IsAbstract);
        var ketQua = new List<string>();
        foreach (var type in types)
        {
            foreach (var method in type.GetMethods())
            {
                var attr = method.GetCustomAttribute<PhanQuyen>();
                if (attr != null)
                {
                    foreach (var ten in attr.TenQuyen)
                    {
                        if (ten == (EQuyen)quyenEnum)
                        {
                            ketQua.Add(method.Name);
                        }
                    }
                    ketQua.Add(method.Name);
                }
            }
        }
        return ketQua;
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

    // public async Task XoaQuyen(string TenQuyen)
    // {
    //     using var context = _context.Database.BeginTransaction();
    //     try
    //     {
    //         var quyen = await _context.Quyens.FindAsync(TenQuyen) 
    //             ?? throw new Exception("Không tìm thấy quyền");
    //         _context.QuyenVaiTros.RemoveRange(_context.QuyenVaiTros.Where(qvt => qvt.TenQuyen == TenQuyen));
    //         _context.Quyens.Remove(quyen);
    //         await _context.SaveChangesAsync();
    //         await context.CommitAsync();
    //     }
    //     catch (Exception e)
    //     {
    //         await context.RollbackAsync();
    //         throw new Exception(e.Message);
    //     }
    // }
}