using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class DiemSinhVienService : IDiemSinhVienService
{
    private readonly ApplicationContext _context;

    public DiemSinhVienService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DiemSinhVienDetail>> GetAll()
    {
        return await _context.DiemSinhViens
            .Select(s => DiemSinhVienDetail.Convert(s))
            .ToListAsync();
    }

    public async Task<IEnumerable<DiemSinhVienDetail>> GetById(int maSinhVien)
    {
        return await _context.DiemSinhViens
            .Where(s => s.MaSinhVien == maSinhVien)
            .Select(s => DiemSinhVienDetail.Convert(s))
            .ToListAsync();
    }

    public async Task<IEnumerable<DiemSinhVienDetail>> GetByLopQuanLi(int maLopQuanLi)
    {
        return await _context.DiemSinhViens
            .Include(s => s.SinhVien)
            .Where(s => s.SinhVien.MaLopQuanLi == maLopQuanLi)
            .Select(s => DiemSinhVienDetail.Convert(s))
            .ToListAsync();
    }

    public async Task<IEnumerable<DiemSinhVienDetail>> GetByLopMonHoc(int maLopMonHoc)
    {
        return await _context.DiemSinhViens
            .Include(s => s.LopMonHoc)
            .Where(s => s.MaLopMonHoc == maLopMonHoc)
            .Select(s => DiemSinhVienDetail.Convert(s))
            .ToListAsync();
    }

    public async Task<DiemSinhVienDetail> ThemMoi(DiemSinhVienDto diemSinhVienDto)
    {
        var sinhVien = await _context.SinhViens.FindAsync(diemSinhVienDto.MaSinhVien)
            ?? throw new ServiceException(404, $"Không tồn tại sinh viên có mã {diemSinhVienDto.MaSinhVien}");
        var lopMonHoc = await _context.LopMonHocs.FindAsync(diemSinhVienDto.MaLopMonHoc)
            ?? throw new ServiceException(404, $"Không tồn tại lớp môn học có mã {diemSinhVienDto.MaLopMonHoc}");
        var diem = await _context.DiemSinhViens.FindAsync(diemSinhVienDto.MaSinhVien, diemSinhVienDto.MaLopMonHoc)
            ?? throw new ServiceException(400, @$"Sinh viên mã {diemSinhVienDto.MaSinhVien} họ tên 
                {sinhVien.HoTen} tại lớp môn học {lopMonHoc.TenLopMonHoc} đã tồn tại!!!");
        var diemSinhVien = DiemSinhVienDto.Convert(diemSinhVienDto);
        await _context.DiemSinhViens.AddAsync(diemSinhVien);
        await _context.SaveChangesAsync();
        return DiemSinhVienDetail.Convert(diemSinhVien);
    }

    public async Task<DiemSinhVienDetail> SuaDiemVaGhiChu(int maSinhVien, DiemSinhVienDto diemSinhVienDto)
    {
        var diem = await _context.DiemSinhViens.FindAsync(maSinhVien, diemSinhVienDto.MaLopMonHoc)
            ?? throw new ServiceException(404, $"Không tồn tại điểm của sinh viên có mã {maSinhVien} tại lớp môn học có mã {diemSinhVienDto.MaLopMonHoc}");
        diem.DiemChuyenCan = diemSinhVienDto.DiemChuyenCan;
        diem.DiemGiuaKi = diemSinhVienDto.DiemGiuaKi;
        diem.DiemCuoiKi = diemSinhVienDto.DiemCuoiKi;
        diem.GhiChu = diemSinhVienDto.GhiChu;
        await _context.SaveChangesAsync();
        return DiemSinhVienDetail.Convert(diem);
    }

    public async Task XoaTheoLopMonHoc(int maSinhVien, int MaLopMonHoc)
    {
        var diem = await _context.DiemSinhViens.FindAsync(maSinhVien, MaLopMonHoc)
            ?? throw new ServiceException(404, $"Không tồn tại điểm của sinh viên có mã {maSinhVien} tại lớp môn học có mã {MaLopMonHoc}");
        diem.DiemChuyenCan = null;
        diem.DiemGiuaKi = null;
        diem.DiemCuoiKi = null;
        await _context.SaveChangesAsync();
    }

    public async Task XoaKhoiLopMonHoc(int maSinhVien, int maLopMonHoc)
    {
        var diem = await _context.DiemSinhViens.FindAsync(maSinhVien, maLopMonHoc)
            ?? throw new ServiceException(404, $"Không tồn tại sinh viên có mã {maSinhVien} trong lớp môn học có mã {maLopMonHoc}");
        _context.DiemSinhViens.Remove(diem);
        await _context.SaveChangesAsync();
    }

    public async Task XoaLopMonHoc(int maLopMonHoc)
    {
        var diems = await _context.DiemSinhViens
            .Where(dsv => dsv.MaLopMonHoc == maLopMonHoc)
            .ToListAsync();
        if (diems.Count == 0)
        {
            throw new ServiceException(404, $"Lớp môn học có mã {maLopMonHoc} chưa có sinh viên nào theo học!");
        }
        _context.DiemSinhViens.RemoveRange(diems);
        await _context.SaveChangesAsync();
    }

    public async Task XoaSinhVien(int maSinhVien)
    {
        var diems = await _context.DiemSinhViens
            .Where(dsv => dsv.MaSinhVien == maSinhVien)
            .ToListAsync();
        if (diems.Count == 0)
        {
            throw new ServiceException(404, $"Sinh viên có mã {maSinhVien} chưa có điểm nào!");
        }
        _context.DiemSinhViens.RemoveRange(diems);
        await _context.SaveChangesAsync();
    }
}