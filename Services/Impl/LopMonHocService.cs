using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class LopMonHocService : ILopMonHocService
{
    private readonly ApplicationContext _context;

    public LopMonHocService(ApplicationContext context, IDiemSinhVienService service)
    {
        _context = context;
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

    public async Task<IEnumerable<LopMonHoc>> GetByTenAsync(string tenLopMonHoc)
    {
        return await _context.LopMonHocs
            .Where(lop => lop.TenLopMonHoc.Contains(tenLopMonHoc))
            .OrderBy(lop => lop.TenLopMonHoc)
            .ToListAsync();
    }

    public async Task<IEnumerable<LopMonHoc>> GetWithSiSoAsync()
    {
        // var query = from lopMonHoc in _context.LopMonHocs
        //             join diemSinhVien in _context.DiemSinhViens on lopMonHoc.MaLopMonHoc equals diemSinhVien.MaLopMonHoc into diemGroup
        //             select new LopMonHocWithSoLuongSinhVien
        //             {
        //                 LopMonHoc = lopMonHoc,
        //                 SoLuongSinhVien = diemGroup.Count()
        //             };
        // return await query.ToListAsync();
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
            // await _service.DeleteByLopMonHoc(item);
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
        // await _service.DeleteByLopMonHoc(maLopMonHoc);
        _context.LopMonHocs.Remove(lop);
        await _context.SaveChangesAsync();
    }

    public async Task<LopMonHoc> UpdateAsync(int maLopMonHoc, LopMonHocDto lopMonHocDto)
    {
        var lop = await _context.LopMonHocs.FindAsync(maLopMonHoc);
        if(lop == null)
        {
            throw new ServiceException(404, $"Không tồn tại lớp môn học có mã {maLopMonHoc}");
        }
        lop.TenLopMonHoc = lopMonHocDto.TenLopMonHoc;
        lop.MaMonHoc = lopMonHocDto.MaMonHoc;
        lop.GiangVien.MaGiangVien = lopMonHocDto.MaGiangVien;
        _context.SaveChanges();
        return lop;
    }
    public async Task<IEnumerable<LopMonHoc>> GetByGiangVienAsync(int magiangvien)
    {
        var gv = await _context.GiangViens.FindAsync(magiangvien)
        ?? throw new ServiceException(404, $"Không tồn tại giảng viên có mã {magiangvien}");
        var lop = from l in _context.LopMonHocs
                  join magv in _context.GiangViens on l.GiangVien.MaGiangVien equals magv.MaGiangVien
                  where magv.MaGiangVien == magiangvien
                  select l;
        return await lop.ToListAsync();
    }
}