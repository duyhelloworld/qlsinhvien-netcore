using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;
[ApiController]
[Route("/[controller]")]
public class DiemSinhVienController : ControllerBase
{
    private readonly ApplicationContext appContext;
    public DiemSinhVienController(ApplicationContext appContext)
    {
        this.appContext = appContext;
    }
}