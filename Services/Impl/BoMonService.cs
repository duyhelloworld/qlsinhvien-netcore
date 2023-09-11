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


    public async Task<IEnumerable<BoMon>> GetAllAsync()
    {
        return await _context.BoMons.ToListAsync();
    }

    public async Task<BoMon?> GetTheoMa(int mabomon)
    {
        return await _context.BoMons.FindAsync(mabomon);
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
            var khoas = await _context.Khoas.Where(k => boMonDto.MaKhoas.Contains(k.MaKhoa))
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

    public async Task<BoMon> Update(int MaBoMon, BoMonDto boMonDto)
    {
        var boMon = await _context.BoMons.FindAsync(MaBoMon)
            ??   throw new ServiceException(400, "Bộ môn không tồn tại");
        boMon.TenBoMon = boMonDto.TenBoMon;
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
            var khoas = await _context.Khoas.Where(k => boMonDto.MaKhoas.Contains(k.MaKhoa))
                .ToListAsync();
            if (khoas.Count != 0)
            {
                boMon.Khoas = khoas;
            }
        }
        await _context.SaveChangesAsync();
        return boMon;
    }

    public async Task Remove(int MaBoMon)
    {
        var boMon = await _context.BoMons.FindAsync(MaBoMon)
            ?? throw new ServiceException(400, "Bộ môn không tồn tại");
        _context.KhoaBoMons.RemoveRange(_context.KhoaBoMons.Where(kbm => kbm.MaBoMon == MaBoMon));
        // _context.GiangViens
        //     .Where(gv => gv.BoMon.MaBoMon == MaBoMon)
        //     .ToList()
        //     .ForEach(gv => gv.BoMon = null);
        _context.BoMons.Remove(boMon);
        await _context.SaveChangesAsync();
    }

}