using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class GiangVienService : IGiangVienService
{
    private readonly ApplicationContext _context;

    public GiangVienService(ApplicationContext context) {
        _context = context;
    }


    public async Task<IEnumerable<GiangVien>> GetAllAsync()
    {
        return await _context.GiangViens.ToListAsync();
    }

    public async Task<GiangVien?> GetByIdAsync(int maSoGiangVien)
    {
        if (maSoGiangVien <= 0)
        {
            return null;
        }
        return await _context.GiangViens.FindAsync(maSoGiangVien);
    }

    public async Task<IEnumerable<GiangVien>> GetByTenAsync(string tenGiangVien)
    {
        return await _context.GiangViens
            .Where(gv => gv.HoTen.Contains(tenGiangVien))
            .OrderBy(gv => gv.HoTen)
            .ToListAsync();
    }

    public async Task<IEnumerable<GiangVien>> GetByBoMonAsync(int maBoMon)
    {
        var boMon = await _context.BoMons.FindAsync(maBoMon);
        if (boMon == null)
        {
            throw new HttpException(404, $"Bộ môn mã số {maBoMon} không tồn tại");
        }
        await _context.BoMons.Entry(boMon).Collection(bm => bm.GiangViens).LoadAsync();
        var giangViens = boMon.GiangViens;
        if (giangViens == null || giangViens.Any())
        {
            throw new HttpException(404, $"Không có giảng viên nào đang dạy bộ môn mã {maBoMon}!");
        }
        return giangViens;
    }

    public async Task<GiangVien?> GetByLopQuanLiAsync(int maLopQuanLi)
    {
        var lopQuanLi = await _context.LopQuanLis.FindAsync(maLopQuanLi);
        if (lopQuanLi == null)
        {
            throw new HttpException(404, $"Lớp quản lí mã số {maLopQuanLi} không tồn tại");
        }
        await _context.LopQuanLis.Entry(lopQuanLi).Reference(lql => lql.GiangVien).LoadAsync();
        var giangVien = lopQuanLi.GiangVien;
        if (giangVien == null)
        {
            throw new HttpException(404, $"Không có giảng viên nào đang quản lí lớp {lopQuanLi.TenLopQuanLi}!");
        }
        return giangVien;
    }

    public async Task<GiangVien?> GetByLopMonHocAsync(int maLopMonHoc)
    {
        var lopMonHoc = await _context.LopMonHocs.FindAsync(maLopMonHoc);
        if (lopMonHoc == null)
        {
            throw new HttpException(404, $"Không có lớp môn học nào mã {maLopMonHoc}");
        }
        await _context.LopMonHocs.Entry(lopMonHoc).Reference(lmh => lmh.GiangVien).LoadAsync();
        var giangVien = lopMonHoc.GiangVien;
        if (giangVien == null)
        {
            throw new HttpException(404, $"Không có giảng viên nào đang dạy lớp {lopMonHoc.TenLopMonHoc}!");
        }
        return giangVien;
    }

    public Task<GiangVien?> GetByLopMonHocAsync(IEnumerable<int> maLopMonHocs)
    {
        // var lopMonHocsInDb = await _context.LopMonHocs
        //         .Where(lmh => maLopMonHocs.Contains(lmh.MaLopMonHoc))
        //         .ToListAsync();
        // if (lopMonHocsInDb.Count == 0)
        // {
        //     throw new HttpException(404, $"Không có lớp môn học nào giống danh sách");
        // }
        // foreach (var lop in lopMonHocsInDb)
        // {
        //     await _context.LopMonHocs.Entry(lop).Reference(lmh => lmh.GiangVien).LoadAsync();
        // }
        // return ;
        throw new NotImplementedException();
    }

    public async Task<GiangVien> AddNewAsync(GiangVienDto giangVienDto)
    {
        var boMon = await _context.BoMons.FindAsync(giangVienDto.MaBoMon);
        if (boMon == null)
        {
            throw new HttpException(404, $"Không tồn tại bộ môn có mã {giangVienDto.MaBoMon}!");
        }
        var giangVien = new GiangVien()
        {
            MaGiangVien = 0,
            HoTen = giangVienDto.HoTen,
            GioiTinh = giangVienDto.GioiTinh,
            NgaySinh = giangVienDto.NgaySinh,
            QueQuan = giangVienDto.QueQuan,
            DiaChiThuongTru = giangVienDto.DiaChiThuongTru,
            SoDienThoai = giangVienDto.SoDienThoai,
            Email = giangVienDto.Email,
            BoMon = boMon
        };

        // Thêm lớp quản lí (lớp quản lí của 1 giảng viên có thể null)
        var maLopQuanLi = giangVienDto.MaLopQuanLi;
        if (maLopQuanLi != null)
        {
            // Nếu gán lớp ql đã có sẵn cho giảng viên mới thì giảng viên mới sẽ tiếp quản lớp đó thay người cũ
            var lopQuanLi = await _context.LopQuanLis.FindAsync(maLopQuanLi);
            giangVien.LopQuanLi = lopQuanLi;
        }

        // Thêm các lớp môn học
        var maLopMonHocs = giangVienDto.MaLopMonHocs;
        if (maLopMonHocs != null && !maLopMonHocs.Any())
        {
            var lopMonHocs = await _context.LopMonHocs
                .Where(lmh => maLopMonHocs.Contains(lmh.MaLopMonHoc))
                .ToListAsync();
            if (!lopMonHocs.Any())
            {
                giangVien.LopMonHocs = lopMonHocs;
            }
        }
        var trungSdtHoacEmail = await _context.GiangViens
            .FirstOrDefaultAsync(gv => gv.SoDienThoai.Equals(giangVien.SoDienThoai)
                || gv.Email.Equals(giangVien.Email));
        if (trungSdtHoacEmail != null)
        {
            string msg = "";
            if (trungSdtHoacEmail.SoDienThoai.Equals(giangVien.SoDienThoai))
            {
                msg = $"Số điện thoại {giangVien.SoDienThoai} đã được sử dụng";
            } 
            else 
            {
                msg = $"Email {giangVien.Email} đã được sử dụng";
            }
            throw new HttpException(400, msg);
        }
        _context.GiangViens.Add(giangVien);
        _context.SaveChanges();
        return giangVien;
    }

    public async Task<GiangVien> UpdateAsync(int maGiangVien, GiangVienDto giangVienDto)
    {
        var boMon = await _context.BoMons.FindAsync(giangVienDto.MaBoMon);
        if (boMon == null)
        {
            throw new HttpException(404, $"Không tồn tại bộ môn có mã {giangVienDto.MaBoMon}!");
        }
        var giangVien = await _context.GiangViens.FindAsync(maGiangVien);
        if (giangVien == null)
        {
            throw new HttpException(404, $"Không tồn tại giảng viên có mã {maGiangVien}!");
        }
        var trungSdtHoacEmail = await _context.GiangViens
            .FirstOrDefaultAsync(gv => gv.SoDienThoai.Equals(giangVienDto.SoDienThoai)
                || gv.Email.Equals(giangVienDto.Email));
        if (trungSdtHoacEmail != null)
        {
            string msg = "";
            if (trungSdtHoacEmail.SoDienThoai.Equals(giangVienDto.SoDienThoai))
            {
                msg = $"Số điện thoại {giangVienDto.SoDienThoai} đã được sử dụng";
            }
            else
            {
                msg = $"Email {giangVienDto.Email} đã được sử dụng";
            }
            throw new HttpException(400, msg);
        }
        
        giangVienDto.MaGiangVien = maGiangVien;
        giangVien.HoTen = giangVienDto.HoTen;
        giangVien.GioiTinh = giangVienDto.GioiTinh;
        giangVien.NgaySinh = giangVienDto.NgaySinh;
        giangVien.QueQuan = giangVienDto.QueQuan;
        giangVien.DiaChiThuongTru = giangVienDto.DiaChiThuongTru;
        giangVien.SoDienThoai = giangVienDto.SoDienThoai;
        giangVien.Email = giangVienDto.Email;
        giangVien.BoMon = boMon;
        // Ko cập nhật lớp quản lí / lớp môn học vì có hàm riêng để làm chuyện ấy
        _context.SaveChanges();
        return giangVien;
    }    

    

    public Task RemoveAsync(int maSoGiangVien)
    {
        throw new NotImplementedException();
    }

    public Task<int> RemoveRangeAsync(ICollection<int> maSoGiangViens)
    {
        throw new NotImplementedException();
    }
}