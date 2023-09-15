namespace qlsinhvien.Entities
{
    public class DiemSinhVienDetail
    {
        [MaxValue(1, EGioiHan.MaxLopMonHoc)]
        public int MaLopMonHoc { get; set; }
        public string? TenLopMonHoc { get; set; }

        [MaxValue(1, EGioiHan.MaxSinhVien)]
        public int MaSinhVien { get; set; }
        public string? TenSinhVien { get; set; } = null!;

        [MaxValue(1, EGioiHan.MaxMonHoc)]
        public int? MaMonHoc { get; set; }
        public string? TenMonHoc { get; set; }

        [MaxValue(1, EGioiHan.MaxLopQuanLi)]
        public int? MaLopQuanLi { get; set; }
        public string? TenLopQuanLi { get; set; }

        public float? DiemChuyenCan { get; set; }
        public float? DiemGiuaKi { get; set; }
        public float? DiemCuoiKi { get; set; }
        
        [MaxValue(1, EGioiHan.MaxHocKi)]
        public int HocKi  { get; set; }

        public string? GhiChu { get; set; }

        public static DiemSinhVien Convert(DiemSinhVienDetail diemDetail)
        {
            return new DiemSinhVien
            {
                MaSinhVien = diemDetail.MaSinhVien,
                MaLopMonHoc = diemDetail.MaLopMonHoc,
                DiemChuyenCan = diemDetail.DiemChuyenCan,
                DiemGiuaKi = diemDetail.DiemGiuaKi,
                DiemCuoiKi = diemDetail.DiemCuoiKi,
                HocKi = diemDetail.HocKi,
                GhiChu = diemDetail.GhiChu
            };
        }

        public static DiemSinhVienDetail Convert(DiemSinhVien diem)
        {
            var diemDetail = new DiemSinhVienDetail
            {
                MaSinhVien = diem.MaSinhVien,
                MaLopMonHoc = diem.MaLopMonHoc,
                DiemChuyenCan = diem.DiemChuyenCan,
                DiemGiuaKi = diem.DiemGiuaKi,
                DiemCuoiKi = diem.DiemCuoiKi,
                HocKi = diem.HocKi,
                GhiChu = diem.GhiChu
            };
            if (diem.SinhVien != null)
            {
                diemDetail.TenSinhVien = diem.SinhVien.HoTen;
                diemDetail.TenLopQuanLi = diem.SinhVien.LopQuanLi.TenLopQuanLi;
            }
            if (diem.LopMonHoc != null)
            {
                diemDetail.TenLopMonHoc = diem.LopMonHoc.TenLopMonHoc;
                if (diem.LopMonHoc.MonHoc != null)
                {
                    diemDetail.MaMonHoc = diem.LopMonHoc.MaMonHoc;
                    diemDetail.TenMonHoc = diem.LopMonHoc.MonHoc.TenMonHoc;
                }
            }
            return diemDetail;
        }
    }
}
