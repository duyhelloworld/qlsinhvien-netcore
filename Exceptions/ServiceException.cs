using System.ComponentModel.DataAnnotations;
using System.Net;

namespace qlsinhvien.Exceptions;

public class ServiceException : Exception
{
    public HttpStatusCode MaHttp { get; set; }
    public IEnumerable<string>? DeXuatGiaiQuyet { get; set; } = new HashSet<string>();
    public string? NguyenNhan { get; set; }
    public object? DataCanSua { get; set; } = null!;

    public ServiceException(HttpStatusCode maHttp, string nguyenNhan)
    {
        MaHttp = maHttp;
        NguyenNhan = nguyenNhan;
    }

    public ServiceException(HttpStatusCode maHttp, string nguyenNhan, params string[] deXuatGiaiQuyet)
    {
        MaHttp = maHttp;
        NguyenNhan = nguyenNhan;
        DeXuatGiaiQuyet = deXuatGiaiQuyet;
    }

    public ServiceException(HttpStatusCode maHttp, string nguyenNhan, string deXuatGiaiQuyet, object dataCanSua)
    {
        MaHttp = maHttp;
        NguyenNhan = nguyenNhan;
        _ = DeXuatGiaiQuyet.Append(deXuatGiaiQuyet);
        DataCanSua = dataCanSua;
    }
}