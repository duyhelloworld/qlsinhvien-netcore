using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class BoMonService : IBoMonService
{
    private readonly ApplicationContext _context;

    public BoMonService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BoMon>> GetAllAsync()
    {
        return await _context.BoMons.ToListAsync();
    }

    public async Task<BoMon?> GetTheoMa(int mabomon)
    {
        return await _context.BoMons.FindAsync(mabomon);
    }

    public async Task<BoMon?> GetTheoGiangVien(int MaGiangVien)
    {
        var giangVien = await _context.GiangViens.FindAsync(MaGiangVien)
            ?? throw new ServiceException(404, "Giảng viên không tồn tại");
        return await _context.BoMons
            .FirstOrDefaultAsync(bm => bm.GiangViens.Contains(giangVien));
    }

    public async Task<IEnumerable<BoMon>> GetTheoKhoa(int MaKhoa)
    {
        var khoa = await _context.Khoas.FindAsync(MaKhoa)
            ?? throw new ServiceException(404, "Khoa không tồn tại");
        return await _context.KhoaBoMons
            .Where(kbm => kbm.Khoa == khoa)
            .Select(kbm => kbm.BoMon)
            .ToListAsync();
    }

    public async Task<BoMon?> GetTheoMonHoc(int MaMonHoc)
    {
        var monHoc = await _context.MonHocs.FindAsync(MaMonHoc)
            ?? throw new ServiceException(404, "Môn học không tồn tại");
        return await _context.BoMons
            .FirstOrDefaultAsync(bm => bm.MonHocs.Contains(monHoc));
    }

    public async Task<BoMon> Add(BoMonDto boMonDto)
    {
        var boMon = new BoMon
        {
            TenBoMon = boMonDto.TenBoMon,
            MaBoMon = 0
        };
        if (boMonDto.MaGiangViens != null && boMonDto.MaGiangViens.Count != 0)
        {
            var giangViens = await _context.GiangViens.Where(gv => boMonDto.MaGiangViens.Contains(gv.MaGiangVien))
                .ToListAsync();
            if (giangViens.Count != 0)
            {
                boMon.GiangViens = giangViens;
            }
        }
        if (boMonDto.MaMonHocs != null)
        {
            var monHocs = await _context.MonHocs.Where(mh => boMonDto.MaMonHocs.Contains(mh.MaMonHoc))
                .ToListAsync();
            if (monHocs.Count != 0)
            {
                boMon.MonHocs = monHocs;
            }
        }
        if (boMonDto.MaKhoas != null)
        {
            var khoas = await _context.KhoaBoMons
                .Where(kbm => boMonDto.MaKhoas.Contains(kbm.MaKhoa))
                .ToListAsync();
            if (khoas.Count != 0)
            {
                boMon.Khoas = khoas;
            }
        }
        await _context.BoMons.AddAsync(boMon);
        await _context.SaveChangesAsync();
        return boMon;
    }

    public async Task<BoMon> UpdateTen(int MaBoMon, string TenBoMon)
    {
        var boMon = await _context.BoMons.FindAsync(MaBoMon)
            ??   throw new ServiceException(404, "Bộ môn không tồn tại");
        boMon.TenBoMon = TenBoMon;
        await _context.SaveChangesAsync();
        return boMon;
    }

    public async Task<BoMon> UpdateGiangVien(int MaBoMon, IEnumerable<int> MaGiangViens)
    {
        var boMon = await _context.BoMons.FindAsync(MaBoMon)
            ?? throw new ServiceException(400, "Bộ môn không tồn tại");
        var giangViens = await _context.GiangViens.Where(gv => MaGiangViens.Contains(gv.MaGiangVien))
                .ToListAsync();
        if (giangViens.Count != 0)
        {
            boMon.GiangViens = giangViens;
        }
        await _context.SaveChangesAsync();
        return boMon;
    }

    public async Task<BoMon> UpdateMonHoc(int MaBoMon, IEnumerable<int> MaMonHocs)
    {
        var boMon = await _context.BoMons.FindAsync(MaBoMon)
            ?? throw new ServiceException(404, "Bộ môn không tồn tại");
        var monHocs = await _context.MonHocs.Where(mh => MaMonHocs.Contains(mh.MaMonHoc))
                .ToListAsync();
        if (monHocs.Count != 0)
        {
            boMon.MonHocs = monHocs;
        }
        await _context.SaveChangesAsync();
        return boMon;
    }

    public async Task<BoMon> UpdateKhoa(int MaBoMon, IEnumerable<int> MaKhoas)
    {
        var boMon = await _context.BoMons.FindAsync(MaBoMon)
            ?? throw new ServiceException(404, "Bộ môn không tồn tại");
        var khoas = await _context.KhoaBoMons.Where(kbm => MaKhoas.Contains(kbm.MaKhoa))
                .ToListAsync();
        if (khoas.Count != 0)
        {
            boMon.Khoas = khoas;
        }
        await _context.SaveChangesAsync();
        return boMon;
    }


    public async Task Remove(int MaBoMon)
    {
        var boMon = await _context.BoMons
            .Include(bm => bm.GiangViens)
            .Include(bm => bm.Khoas)
            .Include(bm => bm.MonHocs)
            .FirstOrDefaultAsync(bm => bm.MaBoMon == MaBoMon)
            ?? throw new ServiceException(400, "Bộ môn không tồn tại");
        if (boMon.GiangViens.Count != 0)
        {
            throw new ServiceException(400, "Bộ môn đang có giảng viên dạy học",
                 "Hãy thử cập nhật bộ môn cho các giảng viên này trước",
                 boMon.GiangViens);
        }
        if (boMon.Khoas.Count != 0)
        {
            throw new ServiceException(400, "Bộ môn đang có khoa",
                "Hãy thử cập nhật bộ môn cho các khoa này trước",
                 boMon.Khoas);
        }
        if (boMon.MonHocs.Count != 0)
        {
            throw new ServiceException(400, "Bộ môn đang có môn học", 
                "Hãy thử cập nhật bộ môn cho các môn học này trước",
                 boMon.MonHocs);
        }
        _context.BoMons.Remove(boMon);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveKhoas(int MaBoMon)
    {
        var boMon = await _context.BoMons.Include(bm => bm.Khoas).FirstOrDefaultAsync(bm => bm.MaBoMon == MaBoMon)
            ?? throw new ServiceException(404, "Bộ môn không tồn tại");
        boMon.Khoas.Clear();
        await _context.SaveChangesAsync();
    }
}