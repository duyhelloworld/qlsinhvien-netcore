using EnumStringValues;

namespace qlsinhvien.Models
{
    public enum EVaiTro
    {
        [StringValue("admin")]
        Admin,
        [StringValue("giangvien")]
        GiangVien,
        [StringValue("sinhvien")]
        SinhVien,
        [StringValue("superadmin")]
        SuperAdmin,
    }
}