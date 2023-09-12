using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

partial class KhoaService : IKhoaService
{
    private readonly ApplicationContext _context;

    public KhoaService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Khoa>> GetAll()
    {
        return await _context.Khoas.ToListAsync();
    }

    public async Task<Khoa?> GetById(int maKhoa)
    {
        var khoa = await _context.Khoas.FindAsync(maKhoa) 
            ?? throw new ServiceException(404, "Không có khoa mã này");
        return khoa;
    }

    public async Task<IEnumerable<Khoa>> GetByTen(string tenKhoa)
    {
        return await _context.Khoas
            .Where(k => k.TenKhoa.Contains(tenKhoa))
            .OrderBy(k => k.TenKhoa)
            .ToListAsync();
    }

    public async Task<Khoa> AddNew(KhoaDto khoaDto)
    {
        var checkTenKhoa = await _context.Khoas
            .AnyAsync(k => k.TenKhoa.Equals(khoaDto.TenKhoa));
        if (checkTenKhoa)  
        {
            throw new ServiceException(400, "Tên khoa đã tồn tại");
        }
        var khoa = new Khoa() 
        {
            MaKhoa = 0,
            TenKhoa = khoaDto.TenKhoa
        };
        if (khoaDto.MaBoMons != null)
        {
            var boMons = await _context.KhoaBoMons
                .Where(kbm => khoaDto.MaBoMons.Contains(kbm.MaBoMon))
                .ToListAsync();
            if (boMons != null)
            {
                khoa.BoMons = boMons;
            }
        }
        if (khoaDto.MaLopQuanLis != null)
        {
            var lopQuanLis = await _context.LopQuanLis
                .Where(lql => khoaDto.MaLopQuanLis.Contains(lql.MaLopQuanLi))
                .ToListAsync();
            if (lopQuanLis != null)
            {
                khoa.LopQuanLis = lopQuanLis;
            }
        }
        await _context.SaveChangesAsync();
        return khoa;
    }


    public async Task<Khoa> Update(int maKhoa, KhoaDto khoaDto)
    {
        var khoa = await _context.Khoas.FindAsync(maKhoa)  
            ?? throw new ServiceException(404, "Không có khoa mã này");
        var checkTenKhoa = await _context.Khoas
           .AnyAsync(k => k.TenKhoa.Equals(khoaDto.TenKhoa));
        if (checkTenKhoa)
        {
            throw new ServiceException(400, "Tên khoa đã tồn tại");
        }
        khoa.TenKhoa = khoaDto.TenKhoa;
        if (khoaDto.MaBoMons != null)
        {
            var boMons = await _context.KhoaBoMons
                .Where(kbm => khoaDto.MaBoMons.Contains(kbm.MaBoMon))
                .ToListAsync();
            if (boMons != null && boMons.Count > 0)
            {
                khoa.BoMons = boMons;
            }
        }
        if (khoaDto.MaLopQuanLis != null)
        {
            var lopQuanLis = await _context.LopQuanLis
                .Where(lql => khoaDto.MaLopQuanLis.Contains(lql.MaLopQuanLi))
                .ToListAsync();
            if (lopQuanLis != null && lopQuanLis.Count > 0)
            {
                khoa.LopQuanLis = lopQuanLis;
            }
        }
        await _context.SaveChangesAsync();
        return khoa;
    }
    
    public async Task Remove(int maKhoa)
    {
        var khoa = await _context.Khoas
            .Where(k => k.MaKhoa == maKhoa)
            .Include(k => k.BoMons)
            .Include(k => k.LopQuanLis)
            .FirstOrDefaultAsync() 
            ?? throw new ServiceException(404, "Không có khoa mã này");
        if (khoa.BoMons != null)
        {
            khoa.BoMons.Clear();
        }
        if (khoa.LopQuanLis != null)
        {
            throw new ServiceException(400, @$"Khoa đang có {khoa.LopQuanLis.Count} 
                lớp quản lí. Hãy thay đổi khoa của các lớp đó trước");
        }
        await _context.SaveChangesAsync();
    }
}