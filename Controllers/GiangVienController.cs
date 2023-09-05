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
    public async Task<IEnumerable<GiangVien>> GetByNameViaRoute(string hoTen)
    {
        return await _service.GetByTen(hoTen);
    }
    
    [HttpGet("hoten")]
    public async Task<IEnumerable<GiangVien>> GetByNameViaQuery([FromQuery] string hoTen)
    {
        if (hoTen.Length < 1 || hoTen.Length > 40)
        {
            return Enumerable.Empty<GiangVien>().ToList();
        }
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

    [HttpGet("{magiangvien:int:min(1)}/lopmonhoc")]
    public async Task<IActionResult> GetLopMonHocs(int maGiangVien)
    {
        var ketQua = await _service.GetLopMonHoc(maGiangVien);
        return Ok(ketQua);        
    }
    [HttpGet("lopmonhoc/{malopmonhoc:int:min(1)}")]
    public async Task<IActionResult> GetByLopMonHoc(int maLopMonHoc)
    {
        var ketQua = await _service.GetByLopMonHoc(maLopMonHoc);
        return Ok(ketQua);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddGiangVien([FromBody] GiangVienDto giangVienDto)
    {
        var ketQua = await _service.AddNew(giangVienDto);
        return Ok(ketQua);
    }

    [HttpPost("{magiangvien:int:min(1)}/lopmonhoc")]
    public async Task<IActionResult> UpdateLopMonHocs_GiangVien(int magiangvien, [FromBody] ICollection<int> maLopMonHocs)
    {
        var ketQua = await _service.AddNewLopMonHoc(magiangvien, maLopMonHocs);
        return Ok(ketQua);
    }

    [HttpPut("{magiangvien:int:min(1)}")]
    public async Task<IActionResult> UpdateThongTinGiangVien(int magiangvien, [FromBody] GiangVienDto giangVienDto)
    {
        var ketQua = await _service.UpdateProfile(magiangvien, giangVienDto);
        return Ok(ketQua);
    }

    [HttpPut("{magiangvien:int:min(1)}/lopquanli/{malopquanli:int:min(1)}")]
    public async Task<IActionResult> UpdateLopQuanLi_GiangVien( int magiangvien,  int maLopQuanLi)
    {
        var ketQua = await _service.UpdateLopQuanLi_GiangVien(magiangvien, maLopQuanLi);
        return Ok(ketQua);
    }

    [HttpPut("{magiangvien:int:min(1)}/bomon/{mabomon:int:min(1)}")]
    public async Task<IActionResult> UpdateBoMon_GiangVien( int magiangvien,  int maBoMon)
    {
        var ketQua = await _service.UpdateBoMon_GiangVien(magiangvien, maBoMon);
        return Ok(ketQua);
    }

    [HttpDelete("{magiangvien:int:min(1)}")]
    public async Task DeleteGiangVien(int magiangvien)
    {
        await _service.Remove(magiangvien);
    }
}