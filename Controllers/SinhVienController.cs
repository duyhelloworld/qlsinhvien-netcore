using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class SinhVienController : ControllerBase
{
    private readonly ApplicationContext sinhVienDbContext;

    public SinhVienController(ApplicationContext sinhVienDbContext) {
        this.sinhVienDbContext = sinhVienDbContext;
    }
}