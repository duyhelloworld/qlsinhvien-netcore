using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _service.LayTatCa());
    }

    [HttpGet("{ TenQuyen:alpha:minlength(1)}")]
    public async Task<IActionResult> GetByIdAsync(string TenQuyen)
    {
        var ketQua = await _service.LayTheoTen(TenQuyen);
        return ketQua == null ? NotFound() : Ok(ketQua);
    }
}