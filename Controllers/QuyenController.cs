using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Atributes;
using qlsinhvien.Entities;
using qlsinhvien.Services;
namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class QuyenController : ControllerBase
{
    private readonly IQuyenService _service;

    public QuyenController(IQuyenService quyenService)
    {
        _service = quyenService;
    }

    [HttpGet]
    [PhanQuyen(EQuyen.XemTatCa_Quyen)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _service.LayTatCa());
    }

    [HttpGet("{TenQuyen:alpha:minlength(1)}")]
    [PhanQuyen(EQuyen.XemTheoTen_Quyen)]
    public async Task<IActionResult> GetByIdAsync(string TenQuyen)
    {
        var ketQua = await _service.LayTheoTen(TenQuyen);
        return ketQua == null ? NotFound() : Ok(ketQua);
    }

    [HttpGet("vaitro")]
    [PhanQuyen(EQuyen.XemTheoVaiTro_Quyen)]
    public async Task<IActionResult> GetByVaiTro([FromQuery] string TenVaiTro)
    {
        var ketQua = await _service.LayTheoVaiTro(TenVaiTro);
        return ketQua == null ? NotFound() : Ok(ketQua);
    }

    [HttpGet("vaitro")]
    [PhanQuyen(EQuyen.XemTheoVaiTro_Quyen)]
    public async Task<IActionResult> GetByNguoiDung([FromQuery] string TenVaiTro)
    {
        var ketQua = await _service.LayTheoVaiTro(TenVaiTro);
        return ketQua == null ? NotFound() : Ok(ketQua);
    }

    [HttpGet("nguoidung")]
    [PhanQuyen(EQuyen.XemTheoNguoiDung_Quyen)]
    public async Task<IActionResult> GetByNguoiDung()
    {
        var ketQua = await _service.LayTheoNguoiDung();
        return ketQua == null ? NotFound() : Ok(ketQua);
    }

    // [HttpPost]
    // [PhanQuyen(EQuyen.ThemMoi_Quyen)]
    // public async Task<IActionResult> ThemAsync([FromBody] QuyenDto quyenDto)
    // {
    //     await _service.ThemQuyen(quyenDto);
    //     return Ok();
    // }

    // [HttpPut("{TenQuyen:alpha:minlength(1)}")]
    // [PhanQuyen(EQuyen.SuaThongTin_Quyen)]
    // public async Task<IActionResult> SuaAsync(string TenQuyen, [FromBody] QuyenDto quyenDto)
    // {
    //     await _service.CapNhatQuyen(TenQuyen, quyenDto);
    //     return Ok();
    // }

    // [HttpDelete("{TenQuyen:alpha:minlength(1)}")]
    // [PhanQuyen(EQuyen.Xoa_Quyen)]
    // public async Task<IActionResult> XoaAsync(string TenQuyen)
    // {
    //     await _service.XoaQuyen(TenQuyen);
    //     return Ok();
    // }
}