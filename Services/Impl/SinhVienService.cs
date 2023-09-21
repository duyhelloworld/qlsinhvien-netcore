using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;
using qlsinhvien.Services.Impl.Validators;

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
            throw new ServiceException(404, $"Lớp quản lí mã số {maLopQuanLi} không tồn tại");
        }
        var sinhViens = await (from sv in _context.SinhViens
                                where sv.MaLopQuanLi == maLopQuanLi
                                select sv).ToListAsync();
        return sinhViens;
    }

    public async Task<IEnumerable<SinhVien>> GetByLopMonHoc(int maLopMonHoc)
    {
        var lopMonHoc = await _context.LopMonHocs.FindAsync(maLopMonHoc) 
            ?? throw new ServiceException(404, $"Không tồn tại lớp môn học mã số {maLopMonHoc}");
        var sinhViens = from dsv in _context.DiemSinhViens
                join sv in _context.SinhViens 
                    on dsv.MaSinhVien equals sv.MaSinhVien
                where dsv.MaLopMonHoc == maLopMonHoc
                select sv;
        return sinhViens;
    }

    public async Task<SinhVien> AddNew(SinhVienDto sinhVienDto)
    {
        var lopQuanLi = await _context.LopQuanLis.FindAsync(sinhVienDto.MaLopQuanLi) 
            ?? throw new ServiceException(404, $"Không tồn tại lớp quản lí mã {sinhVienDto.MaLopQuanLi}");
        var trungSdtHoacEmail = await _context.SinhViens
            .FirstOrDefaultAsync(sv => sv.SoDienThoai == sinhVienDto.SoDienThoai
                || sv.Email == sinhVienDto.Email);
        if (trungSdtHoacEmail != null)
        {
            string msg = "";
            if (trungSdtHoacEmail.SoDienThoai == sinhVienDto.SoDienThoai)
            {
                msg = $"Số điện thoại {sinhVienDto.SoDienThoai} đã được sử dụng";
            }
            else
            {
                msg = $"Email {sinhVienDto.Email} đã được sử dụng";
            }
            throw new ServiceException(400, msg);
        }
        if (!ConNguoiValidator.IsValidToInSert(sinhVienDto))
        {
            throw new ServiceException(400, "Dữ liệu không hợp lệ");
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
        var sinhVien = await _context.SinhViens.FindAsync(maSoSinhVien) 
            ?? throw new ServiceException(404, $"Không tồn tại sinh viên mã số {maSoSinhVien}");
        if (!ConNguoiValidator.IsValid(sinhVienDto))
        {
            throw new ServiceException(400, "Dữ liệu không hợp lệ");
        }
        sinhVien.HoTen = sinhVienDto.HoTen;
        sinhVien.GioiTinh = sinhVienDto.GioiTinh;
        sinhVien.NgaySinh = sinhVienDto.NgaySinh;
        sinhVien.QueQuan = sinhVienDto.QueQuan;
        sinhVien.DiaChiThuongTru = sinhVienDto.DiaChiThuongTru;
        sinhVien.NgayVaoTruong = sinhVienDto.NgayVaoTruong;
        sinhVien.SoDienThoai = sinhVienDto.SoDienThoai;
        sinhVien.Email = sinhVienDto.Email;
        await _context.SaveChangesAsync();
        return sinhVien;
    }
    public async Task<SinhVien> UpdateLopQuanLi(int maSoSinhVien, int maLopQuanLi)
    {
        var sinhVien = await _context.SinhViens
            .FirstOrDefaultAsync(sv => sv.MaSinhVien == maSoSinhVien) 
            ?? throw new ServiceException(404, $"Sinh viên mã {maSoSinhVien} không tồn tại");
        var lopQuanLi = await _context.LopQuanLis
            .FirstOrDefaultAsync(lql => lql.MaLopQuanLi == maLopQuanLi) 
            ?? throw new ServiceException(404, $"Lớp quản lí mã {maLopQuanLi} không tồn tại");
        sinhVien.LopQuanLi = lopQuanLi;
        await _context.SaveChangesAsync();
        return sinhVien;
    }

    public async Task Remove(int maSoSinhVien)
    {
        var sinhVien = await _context.SinhViens.FindAsync(maSoSinhVien) 
            ?? throw new ServiceException(404, $"Không tồn tại sinh viên mã số {maSoSinhVien}");
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