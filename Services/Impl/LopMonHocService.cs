using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class LopMonHocService : ILopMonHocService
{
    private readonly ApplicationContext _context;
    private readonly IDiemSinhVienService _service;

    public LopMonHocService(ApplicationContext context, IDiemSinhVienService service)
    {
        _context = context;
        _service = service;
    }

    public async Task<LopMonHoc> AddNewAsync(LopMonHocDto lopMonHocDto)
    {
        var lopMonHoc = new LopMonHoc()
        {
            TenLopMonHoc = lopMonHocDto.TenLopMonHoc,
        };
        if (lopMonHocDto.MaGiangVien != 0)
        {
            var giangVien = await _context.GiangViens.FindAsync(lopMonHocDto.MaGiangVien)
                ?? throw new ServiceException(404, $"Không có giảng viên mã số {lopMonHocDto.MaGiangVien}");
            lopMonHoc.GiangVien = giangVien;
        }
        if (lopMonHocDto.MaMonHoc != 0)
        {
            var monHoc = await _context.MonHocs.FindAsync(lopMonHocDto.MaMonHoc)
                ?? throw new ServiceException(404, $"Không có môn học mã số {lopMonHocDto.MaMonHoc}");
            lopMonHoc.MonHoc = monHoc;
        }
        await _context.LopMonHocs.AddAsync(lopMonHoc);
        await _context.SaveChangesAsync();
        return lopMonHoc;
    }

    public async Task<IEnumerable<LopMonHoc>> GetAllAsync()
    {
        return await _context.LopMonHocs.ToListAsync();
    }

    public async Task<LopMonHoc?> GetByIdAsync(int maLopMonHoc)
    {
        return await _context.LopMonHocs.FindAsync(maLopMonHoc);
    }

    public Task<IEnumerable<LopMonHoc>> GetByTenAsync(string tenLopMonHoc)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LopMonHoc>> GetWithSiSoAsync()
    {
        throw new NotImplementedException();
    }
    public async Task RemoveTheoMonHoc(int maMonHoc)
    {
        var lop = await _context.LopMonHocs.FindAsync(maMonHoc) 
            ?? throw new ServiceException(404, $"Không tồn tại lớp môn học đang dạy môn học có mã {maMonHoc}");
        var Diems = from l in _context.LopMonHocs
                    join diem in _context.DiemSinhViens on l.MaLopMonHoc equals diem.MaLopMonHoc
                    where l.MaMonHoc == maMonHoc
                    select diem.MaLopMonHoc;
        foreach (var item in Diems)
        {
            await _service.DeleteByLopMonHoc(item);
        }
        var maLopMonHocs = from l in _context.LopMonHocs
                           where l.MaMonHoc == maMonHoc
                           select l;
        foreach (var item in maLopMonHocs)
        {
            _context.LopMonHocs.Remove(item);
        }
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int maLopMonHoc)
    {
        var lop = await _context.LopMonHocs.FindAsync(maLopMonHoc);
        if (lop == null)
        {
            throw new ServiceException(404, $"Không tồn tại lớp môn học có mã {maLopMonHoc}");
        }
        await _service.DeleteByLopMonHoc(maLopMonHoc);
        _context.LopMonHocs.Remove(lop);
        await _context.SaveChangesAsync();
    }

    public Task<LopMonHoc> UpdateAsync(int maLopMonHoc, LopMonHocDto lopMonHocDto)
    {
        throw new NotImplementedException();
    }
}