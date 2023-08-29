using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Entities.SecurityModels;
using qlsinhvien.Services;

namespace qlsinhvien.Controllers;

[Route("/")]
[ApiController]
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

    [HttpPost("dangnhap")]
    public async Task<IActionResult> DangKi([FromBody] ModelDangKi model)
    {
        return Ok(await _service.DangKi(model));
    }
}