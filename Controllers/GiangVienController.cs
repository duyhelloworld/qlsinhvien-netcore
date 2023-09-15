using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Atributes;
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
    [PhanQuyen(EQuyen.XemTatCa_GiangVien)]
    public async Task<IEnumerable<GiangVien>> GetAllAsync()
    {
        return await _service.GetAll();
    }

    [HttpGet("{magiangvien:int:min(1)}")]
    [PhanQuyen(EQuyen.XemTheoMa_GiangVien)]
    public async Task<IActionResult> GetByIdAsync(int magiangvien)
    {
        var giangVien = await _service.GetById(magiangvien);
        if (giangVien == null)
        {
            return NotFound();
        }
        return Ok(giangVien);
    }

    [HttpGet]
    [PhanQuyen(EQuyen.XemBanThan_GiangVien)]
    public async Task<IActionResult> GetMySelf()
    {
        var phanQuyen = (HttpContext.Items["PhanQuyen"] as PhanQuyen)!;
        var giangVien = await _service.GetById(phanQuyen.MaNguoiDung);
        if (giangVien == null)
        {
            return NotFound();
        }
        return Ok(giangVien);
    }
    
    [HttpGet("hoten")]
    [PhanQuyen(EQuyen.XemTheoTen_GiangVien)]
    public async Task<IEnumerable<GiangVien>> GetByTen([FromQuery] string hoTen)
    {
        return await _service.GetByTen(hoTen);
    }

    [HttpGet("bomon/{maBoMon:int:min(1)}")]
    [PhanQuyen(EQuyen.XemTheoBoMon_GiangVien)]
    public async Task<IActionResult> GetByBoMonAsync(int maBoMon)
    {
        return Ok(await _service.GetByBoMon(maBoMon));
    }

    [HttpGet("lopquanli/{maLopQuanLi:int:min(1)}")]
    [PhanQuyen(EQuyen.XemTheoLopQuanLi_GiangVien)]
    public async Task<IActionResult> GetByLopQuanLiAsync(int maLopQuanLi)
    {
        return Ok(await _service.GetByLopQuanLi(maLopQuanLi));
    }

    [HttpGet("{magiangvien:int:min(1)}/lopmonhoc")]
    [PhanQuyen(EQuyen.XemLopMonHoc_GiangVien)]
    public async Task<IActionResult> GetLopMonHocs(int maGiangVien)
    {
        return Ok(await _service.GetLopMonHoc(maGiangVien));        
    }
    
    [HttpGet("lopmonhoc/{malopmonhoc:int:min(1)}")]
    [PhanQuyen(EQuyen.XemTheoLopMonHoc_GiangVien)]
    public async Task<IActionResult> GetByLopMonHoc(int maLopMonHoc)
    {
        return Ok(await _service.GetByLopMonHoc(maLopMonHoc));
    }

    [HttpPost]
    [PhanQuyen(EQuyen.ThemMoi_GiangVien)]
    public async Task<IActionResult> AddGiangVien([FromBody] GiangVienDto giangVienDto)
    {
        return Ok(await _service.AddNew(giangVienDto));
    }

    [HttpPost("{magiangvien:int:min(1)}/lopmonhoc")]
    [PhanQuyen(EQuyen.ThemMoiLopMonHoc_GiangVien)]
    public async Task<IActionResult> ThemLopMonHocs_GiangVien(int magiangvien, [FromBody] ICollection<int> maLopMonHocs)
    {
        return Ok(await _service.AddNewLopMonHoc(magiangvien, maLopMonHocs));
    }

    [HttpPut("{magiangvien:int:min(1)}")]
    [PhanQuyen(EQuyen.SuaProfile_GiangVien)]
    public async Task<IActionResult> UpdateThongTinGiangVien(int magiangvien, [FromBody] GiangVienDto giangVienDto)
    {
        return Ok(await _service.UpdateProfile(magiangvien, giangVienDto));
    }

    [HttpPut("{magiangvien:int:min(1)}/lopquanli/{malopquanli:int:min(1)}")]
    [PhanQuyen(EQuyen.SuaLopQuanLi_GiangVien)]
    public async Task<IActionResult> UpdateLopQuanLi_GiangVien( int magiangvien,  int maLopQuanLi)
    {
        return Ok(await _service.UpdateLopQuanLi_GiangVien(magiangvien, maLopQuanLi));
    }

    [HttpPut("{magiangvien:int:min(1)}/bomon/{mabomon:int:min(1)}")]
    [PhanQuyen(EQuyen.SuaBoMon_GiangVien)]
    public async Task<IActionResult> UpdateBoMon_GiangVien( int magiangvien,  int maBoMon)
    {
        return Ok(await _service.UpdateBoMon_GiangVien(magiangvien, maBoMon));
    }

    [HttpDelete("{magiangvien:int:min(1)}")]
    [PhanQuyen(EQuyen.Xoa_GiangVien)]
    public async Task DeleteGiangVien(int magiangvien)
    {
        await _service.Remove(magiangvien);
    }
}