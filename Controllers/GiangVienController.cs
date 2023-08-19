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
        return await _service.GetAllAsync();
    }

    [HttpGet("{magiangvien:int:min(1)}")]
    public async Task<IActionResult> GetByIdAsync(int magiangvien)
    {
        var giangVien = await _service.GetByIdAsync(magiangvien);
        if (giangVien == null)
        {
            return NotFound();
        }
        return Ok(giangVien);
    }

    [HttpGet("hoten/{hoten:length(1, 40)}")]
    public async Task<IEnumerable<GiangVien>> GetByNameAsync(string hoTen)
    {
        return await _service.GetByTenAsync(hoTen);
    }

    [HttpGet("bomon/{maBoMon:int:min(1)}")]
    public async Task<IActionResult> GetByBoMonAsync(int maBoMon)
    {
        var giangViens = await _service.GetByBoMonAsync(maBoMon);
        return Ok(giangViens);
    }

    [HttpGet("lopquanli/{maLopQuanLi:int:min(1)}")]
    public async Task<IActionResult> GetByLopQuanLiAsync(int maLopQuanLi)
    {
        var giangViens = await _service.GetByLopQuanLiAsync(maLopQuanLi);
        return Ok(giangViens);
    }

    [HttpGet("lopmonhoc/{malopmonhoc:int:min(1)}")]
    public async Task<IActionResult> GetByLopMonHoc([FromRoute] int maLopMonHoc)
    {
        var ketQua = await _service.GetByLopMonHocAsync(maLopMonHoc);
        return Ok(ketQua);        
    }

    [HttpPost]
    public async Task<IActionResult> AddGiangVien([FromBody] GiangVienDto giangVienDto)
    {
        var ketQua = await _service.AddNewAsync(giangVienDto);
        return Ok(ketQua);
    }

    [HttpPut("{magiangvien:int:min(1)}")]
    public async Task<IActionResult> UpdateThongTinGiangVien([FromRoute] int magiangvien, [FromBody] GiangVienDto giangVienDto)
    {
        var ketQua = await _service.UpdateAsync(magiangvien, giangVienDto);
        return Ok(ketQua);
    }

    [HttpPut("lopquanli/{magiangvien}")]
    public ActionResult UpdateLopQuanLi_GiangVien(int magiangvien, [FromBody] int maLopQuanLi)
    {
        if (maLopQuanLi == 0)
        {
            return BadRequest();
        }
        var giangVien = _context.GiangViens.Find(magiangvien);
        if (giangVien == null)
        {
            return NotFound();
        }
        var lopQuanLi = _context.LopQuanLis.Find(maLopQuanLi);
        if (lopQuanLi == null)
        {
            return BadRequest($"Không tồn tại lớp quản lí có mã {maLopQuanLi}");
        }
        giangVien.LopQuanLi = lopQuanLi;
        _context.SaveChanges();
        return Ok(giangVien);
    }

    [HttpPut("lopmonhoc/{magiangvien}")]
    public ActionResult UpdateLopMonHocs_GiangVien(int magiangvien, [FromBody] ICollection<int> maLopMonHocs)
    {
        if (maLopMonHocs.Count == 0)
        {
            return BadRequest();
        }
        var giangVien = _context.GiangViens.Find(magiangvien);
        if (giangVien == null)
        {
            return NotFound($"Không tồn tại giảng viên mã số {magiangvien}");
        }
        var lopMonHocs = _context.LopMonHocs
                .Where(lmh => maLopMonHocs.Contains(lmh.MaLopMonHoc))
                .ToList();
        if (lopMonHocs.Count() == 0)
        {
            return NotFound("Không tồn tại các lớp môn học này.");
        }
        giangVien.LopMonHocs = lopMonHocs;
        _context.SaveChanges();
        return Ok(giangVien);
    }

    [HttpDelete("{magiangvien}")]
    public ActionResult DeleteGiangVien(int magiangvien)
    {
        var gv = _context.GiangViens.Find(magiangvien);

        if (gv == null)
        {
            return NotFound();
        }

        // Tìm các lớp quản lí liên quan và đặt mã giảng viên thành null
        var lqlList = _context.LopQuanLis.Where(lql => lql.GiangVien.MaGiangVien == magiangvien);
        foreach (var lql in lqlList)
        {
            lql.GiangVien = null;
        }

        // Tìm các lớp môn học liên quan và đặt mã giảng viên thành null
        var lmhList = _context.LopMonHocs.Where(lmh => lmh.GiangVien.MaGiangVien == magiangvien);
        foreach (var lmh in lmhList)
        {
            lmh.GiangVien = null;
        }

        _context.SaveChanges();

        return Ok(gv);
    }

}