using System.Net;
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
            ?? throw new ServiceException(HttpStatusCode.NotFound, "Vai trò không tồn tại");
        return await _context.NguoiDungs
                .Where(nd => nd.TenVaiTro == vaiTro.TenVaiTro)
                .Select(nd => NguoiDungDto.Convert(nd)).ToListAsync();
    }

    public async Task<IEnumerable<NguoiDungDto>> GetByQuyen(string TenQuyen)
    {
        var quyen = await _context.Quyens.FindAsync(TenQuyen)
            ?? throw new ServiceException(HttpStatusCode.NotFound, "Quyền không tồn tại");
        var quyenVaitros =  await _context.QuyenVaiTros.Where(qvt => qvt.TenQuyen == TenQuyen).ToListAsync();
        if (quyenVaitros.Count == 0)
        {
            throw new ServiceException(HttpStatusCode.NotFound, "Quyền này chưa được phân quyền cho vai trò nào");
        }
        return await _context.NguoiDungs
            .Where(nd => nd.TenVaiTro != null 
                && quyenVaitros.Any(qvt => qvt.TenVaiTro == nd.TenVaiTro))
            .Select(nd => NguoiDungDto.Convert(nd))
            .ToListAsync();
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
            throw new ServiceException(HttpStatusCode.BadRequest, "Người dùng này đã tồn tại", "Hãy sử dụng tên người dùng khác");
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
            throw new ServiceException(HttpStatusCode.BadRequest, "Người dùng này đã tồn tại", "Hãy sử dụng tên người dùng khác");
        }
        var vaiTro = await _context.VaiTros.FindAsync(nguoiDungDtoDki.TenVaiTro)
            ?? throw new ServiceException(HttpStatusCode.NotFound, "Vai trò không tồn tại");
        var nguoiDung = NguoiDungDto.Convert(nguoiDungDtoDki);
        nguoiDung.MatKhau = nguoiDungDtoDki.MatKhau;
        await _context.NguoiDungs.AddAsync(nguoiDung);
        await _context.SaveChangesAsync();
    }

    public async Task PhanVaiTro(ModelCapVaiTro model)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(model.TenNguoiDung)
            ?? throw new ServiceException
            (HttpStatusCode.NotFound, "Người dùng không tồn tại");
        if (nguoiDung.TenVaiTro == null || string.IsNullOrEmpty(nguoiDung.TenVaiTro))
        {
            var vaiTro = await _context.VaiTros.FindAsync(model.TenVaiTro)
                ?? throw new ServiceException(HttpStatusCode.NotFound, "Vai trò không hợp lệ");
            nguoiDung.TenVaiTro = vaiTro.TenVaiTro;
            await _context.SaveChangesAsync();
        }
    }

    public async Task PhanQuyen(ModelCapQuyen model)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(model.TenNguoiDung)
            ?? throw new ServiceException(HttpStatusCode.NotFound, "Người dùng không tồn tại");
        if (nguoiDung.TenVaiTro == null || string.IsNullOrEmpty(nguoiDung.TenVaiTro))
        {
            throw new ServiceException(HttpStatusCode.NotFound, "Người dùng chưa được phân vai trò");
        }
        var quyen = await _context.Quyens.FindAsync(model.TenQuyen)
            ?? throw new ServiceException(HttpStatusCode.NotFound, "Quyền không hợp lệ");

        var daCoQuyen = await _context.QuyenVaiTros
            .AnyAsync(qvt => qvt.TenVaiTro == nguoiDung.TenVaiTro
                && qvt.TenQuyen == quyen.TenQuyen);
        if (daCoQuyen)
        {
            throw new ServiceException(HttpStatusCode.BadRequest, "Người dùng đã có quyền này");
        }
        var quyenVaiTroMoi = new QuyenVaiTro
        {
            TenQuyen = quyen.TenQuyen,
            TenVaiTro = nguoiDung.TenVaiTro
        };
        await _context.QuyenVaiTros.AddAsync(quyenVaiTroMoi);
        await _context.SaveChangesAsync();
    }

    public async Task CapNhatThongTin(string TenNguoiDung, NguoiDungDto nguoiDungDto)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(TenNguoiDung)
            ?? throw new ServiceException(HttpStatusCode.NotFound, "Người dùng không tồn tại");
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

    public async Task HuyVaiTro(string TenNguoiDung)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(TenNguoiDung)
            ?? throw new ServiceException(HttpStatusCode.NotFound, "Người dùng không tồn tại");
        if (nguoiDung.TenVaiTro != null || !string.IsNullOrEmpty(nguoiDung.TenVaiTro))
        {
            nguoiDung.TenVaiTro = null;
            await _context.SaveChangesAsync();
        }
    }

    public async Task HuyQuyen(ModelCapQuyen modelCapQuyen)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(modelCapQuyen.TenNguoiDung)
            ?? throw new ServiceException(HttpStatusCode.NotFound, "Người dùng không tồn tại");
        if (nguoiDung.TenVaiTro == null || string.IsNullOrEmpty(nguoiDung.TenVaiTro))
        {
            throw new ServiceException(HttpStatusCode.BadRequest, "Người dùng chưa được phân vai trò");
        }
        var quyen = await _context.Quyens.FindAsync(modelCapQuyen.TenQuyen)
            ?? throw new ServiceException(HttpStatusCode.NotFound, "Quyền không tồn tại");
        var quyenVaiTro = await _context.QuyenVaiTros
            .Where(qvt => qvt.TenVaiTro == nguoiDung.TenVaiTro
                && qvt.TenQuyen == quyen.TenQuyen)
            .FirstOrDefaultAsync();
        if (quyenVaiTro == null)
        {
            throw new ServiceException(HttpStatusCode.BadRequest, "Người dùng chưa được phân quyền này");
        }
        _context.QuyenVaiTros.Remove(quyenVaiTro);
        await _context.SaveChangesAsync();
    }


    public async Task Xoa(string TenNguoiDung)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(TenNguoiDung) 
            ?? throw new ServiceException(HttpStatusCode.NotFound, "Người dùng không tồn tại");
        _context.NguoiDungs.Remove(nguoiDung);
        await _context.SaveChangesAsync();
    }
}