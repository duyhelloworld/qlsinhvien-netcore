using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Atributes;
using qlsinhvien.Dtos;
using qlsinhvien.Entities;
using qlsinhvien.Services;
namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class NguoiDungController : ControllerBase
{
    private readonly INguoiDungService _service;
    public NguoiDungController(INguoiDungService service)
    {
        _service = service;
    }

    [HttpGet("tatca")]
    [PhanQuyen(EQuyen.XemTatCa_NguoiDung)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet]
    [PhanQuyen(EQuyen.XemTatCaDaPhanQuyen_NguoiDung, EQuyen.XemTatCaChuaPhanQuyen_NguoiDung)]
    public async Task<IActionResult> GetAllNguoiDungPhanQuyenAsync([FromQuery] bool phanQuyen)
    {
        if (phanQuyen)
        {
            return Ok(await _service.GetAllNguoiDungDaPhanQuyen());
        }
        return Ok(await _service.GetAllNguoiDungChuaPhanQuyen());
    }

    [HttpGet("vaitro")]
    [PhanQuyen(EQuyen.XemTheoVaiTro_NguoiDung)]
    public async Task<IActionResult> GetAllGroupByVaiTroAsync()
    {
        return Ok(await _service.GetAllGroupByVaiTro());
    }

    [HttpGet("timkiem/{tennguoidung}")]
    [PhanQuyen(EQuyen.XemTheoTen_NguoiDung)]
    public async Task<IActionResult> GetByTenNguoiDungAsync(string TenNguoiDung)
    {
        return Ok(await _service.GetByTenNguoiDung(TenNguoiDung));
    }

    [HttpGet("timkiem")]
    [PhanQuyen(EQuyen.XemTheoTenHienThi_NguoiDung)]
    public async Task<IActionResult> GetByTenHienThiAsync([FromQuery] string TenHienThi)
    {
        return Ok(await _service.GetByTenHienThi(TenHienThi));
    }

    [HttpGet("timkiem/vaitro")]
    [PhanQuyen(EQuyen.XemTheoVaiTro_NguoiDung)]
    public async Task<IActionResult> GetByVaiTroAsync([FromQuery] string TenVaiTro)
    {
        return Ok(await _service.GetByVaiTro(TenVaiTro));
    }

    [HttpPost("them")]
    [PhanQuyen(EQuyen.ThemMoi_NguoiDung)]
    public async Task AddAsync([FromBody] NguoiDungDtoDangKi nguoiDungDtoDki)
    {
        await _service.Them(nguoiDungDtoDki);
    }

    [HttpPost("phanquyen")]
    [PhanQuyen(EQuyen.PhanQuyen_NguoiDung)]
    public async Task PhanQuyenAsync([FromBody] ModelCapQuyen modelCapQuyen)
    {
        await _service.PhanQuyen(modelCapQuyen);
    }

    [HttpPost("phanvaitro")]
    [PhanQuyen(EQuyen.PhanVaiTro_NguoiDung)]
    public async Task PhanVaiTroAsync([FromBody] ModelCapVaiTro model)
    {
        await _service.PhanVaiTro(model);
    }

    [HttpPost]
    [PhanQuyen(EQuyen.ThemMoi_NguoiDung, EQuyen.PhanQuyen_NguoiDung)]
    public async Task ThemVaPhanQuyenAsync([FromBody] NguoiDungDtoDangKi nguoiDungDtoDki)
    {
        await _service.ThemVaPhanQuyen(nguoiDungDtoDki);
    }

    [HttpPut]
    [PhanQuyen(EQuyen.SuaThongTin_NguoiDung)]
    public async Task CapNhatThongTinAsync([FromQuery] string TenNguoiDung, [FromBody] NguoiDungDto nguoiDungDto)
    {
        await _service.CapNhatThongTin(TenNguoiDung, nguoiDungDto);
    }
    
    [HttpDelete("phanquyen")]
    [PhanQuyen(EQuyen.HuyPhanQuyen_NguoiDung)]
    public async Task HuyPhanQuyenAsync([FromQuery] string TenNguoiDung)
    {
        await _service.HuyPhanQuyen(TenNguoiDung);
    }

    [HttpDelete]
    [PhanQuyen(EQuyen.Xoa_NguoiDung)]
    public async Task XoaAsync([FromQuery] string TenNguoiDung)
    {
        await _service.Xoa(TenNguoiDung);
    }
}