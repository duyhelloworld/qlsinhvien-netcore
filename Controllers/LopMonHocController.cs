using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("/[controller]")]
public class LopMonHocController : ControllerBase
{
    private readonly ApplicationContext appContext;
    public LopMonHocController(ApplicationContext appContext)
    {
        this.appContext = appContext;
    }
}