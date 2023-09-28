using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Atributes;
using qlsinhvien.Context;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;
using qlsinhvien.Models;

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

    public async Task<IEnumerable<QuyenDetail>> LayTheoNguoiDung()
    {
        return from nd in _context.NguoiDungs
            join qvt in _context.QuyenVaiTros on nd.TenVaiTro equals qvt.TenVaiTro
            join q in _context.Quyens on qvt.TenQuyen equals q.TenQuyen
            select new QuyenDetail
            {
                TenNguoiDung = nd.TenNguoiDung,
                TenVaiTro = nd.TenVaiTro ?? "",
                Quyens = new HashSet<QuyenDto> { QuyenDto.Convert(q) }
            };
    }

    public async Task<IEnumerable<QuyenDto>> LayTheoTen(string TenQuyen)
    {
        return await _context.Quyens
            .Where(q => q.TenQuyen.Contains(TenQuyen))
            .Select(q => QuyenDto.Convert(q))
            .ToListAsync();
    }

    public async Task<IEnumerable<QuyenDto>> LayTheoTenNguoiDung(string TenNguoiDung)
    {
        var nd = await _context.NguoiDungs.FindAsync(TenNguoiDung)
            ?? throw new Exception("Người dùng không tồn tại");
        return await (from qvt in _context.QuyenVaiTros
                      join q in _context.Quyens on qvt.TenQuyen equals q.TenQuyen
                      where qvt.TenVaiTro == nd.TenVaiTro
                      select QuyenDto.Convert(q)
        ).ToListAsync();
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
}