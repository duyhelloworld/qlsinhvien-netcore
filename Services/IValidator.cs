using qlsinhvien.Dto;

namespace qlsinhvien.Services;

public interface IValidator
{
    public abstract static bool IsValid(SinhVienDto dto);
    public abstract static bool IsValidToInsert(SinhVienDto dto);
}