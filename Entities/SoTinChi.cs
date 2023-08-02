using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities

{
    public enum SoTinChi
    {
        [Display(Name = "1")]
        MotTinChi,

        [Display(Name = "2")]
        HaiTinChi = 2,
        
        [Display(Name = "3")]
        BaTinChi = 3
    }
}