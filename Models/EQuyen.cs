using EnumStringValues;

namespace qlsinhvien.Entities
{
    public enum EQuyen
    {
        [StringValue("khongcoquyen")]
        KhongCoQuyen,
        [StringValue("xemtatca-bomon")]
        XemTatCa_BoMon,
        [StringValue("xemtatca-khoa")]
        XemTatCa_Khoa,
        [StringValue("xemtatca-giangvien")]
        XemTatCa_GiangVien,
        [StringValue("xemtatca-sinhvien")]
        XemTatCa_SinhVien,
        [StringValue("xemtatca-lopmonhoc")]
        XemTatCa_LopMonHoc,
        [StringValue("xemtatca-monhoc")]
        XemTatCa_MonHoc,
        [StringValue("xemtatca-lopquanli")]
        XemTatCa_LopQuanLi,
        [StringValue("xemtatca-vaitro")]
        XemTatCa_VaiTro,
        [StringValue("xemtatca-quyen")]
        XemTatCa_Quyen,
        [StringValue("xemtatca-diemsinhvien")]
        XemTatCa_DiemSinhVien,
        [StringValue("xemtatca-nguoidung")]
        XemTatCa_NguoiDung,
        [StringValue("xemtheoma-sinhvien")]
        XemTheoMa_SinhVien,
        [StringValue("xemtheoma-giangvien")]
        XemTheoMa_GiangVien,
        [StringValue("xemtheoma-bomon")]
        XemTheoMa_BoMon,
        [StringValue("xemtheoma-khoa")]
        XemTheoMa_Khoa,
        [StringValue("xemtheoma-lopmonhoc")]
        XemTheoMa_LopMonHoc,
        [StringValue("xemtheoma-monhoc")]
        XemTheoMa_MonHoc,
        [StringValue("xemtheoma-lopquanli")]
        XemTheoMa_LopQuanLi,
        [StringValue("xemtheoma-quyen")]
        XemTheoMa_Quyen,
        [StringValue("xemtheoten-sinhvien")]
        XemTheoTen_SinhVien,
        [StringValue("xemtheolopquanli-sinhvien")]
        XemTheoLopQuanLi_SinhVien,
        [StringValue("xemtheolopmonhoc-sinhvien")]
        XemTheoLopMonHoc_SinhVien,
        [StringValue("themmoi-sinhvien")]
        ThemMoi_SinhVien,
        [StringValue("themmoi-quyen")]
        ThemMoi_Quyen,
        [StringValue("suathongtin-quyen")]
        SuaThongTin_Quyen,
        [StringValue("xoa-quyen")]
        Xoa_Quyen,
        [StringValue("xemtheoten-monhoc")]
        XemTheoTen_MonHoc,
        [StringValue("themmoi-monhoc")]
        ThemMoi_MonHoc,
        [StringValue("suathongtintheoma-sinhvien")]
        SuaThongTinTheoMa_SinhVien,
        [StringValue("xembanthan-sinhvien")]
        XemBanThan_SinhVien,
        [StringValue("xoa-sinhvien")]
        Xoa_SinhVien,
        [StringValue("suathongtintheolopquanli-sinhvien")]
        SuaThongTinTheoLopQuanLi_Sinhvien,
        [StringValue("suathongtintheoma-monhoc")]
        SuaThongTinTheoMa_MonHoc,
        [StringValue("xoa-monhoc")]
        Xoa_MonHoc,
        [StringValue("xemtatcacungsiso-lopquanli")]
        XemTatCaCungSiSo_LopQuanLi,
        [StringValue("xemtheoten-quyen")]
        XemTheoTen_Quyen,
        [StringValue("xemtheoten-lopquanli")]
        XemTheoTen_LopQuanLi,
        [StringValue("themmoi-lopquanli")]
        ThemMoi_LopQuanLi,
        [StringValue("suathongtintheoma-lopquanli")]
        SuaThongTinTheoMa_LopQuanLi,
        [StringValue("xoa-lopquanli")]
        Xoa_LopQuanLi,
        [StringValue("xemtatcacungsiso-lopmonhoc")]
        XemTatCaCungSiSo_LopMonHoc,
        [StringValue("xemtheoten-lopmonhoc")]
        XemTheoTen_LopMonHoc,
        [StringValue("themmoi-lopmonhoc")]
        ThemMoi_LopMonHoc,
        [StringValue("suathongtin-lopmonhoc")]
        SuaThongTin_LopMonHoc,
        [StringValue("xoatheoma-lopmonhoc")]
        XoaTheoMa_LopMonHoc,
        [StringValue("xoatheomon-lopmonhoc")]
        XoaTheoMonHoc_LopMonHoc,
        [StringValue("xemtheoten-khoa")]
        XemTheoTen_Khoa,
        [StringValue("themmoi-khoa")]
        ThemMoi_Khoa,
        [StringValue("suathongtin-khoa")]
        SuaThongTin_Khoa,
        [StringValue("xoa-khoa")]
        Xoa_Khoa,
        [StringValue("xemtheoten-giangvien")]
        XemTheoTen_GiangVien,
        [StringValue("xemtheolopquanli-giangvien")]
        XemTheoLopQuanLi_GiangVien,
        [StringValue("xemtheolopmonhoc-giangvien")]
        XemTheoLopMonHoc_GiangVien,
        [StringValue("xemtheobomon-giangvien")]
        XemTheoBoMon_GiangVien,
        [StringValue("xemlopmonhoc-giangvien")]
        XemLopMonHoc_GiangVien,
        [StringValue("xembanthan-giangvien")]
        XemBanThan_GiangVien,
        [StringValue("themmoi-giangvien")]
        ThemMoi_GiangVien,
        [StringValue("themmoilopmonhoc-giangvien")]
        ThemMoiLopMonHoc_GiangVien,
        [StringValue("suaprofile-giangvien")]
        SuaProfile_GiangVien,
        [StringValue("sualopquanli-giangvien")]
        SuaLopQuanLi_GiangVien,
        [StringValue("suabomon-giangvien")]
        SuaBoMon_GiangVien,
        [StringValue("xoa-giangvien")]
        Xoa_GiangVien,
        [StringValue("xoalopquanli-giangvien")]
        XoaLopQuanLi_GiangVien,
        [StringValue("xoalopmonhoc-giangvien")]
        XoaLopMonHoc_GiangVien,
        [StringValue("xemtheoma-diemsinhvien")]
        XemTheoMa_DiemSinhVien,
        [StringValue("xemtheolopquanli-diemsinhvien")]
        XemTheoLopQuanLi_DiemSinhVien,
        [StringValue("xemtheolopmonhoc-diemsinhvien")]
        XemTheoLopMonHoc_DiemSinhVien,
        [StringValue("suatheomasinhvien-diemsinhvien")]
        SuaTheoMaSinhVien_DiemSinhVien,
        [StringValue("suatheolopmonhoc-diemsinhvien")]
        SuaTheoLopMonHoc_DiemSinhVien,
        [StringValue("xoadiem-diemsinhvien")]
        XoaDiemSinhVien_DiemSinhVien,
        [StringValue("xemtheogiangvien-lopmonhoc")]
        XemTheoGiangVien_LopMonHoc,
        [StringValue("xoa-diemsinhvien")]
        Xoa_DiemSinhVien,
        [StringValue("themmoi-bomon")]
        ThemMoi_BoMon,
        [StringValue("suathongtin-bomon")]
        SuaThongTin_BoMon,
        [StringValue("xoa-bomon")]
        Xoa_BoMon,
        [StringValue("xemtatcachuaphanquyen-nguoidung")]
        XemTatCaChuaPhanQuyen_NguoiDung,
        [StringValue("xemtatcadaphanquyen-nguoidung")]
        XemTatCaDaPhanQuyen_NguoiDung,
        [StringValue("xemtatcatheovaitro-nguoidung")]
        XemTatCaTheoVaiTro_NguoiDung,
        [StringValue("xemtheotenhienthi-nguoidung")]
        XemTheoTenHienThi_NguoiDung,
        [StringValue("xemtheoten-nguoidung")]
        XemTheoTen_NguoiDung,
        [StringValue("xemtheovaitro-nguoidung")]
        XemTheoVaiTro_NguoiDung,
        [StringValue("themmoi-nguoidung")]
        ThemMoi_NguoiDung,
        [StringValue("phanquyen-nguoidung")]
        PhanQuyen_NguoiDung,
        [StringValue("suathongtin-nguoidung")]
        SuaThongTin_NguoiDung,
        [StringValue("huyphanquyen-nguoidung")]
        HuyPhanQuyen_NguoiDung,
        [StringValue("xoa-nguoidung")]
        Xoa_NguoiDung,
    }
}
