using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;
public class MonHocService : IMonHocService
{
    private readonly ApplicationContext _context;

    public MonHocService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<MonHoc> AddNew(MonHocDto monHocDto)
    {
        var boMon = await _context.BoMons.FindAsync(monHocDto.MaBoMon);
        if (boMon == null)
        {
            throw new HttpException(404, $"Không tồn tại bộ môn{boMon}");
        }
        var mh = new MonHoc()
        {
            MaMonHoc = 0,
            TenMonHoc = monHocDto.TenMonHoc,
            SoTinChi = monHocDto.SoTinChi,
            BatBuoc = monHocDto.BatBuoc,
            MoTa = monHocDto.MoTa,
            BoMon = boMon
        };
        await _context.MonHocs.AddAsync(mh);
        await _context.SaveChangesAsync();

        return mh;
    }


    async Task<IEnumerable<MonHoc>> IMonHocService.GetAll()
    {
        return await _context.MonHocs.ToListAsync();
    }

    async Task<MonHoc> IMonHocService.GetById(int maSoMonHoc)
    {
        var mh = await _context.MonHocs.FindAsync(maSoMonHoc);
        return mh;
    }

    async Task<IEnumerable<MonHoc>> IMonHocService.GetByTenMon(string tenMonHoc)
    {
        return await _context.MonHocs
            .Where(mh => mh.TenMonHoc.Contains(tenMonHoc))
            .OrderBy(mh => mh.TenMonHoc)
            .ToListAsync();
    }

    public async Task<MonHoc> Remove(int maSoMonHoc)
    {
        var mh = await _context.MonHocs.FindAsync(maSoMonHoc);

        if (mh == null)
        {
            throw new HttpException(404, $"Không tồn tại môn học có mã môn học: {maSoMonHoc}.");
        }

        _context.MonHocs.Remove(mh);
        await _context.SaveChangesAsync();

        return mh;
    }



    // Task<MonHoc> IMonHocService.RemoveRange(ICollection<int> maSoMonHocs)
    // {
    //     throw new NotImplementedException();
    // }

    async Task<MonHoc> IMonHocService.Update(int maSoMonHoc, MonHocDto monHocDto)
    {
        var mh = await _context.MonHocs.FindAsync(maSoMonHoc);
        if (mh == null)
        {
            throw new HttpException(404, $"Không tồn tại môn học có mã môn học: {maSoMonHoc}.");
        }
        var boMon = await _context.BoMons.FindAsync(monHocDto.MaBoMon);
        if (boMon == null)
        {
            throw new HttpException(404, $"Không tồn tại bộ môn có mã: {monHocDto.MaBoMon}.");
        }
        monHocDto.MaMonHoc = maSoMonHoc;
        mh.TenMonHoc = monHocDto.TenMonHoc;
        mh.SoTinChi = monHocDto.SoTinChi;
        mh.BatBuoc = monHocDto.BatBuoc;
        mh.MoTa = monHocDto.MoTa;
        mh.BoMon = boMon;
        await _context.SaveChangesAsync();
        return mh;
    }
}