using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using qlsinhvien.Context;
using qlsinhvien.Entities;
using qlsinhvien.Entities.SecurityModels;

namespace qlsinhvien.Services.Impl;

public class TaiKhoanService : ITaiKhoanService
{
    private readonly ApplicationContext _context;

    public TaiKhoanService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<string> DangKi(ModelDangKi model)
    {
        var nguoiDung = new NguoiDung() 
        {
            TenNguoiDung = model.TenNguoiDung,
            MatKhau = model.MatKhau,
            TenHienThi = model.TenHienThi
        };
        return "";
    }

    public async Task<ModelTraVe> DangNhap(ModelDangNhap model)
    {
        var nguoiDung = new NguoiDung()
        {
            TenNguoiDung = model.TenNguoiDung,
            MatKhau = model.MatKhau
        };
        // var result = await _signInManager.PasswordSignInAsync(nguoiDung, nguoiDung.MatKhau, false, false);
        // if (!result.Succeeded)
        // {
        //     return new ModelTraVe() 
        //     {
        //         ThanhCong = false,
        //         Data = "Sai tài khoản hoặc mật khẩu"
        //     };
        // }
        // var token = Convert.ToBase64String(await _userManager.CreateSecurityTokenAsync(nguoiDung)); 
        // return new ModelTraVe() 
        // {
        //     ThanhCong = true,
        //     Data = token
        // };
        return null;
    }

    public async Task DangXuat(string token)
    {
    }
}