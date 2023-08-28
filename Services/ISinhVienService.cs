using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Services;
public interface ISinhVienService
{
    public Task<IEnumerable<SinhVien>> GetAll();
    public Task<SinhVien?> GetById(int maSoSinhVien);
    public Task<IEnumerable<SinhVien>> GetByHoTen(string hoTen);
    public Task<IEnumerable<SinhVien>> GetByLopQuanLi(int maLopQuanLi);
    public Task<IEnumerable<SinhVien>> GetByLopMonHoc(int maLopMonHoc);
    public Task<SinhVien> AddNew(SinhVienDto sinhVienDto);
    public Task<SinhVien> UpdateProfile(int maSoSinhVien, SinhVienDto sinhVienDto);
    public Task<SinhVien> UpdateLopQuanLi(int maSoSinhVien, int maLopQuanLi);
    public Task Remove(int maSoSinhVien);
}