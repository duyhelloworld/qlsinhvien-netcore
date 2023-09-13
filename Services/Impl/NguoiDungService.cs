using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dtos;
using qlsinhvien.Entities;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class NguoiDungService : INguoiDungService
{
    private readonly ApplicationContext _context;
    public NguoiDungService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<NguoiDungDto>> GetAll()
    {
        return await _context.NguoiDungs
                .Select(nd => NguoiDungDto.Convert(nd)).ToListAsync();
    }

    public async Task<IEnumerable<NguoiDungDto>> GetAllNguoiDungChuaPhanQuyen()
    {
        return await _context.NguoiDungs
            .Where(nd => nd.TenVaiTro == null || string.IsNullOrEmpty(nd.TenVaiTro))
            .Select(nd => NguoiDungDto.Convert(nd)).ToListAsync();
    }

    public async Task<IEnumerable<NguoiDungDto>> GetAllNguoiDungDaPhanQuyen()
    {
        return await _context.NguoiDungs
            .Where(nd => nd.TenVaiTro != null)
            .Select(nd => NguoiDungDto.Convert(nd)).ToListAsync();
    }

    public async Task<IEnumerable<NguoiDungDto>> GetByTenHienThi(string TenHienThi)
    {
        return await _context.NguoiDungs
            .Where(nd => nd.TenHienThi != null && nd.TenHienThi.Contains(TenHienThi))
            .Select(nd => NguoiDungDto.Convert(nd)).ToListAsync();
    }

    public async Task<IEnumerable<NguoiDungDto>> GetByTenNguoiDung(string TenNguoiDung)
    {
        return await _context.NguoiDungs
            .Where(nd => nd.TenNguoiDung.Contains(TenNguoiDung))
            .Select(nd => NguoiDungDto.Convert(nd)).ToListAsync();
    }

    public async Task<IEnumerable<NguoiDungDto>> GetByVaiTro(string TenVaiTro)
    {
        var vaiTro = await _context.VaiTros.FindAsync(TenVaiTro)
            ?? throw new ServiceException(404, "Vai trò không tồn tại");
        return await _context.NguoiDungs
                .Where(nd => nd.TenVaiTro == vaiTro.TenVaiTro)
                .Select(nd => NguoiDungDto.Convert(nd)).ToListAsync();
    }

    public async Task<IEnumerable<NguoiDungDetail>> GetAllGroupByVaiTro()
    {
        var ketQua = from nd in _context.NguoiDungs
                     where nd.TenVaiTro != null
                     group nd by nd.TenVaiTro into nds
                     select new NguoiDungDetail
                     {
                        TenVaiTro = nds.Key,
                        NguoiDungDtos = nds.Select(nd => NguoiDungDto.Convert(nd)),
                        GhiChuVaiTro = nds.Select(nd => nd.VaiTro.GhiChu).FirstOrDefault()
                     };
        return await ketQua.ToListAsync();
    }

    public async Task Them(NguoiDungDtoDangKi nguoiDungDtoDki)
    {
        var daTonTai = await _context.NguoiDungs
                    .AnyAsync(nd => nd.TenNguoiDung == nguoiDungDtoDki.TenNguoiDung);
        if (daTonTai)
        {
            throw new ServiceException(400, "Người dùng này đã tồn tại", "Hãy sử dụng tên người dùng khác");
        }
        var nguoiDung = NguoiDungDto.Convert(nguoiDungDtoDki);
        nguoiDung.MatKhau = nguoiDungDtoDki.MatKhau;
        await _context.NguoiDungs.AddAsync(nguoiDung);
        await _context.SaveChangesAsync();
    }

    public async Task ThemVaPhanQuyen(NguoiDungDtoDangKi nguoiDungDtoDki)
    {
        var daTonTai = await _context.NguoiDungs
                    .AnyAsync(nd => nd.TenNguoiDung == nguoiDungDtoDki.TenNguoiDung);
        if (daTonTai)
        {
            throw new ServiceException(400, "Người dùng này đã tồn tại", "Hãy sử dụng tên người dùng khác");
        }
        var vaiTro = await _context.VaiTros.FindAsync(nguoiDungDtoDki.TenVaiTro)
            ?? throw new ServiceException(404, "Vai trò không tồn tại");
        var nguoiDung = NguoiDungDto.Convert(nguoiDungDtoDki);
        nguoiDung.MatKhau = nguoiDungDtoDki.MatKhau;
        await _context.NguoiDungs.AddAsync(nguoiDung);
        await _context.SaveChangesAsync();
    }

    public async Task PhanQuyen(ModelCapQuyen model)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(model.TenNguoiDung)
            ?? throw new ServiceException
            (404, "Người dùng không tồn tại");
        if (nguoiDung.TenVaiTro == null || string.IsNullOrEmpty(nguoiDung.TenVaiTro))
        {
            var vaiTro = await _context.VaiTros.FindAsync(model.TenVaiTro)
                ?? throw new ServiceException(404, "Vai trò không hợp lệ");
            nguoiDung.TenVaiTro = vaiTro.TenVaiTro;
            await _context.SaveChangesAsync();
        }
    }

    public async Task CapNhatThongTin(string TenNguoiDung, NguoiDungDto nguoiDungDto)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(TenNguoiDung)
            ?? throw new ServiceException(404, "Người dùng không tồn tại");
        nguoiDung.TenHienThi = nguoiDungDto.TenHienThi;
        switch (nguoiDungDto.TenVaiTro)
        {
            case "sinhvien":
                nguoiDung.MaSinhVien = nguoiDungDto.MaSo;
                nguoiDung.MaGiangVien = null;
                break;
            case "giangvien":
                nguoiDung.MaGiangVien = nguoiDungDto.MaSo;
                nguoiDung.MaSinhVien = null;
                break;
            default:
                break;
        }
        await _context.SaveChangesAsync();
    }

    public async Task HuyPhanQuyen(string TenNguoiDung)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(TenNguoiDung)
            ?? throw new ServiceException(404, "Người dùng không tồn tại");
        if (nguoiDung.TenVaiTro != null || !string.IsNullOrEmpty(nguoiDung.TenVaiTro))
        {
            nguoiDung.TenVaiTro = null;
            await _context.SaveChangesAsync();
        }
    }

    public async Task Xoa(string TenNguoiDung)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(TenNguoiDung) 
            ?? throw new ServiceException(404, "Người dùng không tồn tại");
        _context.NguoiDungs.Remove(nguoiDung);
        await _context.SaveChangesAsync();
    }
}