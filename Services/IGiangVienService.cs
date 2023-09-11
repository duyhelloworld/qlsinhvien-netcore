using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IGiangVienService
{
    public Task<IEnumerable<GiangVien>> GetAll();
    public Task<GiangVien?> GetById(int maSoGiangVien);
    public Task<IEnumerable<GiangVien>> GetByTen(string tenGiangVien);
    public Task<GiangVien?> GetByLopQuanLi(int maLopQuanLi);
    public Task<GiangVien?> GetByLopMonHoc(int maLopMonHoc);
    public Task<IEnumerable<LopMonHoc>> GetLopMonHoc(int maGiangVien);
    public Task<IEnumerable<GiangVien>> GetByBoMon(int maBoMon);
    public Task<GiangVien> AddNew(GiangVienDto giangVienDto);
    public Task<GiangVien> AddNewLopMonHoc(int maGiangVien, ICollection<int> maLopMonHocs);
    public Task<GiangVien> UpdateProfile(int maGiangVien, GiangVienDto giangVienDto);
    public Task<GiangVien> UpdateLopQuanLi_GiangVien(int maGiangVien, int maLopQuanLi);
    public Task<GiangVien> UpdateBoMon_GiangVien(int maGiangVien, int maBoMon);
    public Task Remove(int maGiangVien);
    public Task RemoveLopQuanLiHienTai(int maLopQuanLi);
    public Task RemoveAllLopMonHoc(int maGiangVien);
}