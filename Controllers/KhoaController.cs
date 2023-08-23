using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Services;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class KhoaController : ControllerBase
{
    private readonly IKhoaService _service;

    public KhoaController(IKhoaService khoaService)
    {
        _service = khoaService;
    }    

    [HttpGet("/")]
    public async Task<IEnumerable<Khoa>> GetAll() {
        return await _service.GetAll();
    }

    [HttpGet("{makhoa:int:min(1)}")]
    public async Task<Khoa?> GetById(int makhoa)
    {
        return await _service.GetById(makhoa); ;
    }

    [HttpGet("tim")]
    public async Task<IEnumerable<Khoa>> GetByName([FromQuery] string tenkhoa)
    {
        return await _service.GetByTen(tenkhoa);
    }

    [HttpPost]
    public async Task<Khoa> AddKhoa([FromBody] KhoaDto khoaDto)
    {
        return await _service.AddNew(khoaDto);
    }

    [HttpPut("{makhoa}")]
    public async Task<Khoa> UpdateKhoa(int maKhoa, [FromBody] KhoaDto khoaDto)
    {
       return await _service.Update(maKhoa, khoaDto);
    }

    [HttpDelete("{maKhoa}")]
    public async Task DeleteKhoa(int maKhoa) {
        await _service.Remove(maKhoa);
    }
}