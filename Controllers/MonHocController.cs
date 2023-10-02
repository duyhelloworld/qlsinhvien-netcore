using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("/[controller]")]
public class MonHocController : ControllerBase
{
    private readonly ApplicationContext appContext;

    public MonHocController(ApplicationContext appContext)
    {
        this.appContext = appContext;
    }   
}