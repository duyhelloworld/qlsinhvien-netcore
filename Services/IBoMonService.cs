using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;

public interface IBoMonService
{
    public Task<IEnumerable<BoMon>> GetAllAsync();
    public Task<BoMon?> GetTheoMa(int MaBoMon);
    public Task<BoMon?> GetTheoMonHoc(int MaMonHoc);
    public Task<BoMon?> GetTheoGiangVien(int MaGiangVien);
    public Task<IEnumerable<BoMon>> GetTheoKhoa(int MaKhoa);
    public Task<BoMon> Add(BoMonDto boMon);
    public Task<BoMon> UpdateTen(int MaBoMon, string TenBoMon);
    public Task<BoMon> UpdateGiangVien(int MaBoMon, IEnumerable<int> MaGiangViens);
    public Task<BoMon> UpdateKhoa(int MaBoMon, IEnumerable<int> MaKhoas);
    public Task<BoMon> UpdateMonHoc(int MaBoMon, IEnumerable<int> MaMonHocs);
    public Task Remove(int MaBoMon);
}