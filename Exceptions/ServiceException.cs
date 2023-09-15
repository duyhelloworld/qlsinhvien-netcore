using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Exceptions;

public class ServiceException : Exception
{
    [Range(100, 520)]
    public int MaHttp { get; set; }
    public IEnumerable<string>? DeXuatGiaiQuyet { get; set; } = new List<string>();
    public string? NguyenNhan { get; set; }
    public object? DataCanSua { get; set; } = null!;

    public ServiceException(int maHttp, string NguyenNhan) : base(NguyenNhan)
    {
        MaHttp = maHttp;
    }

    public ServiceException(int maHttp, string NguyenNhan, params string[] deXuatGiaiQuyet) : base(NguyenNhan)
    {
        MaHttp = maHttp;
        DeXuatGiaiQuyet = deXuatGiaiQuyet;
    }

    public ServiceException(int maHttp, string NguyenNhan, string deXuatGiaiQuyet, object dataCanSua) : base(NguyenNhan)
    {
        MaHttp = maHttp;
        DeXuatGiaiQuyet.Append(deXuatGiaiQuyet);
        DataCanSua = dataCanSua;
    }
}