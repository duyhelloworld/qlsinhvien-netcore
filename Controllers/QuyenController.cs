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

    // [HttpGet]
    // [PhanQuyen(EQuyen.XemTatCa_Quyen)]
    // public async Task<IActionResult> GetAllAsync()
    // {
    //     return Ok(await _service.LayTatCa());
    // }

    [HttpGet]
    [PhanQuyen(EQuyen.XemTheoTen_Quyen, EQuyen.XemTatCa_Quyen)]
    public async Task<IActionResult> GetByIdAsync([FromQuery] string? TenQuyen)
    {
        if (TenQuyen == null)
        {
            return Ok(await _service.LayTatCa());
        }
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

    [HttpGet("nguoidung")]
    [PhanQuyen(EQuyen.XemTheoNguoiDung_Quyen, EQuyen.XemTheoTenNguoiDung_Quyen)]
    public async Task<IActionResult> GetByNguoiDung([FromQuery] string? TenNguoiDung)
    {
        if (string.IsNullOrEmpty(TenNguoiDung))
        {
            return Ok(await _service.LayTheoNguoiDung());  
        }
        var ketQua = await _service.LayTheoTenNguoiDung(TenNguoiDung);
        return ketQua == null ? NotFound() : Ok(ketQua);
    }
}