using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class DiemSinhVien : IDiemSinhVienService
{
    private readonly ApplicationContext _context;

    public DiemSinhVien(ApplicationContext context)
    {
        _context = context;
    }

    // Task<Entities.DiemSinhVien> IDiemSinhVienService.AddNewAsync(DiemSinhVienDto diemSinhVienDto)
    // {
    //     throw new NotImplementedException();
    // }

    async Task<IEnumerable<Entities.DiemSinhVien>> IDiemSinhVienService.GetAllAsync()
    {
        return await _context.DiemSinhViens.ToListAsync();
    }

    public async Task<IEnumerable<DiemSinhVienDetail>> GetByIdAsync(int maSinhVien)
    {
        var kq = await _context.DiemSinhViens.FindAsync(maSinhVien);
        if (kq == null)
        {
            throw new HttpException(404, $"Không có điểm của sinh viên có mã {maSinhVien}");
        }

        var query = from diem in _context.DiemSinhViens
                    join lmh in _context.LopMonHocs on diem.MaLopMonHoc equals lmh.MaLopMonHoc
                    join mh in _context.MonHocs on lmh.MaMonHoc equals mh.MaMonHoc
                    join sv in _context.SinhViens on diem.MaSinhVien equals sv.MaSinhVien
                    where diem.MaSinhVien == maSinhVien
                    select new DiemSinhVienDetail
                    {
                        MaSinhVien = maSinhVien,
                        HoTen = sv.HoTen,
                        MaMonHoc = mh.MaMonHoc,
                        TenMonHoc = mh.TenMonHoc,
                        DiemChuyenCan = diem.DiemChuyenCan,
                        DiemGiuaKi = diem.DiemGiuaKi,
                        DiemCuoiKi = diem.DiemCuoiKi
                    };
        return await query.ToListAsync();
    }


    async Task<IEnumerable<DiemSinhVienDetail>> IDiemSinhVienService.GetByLopMonHocAsync(int maLopMonHoc)
    {
        var kq = await _context.LopMonHocs.FindAsync(maLopMonHoc);
        if (kq == null)
        {
            throw new HttpException(404, $"Không có điểm của lớp môn học có mã {maLopMonHoc}");
        }

        var query = from diem in _context.DiemSinhViens
                    join lmh in _context.LopMonHocs on diem.MaLopMonHoc equals lmh.MaLopMonHoc
                    join mh in _context.MonHocs on lmh.MaMonHoc equals mh.MaMonHoc
                    join sv in _context.SinhViens on diem.MaSinhVien equals sv.MaSinhVien
                    where diem.MaLopMonHoc == maLopMonHoc
                    select new DiemSinhVienDetail
                    {
                        MaLopMonHoc = maLopMonHoc,
                        HoTen = sv.HoTen,
                        MaMonHoc = mh.MaMonHoc,
                        TenMonHoc = mh.TenMonHoc,
                        DiemChuyenCan = diem.DiemChuyenCan,
                        DiemGiuaKi = diem.DiemGiuaKi,
                        DiemCuoiKi = diem.DiemCuoiKi
                    };

        return await query.ToListAsync();
    }

    async Task<IEnumerable<Entities.DiemSinhVienDetail>> IDiemSinhVienService.GetByLopQuanLiAsync(int maLopQuanLi)
    {
        var kq = await _context.LopQuanLis.FindAsync(maLopQuanLi);
        if (kq == null)
        {
            throw new HttpException(404, $"Không có điểm của lớp môn học có mã {maLopQuanLi}");
        }

        var query = from diem in _context.DiemSinhViens
                    join lmh in _context.LopMonHocs on diem.MaLopMonHoc equals lmh.MaLopMonHoc
                    join mh in _context.MonHocs on lmh.MaMonHoc equals mh.MaMonHoc
                    join sv in _context.SinhViens on diem.MaSinhVien equals sv.MaSinhVien
                    join lql in _context.LopQuanLis on sv.MaLopQuanLi equals lql.MaLopQuanLi
                    where lql.MaLopQuanLi == maLopQuanLi
                    select new DiemSinhVienDetail
                    {
                        MaLopQuanLi = maLopQuanLi,
                        HoTen = sv.HoTen,
                        MaMonHoc = mh.MaMonHoc,
                        TenMonHoc = mh.TenMonHoc,
                        DiemChuyenCan = diem.DiemChuyenCan,
                        DiemGiuaKi = diem.DiemGiuaKi,
                        DiemCuoiKi = diem.DiemCuoiKi
                    };

        return await query.ToListAsync();
    }

    async Task<Entities.DiemSinhVien> IDiemSinhVienService.RemoveAsync(int maSinhVien, DiemSinhVienDto diemSinhVienDto)
    {
        var diem = await _context.DiemSinhViens.FindAsync(maSinhVien);
        if (diem == null)
        {
            throw new HttpException(404, $"Không có điểm của sinh viên có mã {maSinhVien}");
        }
        diem.DiemChuyenCan = 0;
        diem.DiemGiuaKi = 0;
        diem.DiemCuoiKi = 0;
        _context.SaveChanges();
        return diem;
    }

    // Task<Entities.DiemSinhVien> IDiemSinhVienService.RemoveRangeAsync(ICollection<int> maDiemSinhViens)
    // {
    //     throw new NotImplementedException();
    // }

    async Task<Entities.DiemSinhVien> IDiemSinhVienService.UpdateAsync(int maSinhVien, DiemSinhVienDto diemSinhVienDto)
    {
        var diem = await _context.DiemSinhViens.FindAsync(maSinhVien);
        if (diem == null)
        {
            throw new HttpException(404, $"Không có điểm của sinh viên có mã {maSinhVien}");
        }
        diem.DiemChuyenCan = diemSinhVienDto.DiemChuyenCan;
        diem.DiemGiuaKi = diemSinhVienDto.DiemGiuaKi;
        diem.DiemCuoiKi = diemSinhVienDto.DiemCuoiKi;
        _context.SaveChanges();
        return diem;
    }

    public async Task<Entities.DiemSinhVien> UpdateTheoLopMonHoc(int maLopMonHoc, DiemSinhVienDto diemSinhVienDto)
    {
        var diem = await _context.DiemSinhViens.FindAsync(maLopMonHoc);
        if (diem == null)
        {
            throw new HttpException(404, $"Không có điểm của lớp môn học có mã {maLopMonHoc}");
        }
        diem.DiemChuyenCan = diemSinhVienDto.DiemChuyenCan;
        diem.DiemGiuaKi = diemSinhVienDto.DiemGiuaKi;
        diem.DiemCuoiKi = diemSinhVienDto.DiemCuoiKi;
        _context.SaveChanges();
        return diem;
    }

    public async Task<Entities.DiemSinhVien> RemoveTheoLopMonHoc(int maLopMonHoc, DiemSinhVienDto diemSinhVienDto)
    {
        var diem = await _context.DiemSinhViens.FindAsync(maLopMonHoc);
        if (diem == null)
        {
            throw new HttpException(404, $"Không có điểm của sinh viên có mã {maLopMonHoc}");
        }
        diem.DiemChuyenCan = 0;
        diem.DiemGiuaKi = 0;
        diem.DiemCuoiKi = 0;
        _context.SaveChanges();
        return diem;
    }
}