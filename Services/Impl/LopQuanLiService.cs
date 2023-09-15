using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class LopQuanLiService : ILopQuanLiService
{
    private readonly ApplicationContext _context;
    public LopQuanLiService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LopQuanLi>> GetAll()
    {
        return await _context.LopQuanLis.ToListAsync();
    }

    public async Task<LopQuanLi?> GetById(int maLopQuanLi)
    {
        return await _context.LopQuanLis.FindAsync(maLopQuanLi);
    }

    public async Task<IEnumerable<LopQuanLi>> GetByTen(string tenLopQuanLi)
    {
        return await _context.LopQuanLis
            .Where(lop => lop.TenLopQuanLi.Contains(tenLopQuanLi))
            .OrderBy(lop => lop.TenLopQuanLi)
            .ToListAsync();
    }

    public async Task<LopQuanLi> AddNew(LopQuanLiDto lopQuanLiDto)
    {
        var lopQuanLi = new LopQuanLi()
        {
            TenLopQuanLi = lopQuanLiDto.TenLopQuanLi,
        };
        var gv = await _context.LopQuanLis.FindAsync(lopQuanLiDto.MaGiangVien);
        if (lopQuanLiDto.MaGiangVien != 0 && gv == null)
        {
            var giangVien = await _context.GiangViens.FindAsync(lopQuanLiDto.MaGiangVien)
                ?? throw new ServiceException(404, $"Không có giảng viên mã số {lopQuanLiDto.MaGiangVien}");
            lopQuanLi.GiangVien = giangVien;
        }
        await _context.LopQuanLis.AddAsync(lopQuanLi);
        await _context.SaveChangesAsync();
        return lopQuanLi;
    }

    public Task<LopQuanLi> GetWithSiSo()
    {
        throw new NotImplementedException();
    }

    public async Task Remove(int maLopQuanLi)
    {
        var lop = await _context.LopQuanLis.FindAsync(maLopQuanLi)
        ??throw new ServiceException(404, $"Không tồn tại lớp quản lí có mã {maLopQuanLi}");
        _context.LopQuanLis.Remove(lop);
        await _context.SaveChangesAsync();
    }

    public async Task<LopQuanLi> Update(int maLopQuanLi, LopQuanLiDto lopQuanLiDto)
    {
        var lop = await _context.LopQuanLis.FindAsync(maLopQuanLi)
        ??throw new ServiceException(404, $"Không tồn tại lớp quản lí có mã {maLopQuanLi}");
        lop.TenLopQuanLi = lopQuanLiDto.TenLopQuanLi;
        lop.MaGiangVien = lopQuanLiDto.MaGiangVien;
        lop.MaKhoa = lopQuanLiDto.MaKhoa;
        await _context.SaveChangesAsync();
        return lop;
    }
}