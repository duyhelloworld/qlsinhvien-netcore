using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Services;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class GiangVienController : ControllerBase
{
    private readonly IGiangVienService _service;
    public GiangVienController(IGiangVienService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<GiangVien>> GetAllAsync()
    {
        return await _service.GetAll();
    }

    [HttpGet("{magiangvien:int:min(1)}")]
    public async Task<IActionResult> GetByIdAsync(int magiangvien)
    {
        var giangVien = await _service.GetById(magiangvien);
        if (giangVien == null)
        {
            return NotFound();
        }
        return Ok(giangVien);
    }

    [HttpGet("hoten/{hoten:length(1, 40)}")]
    public async Task<IEnumerable<GiangVien>> GetByNameAsync(string hoTen)
    {
        return await _service.GetByTen(hoTen);
    }

    [HttpGet("bomon/{maBoMon:int:min(1)}")]
    public async Task<IActionResult> GetByBoMonAsync(int maBoMon)
    {
        var giangViens = await _service.GetByBoMon(maBoMon);
        return Ok(giangViens);
    }

    [HttpGet("lopquanli/{maLopQuanLi:int:min(1)}")]
    public async Task<IActionResult> GetByLopQuanLiAsync(int maLopQuanLi)
    {
        var giangViens = await _service.GetByLopQuanLi(maLopQuanLi);
        return Ok(giangViens);
    }

    [HttpGet("lopmonhoc/{malopmonhoc:int:min(1)}")]
    public async Task<IActionResult> GetByLopMonHoc([FromRoute] int maLopMonHoc)
    {
        var ketQua = await _service.GetByLopMonHoc(maLopMonHoc);
        return Ok(ketQua);        
    }

    [HttpPost("/")]
    public async Task<IActionResult> AddGiangVien([FromBody] GiangVienDto giangVienDto)
    {
        var ketQua = await _service.AddNew(giangVienDto);
        return Ok(ketQua);
    }

    [HttpPut("{magiangvien:int:min(1)}")]
    public async Task<IActionResult> UpdateThongTinGiangVien([FromRoute] int magiangvien, [FromBody] GiangVienDto giangVienDto)
    {
        var ketQua = await _service.UpdateProfile(magiangvien, giangVienDto);
        return Ok(ketQua);
    }

    [HttpPut("{magiangvien:int:min(1)}/lopquanli/{malopquanli:int:min(1)}")]
    public async Task<IActionResult> UpdateLopQuanLi_GiangVien([FromRoute] int magiangvien, [FromRoute] int maLopQuanLi)
    {
        var ketQua = await _service.UpdateLopQuanLi_GiangVien(magiangvien, maLopQuanLi);
        return Ok(ketQua);
    }

    [HttpPut("lopmonhoc/{magiangvien}")]
    public async Task<IActionResult> UpdateLopMonHocs_GiangVien(int magiangvien, [FromBody] ICollection<int> maLopMonHocs)
    {
        var ketQua = await _service.UpdateLopMonHocs_GiangVien(magiangvien, maLopMonHocs);
        return Ok(ketQua);
    }

    [HttpDelete("{magiangvien}")]
    public async Task DeleteGiangVien(int magiangvien)
    {
        await _service.Remove(magiangvien);
    }
}