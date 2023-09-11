using EnumStringValues;

namespace qlsinhvien.Entities;

public enum EQuyen
{
    [StringValue("xemtatca-bomon")]
    XemTatCa_BOMON,
    [StringValue("xemtatca-khoa")]
    XemTatCa_KHOA,
    [StringValue("xemtatca-giangvien")]
    XemTatCa_GIANGVIEN,
    [StringValue("xemtatca-sinhvien")]
    XemTatCa_SINHVIEN,
    [StringValue("xemtatca-lopmonhoc")]
    XemTatCa_LOPMONHOC,
    [StringValue("xemtatca-monhoc")]
    XemTatCa_MONHOC,
    [StringValue("xemtatca-lopquanli")]
    XemTatCa_LOPQUANLI,
    [StringValue("xemtatca-vaitro")]
    XemTatCa_VAITRO,
    [StringValue("xemtatca-quyen")]
    XemTatCa_QUYEN,
    [StringValue("xemtatca-nguoidung")]
    XemTatCa_NGUOIDUNG,
    [StringValue("xemtheoma-sinhvien")]
    XemTheoMa_SINHVIEN,
    [StringValue("xemtheoma-giangvien")]
    XemTheoMa_GIANGVIEN,
    [StringValue("xemtheoma-bomon")]
    XemTheoMa_BOMON,
    [StringValue("xemtheoma-khoa")]
    XemTheoMa_KHOA,
    [StringValue("xemtheoma-lopmonhoc")]
    XemTheoMa_LOPMONHOC,
    [StringValue("xemtheoma-monhoc")]
    XemTheoMa_MONHOC,
    [StringValue("xemtheoma-lopquanli")]
    XemTheoMa_LOPQUANLI
}