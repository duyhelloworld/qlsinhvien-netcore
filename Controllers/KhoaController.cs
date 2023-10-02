using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class KhoaController : ControllerBase
{
    private readonly ApplicationContext applicationContext;
    public KhoaController(ApplicationContext applicationContext) {
        this.applicationContext = applicationContext;
    }
}