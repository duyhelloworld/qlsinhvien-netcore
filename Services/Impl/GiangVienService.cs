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


    public async Task<IEnumerable<GiangVien>> GetAll()
    {
        return await _context.GiangViens.ToListAsync();
    }

    public async Task<GiangVien?> GetById(int maSoGiangVien)
    {
        if (maSoGiangVien <= 0)
        {
            return null;
        }
        return await _context.GiangViens.FindAsync(maSoGiangVien);
    }

    public async Task<IEnumerable<GiangVien>> GetByTen(string tenGiangVien)
    {
        return await _context.GiangViens
            .Where(gv => gv.HoTen.Contains(tenGiangVien))
            .OrderBy(gv => gv.HoTen)
            .ToListAsync();
    }

    public async Task<IEnumerable<GiangVien>> GetByBoMon(int maBoMon)
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

    public async Task<GiangVien?> GetByLopQuanLi(int maLopQuanLi)
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

    public async Task<GiangVien?> GetByLopMonHoc(int maLopMonHoc)
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

    public Task<GiangVien?> GetByLopMonHoc(IEnumerable<int> maLopMonHocs)
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

    public async Task<GiangVien> AddNew(GiangVienDto giangVienDto)
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

    public async Task<GiangVien> UpdateProfile(int maGiangVien, GiangVienDto giangVienDto)
    {
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
        // Ko cập nhật bộ môn / lớp quản lí / lớp môn học vì có hàm riêng để làm chuyện ấy
        _context.SaveChanges();
        return giangVien;
    }    

    public async Task<GiangVien> UpdateLopQuanLi_GiangVien(int maGiangVien, int maLopQuanLi)
    {
        var giangVien = await _context.GiangViens.FindAsync(maGiangVien);
        if (giangVien == null)
        {
            throw new HttpException(404, $"Không tồn tại giảng viên có mã {maGiangVien}!");
        }
        var lopQuanLi = await _context.LopQuanLis.FindAsync(maLopQuanLi);
        if (lopQuanLi == null)
        {
            throw new HttpException(404, $"Không tồn tại lớp quản lí có mã {maLopQuanLi}");
        }
        giangVien.LopQuanLi = lopQuanLi;
        _context.SaveChanges();
        return giangVien;
    }

    public async Task<GiangVien> UpdateBoMon_GiangVien(int maGiangVien, int maBoMon)
    {
        var giangVien = await _context.GiangViens.FindAsync(maGiangVien);
        if (giangVien == null)
        {
            throw new HttpException(404, $"Không tồn tại giảng viên có mã {maGiangVien}!");
        }
        var boMon = await _context.BoMons.FindAsync(maBoMon);
        if (boMon == null)
        {
            throw new HttpException(404, $"Không tồn tại bộ môn có mã {maBoMon}!");
        }
        giangVien.BoMon = boMon;
        await _context.SaveChangesAsync();
        return giangVien;
    }

    public async Task<GiangVien> UpdateLopMonHocs_GiangVien(int maGiangVien, ICollection<int> maLopMonHocs)
    {
        var giangVien = await _context.GiangViens.FindAsync(maGiangVien);
        if (giangVien == null)
        {
            throw new HttpException(404, $"Không tồn tại giảng viên mã số {maGiangVien}");
        }
        var lopMonHocs = await _context.LopMonHocs
                .Where(lmh => maLopMonHocs.Contains(lmh.MaLopMonHoc))
                .ToListAsync();
        if (lopMonHocs.Any())
        {
            throw new HttpException(404, "Không tồn tại các lớp môn học này");
        }
        giangVien.LopMonHocs = lopMonHocs;
        var soUpdated = _context.SaveChanges();
        if (soUpdated != lopMonHocs.Count())
        {
            var khongTonTai = new List<int>();
            int dem = 0;
            while (dem == soUpdated)
            {
                foreach (var maLop in maLopMonHocs)
                {
                    foreach (var lop in lopMonHocs)
                    {
                        if (maLop != lop.MaLopMonHoc)
                        {
                            khongTonTai.Add(maLop);
                            dem++;
                        }
                    }
                }
            }
            throw new HttpException(200, @$"Cập nhật thành công {soUpdated} lớp môn học.\n
                    Các mã lớp không được cập nhật là {khongTonTai}");
        }
        return giangVien;
    }

    public async Task Remove(int maGiangVien)
    {
        var giangVien = await _context.GiangViens.FindAsync(maGiangVien);
        if (giangVien == null)
        {
            throw new HttpException(404, $"Không tồn tại giảng viên mã số {maGiangVien}");
        }

        // Tìm các lớp quản lí liên quan và đặt mã giảng viên thành null
        await _context.GiangViens.Entry(giangVien).Reference(gv => gv.LopQuanLi).LoadAsync();
        giangVien.LopQuanLi!.GiangVien = null;

        // Tìm các lớp môn học liên quan và đặt mã giảng viên thành null
        var lmhList = _context.LopMonHocs.Where(lmh => lmh.GiangVien.MaGiangVien == maGiangVien);
        foreach (var lmh in lmhList)
        {
            lmh.GiangVien = null;
        }
        _context.SaveChanges();
    }

    // public Task<int> RemoveRange(ICollection<int> maSoGiangViens)
    // {
    //     throw new NotImplementedException();
    // }
}