using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class LopMonHocService : ILopMonHocService
{
    private readonly ApplicationContext _context;
    private readonly IDiemSinhVienService _service;

    public LopMonHocService(ApplicationContext context, IDiemSinhVienService service)
    {
        _context = context;
        _service = service;
    }

    public Task<ActionResult> AddNewAsync(LopMonHocDto lopMonHocDto)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> GetByIdAsync(int maLopMonHoc)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> GetByTenAsync(string tenLopMonHoc)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> GetWithSiSoAsync()
    {
        throw new NotImplementedException();
    }
    public async Task RemoveTheoMonHoc(int maMonHoc)
    {
        var lop = await _context.LopMonHocs.FindAsync(maMonHoc);
        if (lop == null)
        {
            throw new HttpException(404, $"Không tồn tại lớp môn học đang dạy môn học có mã {maMonHoc}");
        }
        var Diems = from l in _context.LopMonHocs
                 join diem in _context.DiemSinhViens on l.MaLopMonHoc equals diem.MaLopMonHoc
                 where l.MaMonHoc == maMonHoc
                 select diem.MaLopMonHoc;
        foreach (var item in Diems)
        {
            await _service.DeleteByLopMonHoc(item);
        }
        var maLopMonHocs = from l in _context.LopMonHocs
                 where l.MaMonHoc == maMonHoc
                 select l;
        foreach (var item in maLopMonHocs)
        {
            _context.LopMonHocs.Remove(item);
        }
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int maLopMonHoc)
    {
        var lop = await _context.LopMonHocs.FindAsync(maLopMonHoc);
        if (lop == null)
        {
            throw new HttpException(404, $"Không tồn tại lớp môn học có mã {maLopMonHoc}");
        }
        await _service.DeleteByLopMonHoc(maLopMonHoc);
        _context.LopMonHocs.Remove(lop);
        await _context.SaveChangesAsync();
    }

    public Task<ActionResult> RemoveRangeAsync(ICollection<int> maLopMonHocs)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> UpdateAsync(int maLopMonHoc, LopMonHocDto lopMonHocDto)
    {
        throw new NotImplementedException();
    }
}