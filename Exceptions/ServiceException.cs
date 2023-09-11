namespace qlsinhvien.Exceptions;

public class ServiceException : Exception
{
    public int MaHttp { get; set; }
    public IEnumerable<string>? DeXuatGiaiQuyet { get; set; }
    public string? NguyenNhan { get; set; }

    public ServiceException(int maHttp, string NguyenNhan) : base(NguyenNhan)
    {
        MaHttp = maHttp;
    }

    public ServiceException(int maHttp, string NguyenNhan, params string[] deXuatGiaiQuyet) : base(NguyenNhan)
    {
        MaHttp = maHttp;
        DeXuatGiaiQuyet = deXuatGiaiQuyet;
    }
}