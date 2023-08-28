namespace qlsinhvien.Entities.Security;

public class ModelTraVe
{
    public bool ThanhCong  { get; set; } = false;
    public DateTime ThoiGianTraVe  { get; set; } = DateTime.UtcNow;
    public object Data { get; set; } = null!;
}