using qlsinhvien.Dtos;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface INguoiDungService
{
    public Task<IEnumerable<NguoiDungDto>> GetAll();
    public Task<IEnumerable<NguoiDungDto>> GetAllNguoiDungChuaPhanQuyen();
    public Task<IEnumerable<NguoiDungDto>> GetAllNguoiDungDaPhanQuyen();
    public Task<IEnumerable<NguoiDungDetail>> GetAllGroupByVaiTro();
    public Task<IEnumerable<NguoiDungDto>> GetByTenNguoiDung(string TenNguoiDung);
    public Task<IEnumerable<NguoiDungDto>> GetByTenHienThi(string TenHienThi);
    public Task<IEnumerable<NguoiDungDto>> GetByVaiTro(string TenVaiTro);
    public Task<IEnumerable<NguoiDungDto>> GetByQuyen(string TenQuyen);
    public Task Them(NguoiDungDtoDangKi nguoiDungDtoDki);
    public Task PhanQuyen(ModelCapQuyen modelCapQuyen);
    public Task ThemVaPhanQuyen(NguoiDungDtoDangKi nguoiDungDtoDki);
    public Task HuyPhanQuyen(string TenNguoiDung);
    public Task CapNhatThongTin(string TenNguoiDung, NguoiDungDto nguoiDungDto);
    public Task Xoa(string TenNguoiDung);
}