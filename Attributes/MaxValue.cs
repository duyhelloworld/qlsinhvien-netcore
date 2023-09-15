using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class MaxValue : RangeAttribute
{
    public MaxValue(double minimum, EGioiHan gioiHan) : base(minimum, (int) gioiHan)
    {
        
    }
}