using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IKhoaService
{
    public Task<IEnumerable<Khoa>> GetAll();
    public Task<Khoa?> GetById(int maKhoa);
    public Task<IEnumerable<Khoa>> GetByTen(string tenKhoa);
    public Task<Khoa> AddNew(KhoaDto KhoaDto);
    public Task<Khoa> Update(int maKhoa, KhoaDto KhoaDto);
    public Task Remove(int maKhoa);
}