namespace qlsinhvien.Entities;

public class AppSetting
{
    public string SecretKey { get; set;} = null!;

    public IEnumerable<string>? Issuer { get; set;}
}