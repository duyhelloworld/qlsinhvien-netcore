using qlsinhvien.Dto;

namespace qlsinhvien.Services.Impl.Validators;

public class ConNguoiValidator
{
    public static bool IsValid(SinhVienDto dto)
    {
        return 
            !string.IsNullOrEmpty(dto.HoTen)
            && dto.NgaySinh < DateTime.Now.AddYears(-18)
            && dto.NgayVaoTruong <= DateTime.Now
            && dto.NgayVaoTruong >= dto.NgaySinh;
    }

    public static bool IsValidToInSert(SinhVienDto dto)
    {
        return IsValid(dto)
            && dto.QueQuan != null && !string.IsNullOrEmpty(dto.QueQuan)
            && dto.DiaChiThuongTru != null && !string.IsNullOrEmpty(dto.DiaChiThuongTru);
    }
}