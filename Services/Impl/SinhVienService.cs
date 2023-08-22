using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class SinhVienService : ISinhVienService
{
    private readonly ApplicationContext _context;

    public SinhVienService(ApplicationContext applicationContext)
    {
        _context = applicationContext;
    }

    public async Task<IEnumerable<SinhVien>> GetAll()
    {
        return await _context.SinhViens.ToListAsync();
    }

    public async Task<IEnumerable<SinhVien>> GetByHoTen(string hoTen)
    {
        return await _context.SinhViens
            .Where(sv => sv.HoTen.Contains(hoTen))
            .OrderBy(sv => sv.HoTen)
            .ToListAsync();
    }

    public async Task<SinhVien?> GetById(int maSoSinhVien)
    {
        return await _context.SinhViens.FindAsync(maSoSinhVien);
    }

    public async Task<IEnumerable<SinhVien>> GetByLopQuanLi(int maLopQuanLi)
    {
        var lopQuanLi = await _context.LopQuanLis.FindAsync(maLopQuanLi);
        if (lopQuanLi == null)
        {
            throw new HttpException(404, $"Lớp quản lí mã số {maLopQuanLi} không tồn tại");
        }
        var sinhViens = await (from sv in _context.SinhViens
                                where sv.MaLopQuanLi == maLopQuanLi
                                select sv).ToListAsync();
        return sinhViens;
    }

    public async Task<IEnumerable<SinhVien>> GetByLopMonHoc(int maLopMonHoc)
    {
        var lopMonHoc = await _context.LopMonHocs.FindAsync(maLopMonHoc);
        if (lopMonHoc == null)
        {
            throw new HttpException(404, $"Không tồn tại lớp môn học mã số {maLopMonHoc}");
        }
        var maSinhViens = from dsv in _context.DiemSinhViens
                where dsv.MaLopMonHoc == maLopMonHoc
                select dsv.MaSinhVien;
        if (maSinhViens.Count() == 0) {
            return Enumerable.Empty<SinhVien>();
        }
        var sinhViens = from sv in _context.SinhViens
                        where maSinhViens.Contains(sv.MaSinhVien)
                        select sv;
        return sinhViens;
    }

    public async Task<SinhVien> AddNew(SinhVienDto sinhVienDto)
    {
        var lopQuanLi = await _context.LopQuanLis.FindAsync(sinhVienDto.MaLopQuanLi);
        if (lopQuanLi == null) {
            throw new HttpException(404, $"Không tồn tại lớp quản lí mã {sinhVienDto.MaLopQuanLi}");
        }
        var trungSdtHoacEmail = await _context.SinhViens
            .FirstOrDefaultAsync(sv => sv.SoDienThoai.Equals(sinhVienDto.SoDienThoai)
                || sv.Email.Equals(sinhVienDto.Email));
        if (trungSdtHoacEmail != null)
        {
            string msg = "";
            if (trungSdtHoacEmail.SoDienThoai.Equals(sinhVienDto.SoDienThoai))
            {
                msg = $"Số điện thoại {sinhVienDto.SoDienThoai} đã được sử dụng";
            }
            else
            {
                msg = $"Email {sinhVienDto.Email} đã được sử dụng";
            }
            throw new HttpException(400, msg);
        }

        var sinhVien = new SinhVien()
        {
            HoTen = sinhVienDto.HoTen,
            GioiTinh = sinhVienDto.GioiTinh,
            NgaySinh = sinhVienDto.NgaySinh,
            QueQuan = sinhVienDto.QueQuan,
            DiaChiThuongTru = sinhVienDto.DiaChiThuongTru,
            NgayVaoTruong = sinhVienDto.NgayVaoTruong,
            SoDienThoai = sinhVienDto.SoDienThoai,
            Email = sinhVienDto.Email,
            LopQuanLi = lopQuanLi
        };
        await _context.SinhViens.AddAsync(sinhVien);
        return sinhVien;
    }

    public async Task<SinhVien> UpdateProfile(int maSoSinhVien, SinhVienDto sinhVienDto)
    {
        sinhVienDto.MaSinhVien = maSoSinhVien;
        var lopQuanLi = await _context.LopQuanLis.FindAsync(sinhVienDto.MaLopQuanLi);
        if (lopQuanLi == null)
        {
            throw new HttpException(404, $"Không tồn tại lớp quản lí mã {sinhVienDto.MaLopQuanLi}");
        }

        var sinhVien = await _context.SinhViens.FindAsync(maSoSinhVien);
        if (sinhVien == null)
        {
            throw new HttpException(404, $"Không tồn tại sinh viên mã số {maSoSinhVien}");
        }
        sinhVien.HoTen = sinhVienDto.HoTen;
        sinhVien.GioiTinh = sinhVienDto.GioiTinh;
        sinhVien.NgaySinh = sinhVienDto.NgaySinh;
        sinhVien.QueQuan = sinhVienDto.QueQuan;
        sinhVien.DiaChiThuongTru = sinhVienDto.DiaChiThuongTru;
        sinhVien.NgayVaoTruong = sinhVienDto.NgayVaoTruong;
        sinhVien.SoDienThoai = sinhVienDto.SoDienThoai;
        sinhVien.Email = sinhVienDto.Email;
        sinhVien.LopQuanLi = lopQuanLi;
        await _context.SaveChangesAsync();
        return sinhVien;
    }
    public async Task Remove(int maSoSinhVien)
    {
        var sinhVien = await _context.SinhViens.FindAsync(maSoSinhVien);
        if (sinhVien == null)
        {
            throw new HttpException(404, $"Không tồn tại sinh viên mã số {maSoSinhVien}");
        }
        var diems = from dsv in _context.DiemSinhViens
                    where dsv.MaSinhVien == maSoSinhVien
                    select dsv;
        if (diems != null) {
            _context.DiemSinhViens.RemoveRange(diems);
        }
        _context.SinhViens.Remove(sinhVien);
        await _context.SaveChangesAsync();
    }
}