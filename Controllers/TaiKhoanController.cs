using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Atributes;
using qlsinhvien.Entities;
using qlsinhvien.Entities.SecurityModels;
using qlsinhvien.Services;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class TaiKhoanController : ControllerBase
{
    private readonly ITaiKhoanService _service;

    public TaiKhoanController(ITaiKhoanService taiKhoanService)
    {
        _service = taiKhoanService;
    }

    [HttpPost("dangnhap")]
    public async Task<IActionResult> DangNhap([FromBody] ModelDangNhap model) 
    {
        return Ok(await _service.DangNhap(model));
    }

    [HttpPost("dangki")]
    public async Task DangKi([FromBody] ModelDangKi model)
    {
        await _service.TaoTaiKhoanTrong(model);
    }

    [HttpGet("dangxuat")]
    public async Task DangXuat()
    {   
        await _service.DangXuat(HttpContext);
    }
}