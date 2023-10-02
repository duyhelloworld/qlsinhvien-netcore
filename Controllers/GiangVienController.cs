using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("/[controller]")]
public class GiangVienController : ControllerBase
{
    private readonly ApplicationContext giangVienDbContext;
    public GiangVienController(ApplicationContext giangVienDbContext)
    {
        this.giangVienDbContext = giangVienDbContext;
    }
}