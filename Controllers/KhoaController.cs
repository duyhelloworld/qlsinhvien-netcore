using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class KhoaController : ControllerBase
{
    private readonly ApplicationContext applicationContext;
    public KhoaController(ApplicationContext applicationContext) {
        this.applicationContext = applicationContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Khoa>> GetAll() {
        return applicationContext.Khoas
            .ToList();
    }

    [HttpGet("{makhoa}")]
    public ActionResult<Khoa> GetById(int makhoa)
    {
        var ketQua = applicationContext.Khoas.Find(makhoa);
        return ketQua == null ? NotFound() : Ok(ketQua);
    }

    [HttpGet("tim")]
    public ActionResult<IEnumerable<Khoa>> GetByName([FromQuery] string tenkhoa)
    {
        var ketQua = applicationContext.Khoas
                    .Where(k => k.TenKhoa.Contains(tenkhoa))
                    .OrderBy(k => k.MaKhoa);
        return ketQua == null ? NotFound() : Ok(ketQua);
    }

    [HttpPost]
    public ActionResult AddKhoa([FromBody] KhoaDto khoaDto)
    {
        if (khoaDto.MaKhoa != 0) {
            return BadRequest("Mã khoa sai");
        }
        try
        {
            var khoa = new Khoa() {
                MaKhoa = khoaDto.MaKhoa,
                TenKhoa = khoaDto.TenKhoa
            };
            applicationContext.Khoas.Add(khoa);
            applicationContext.SaveChanges();
            return Ok(khoa);
        }
        catch (DbUpdateException)
        {
            return BadRequest("Khoa đã tồn tại");
        }
    }

    [HttpPut("{makhoa}")]
    public ActionResult<Khoa> UpdateKhoa(int maKhoa, [FromBody] KhoaDto khoaDto)
    {
        khoaDto.MaKhoa = maKhoa;
        var khoa = applicationContext.Khoas.Find(maKhoa);
        if (khoa == null)
        {
            return BadRequest();
        }
        khoa.TenKhoa = khoaDto.TenKhoa;
        applicationContext.SaveChanges();
        return Ok(khoa);
    }

    [HttpDelete("{maKhoa}")]
    public async Task<ActionResult> DeleteKhoa(int maKhoa) {
        var khoa = applicationContext.Khoas.Find(maKhoa);
        if (khoa == null)
        {
            return BadRequest();
        }
        var httpClient = new HttpClient();
        applicationContext.Khoas.Entry(khoa).Collection(k => k.LopQuanLis).Load();
        applicationContext.Khoas.Entry(khoa).Collection(k => k.BoMons).Load();
        var lopQuanLis = khoa.LopQuanLis;
        foreach (var l in lopQuanLis)
        {
            var resp = await httpClient.DeleteAsync($"http://localhost:5277/lopquanli/{l.MaLopQuanLi}");
            resp.EnsureSuccessStatusCode();            
        }
        khoa.BoMons.Clear();
        applicationContext.Khoas.Remove(khoa);
        applicationContext.SaveChanges();
        return NoContent();
    }
}