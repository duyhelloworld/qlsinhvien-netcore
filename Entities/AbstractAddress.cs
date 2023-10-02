namespace qlsinhvien.Entities;

public abstract class Address
{
    public int ZipCode { get; set; }

    public int ProvinceId { get; set; }

    public int DistrictId { get; set; }

    public int CommuneId { get; set; }
}