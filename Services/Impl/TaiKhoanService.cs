using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using qlsinhvien.Entities;
using qlsinhvien.Entities.SecurityModels;

namespace qlsinhvien.Services.Impl;

public class TaiKhoanService : ITaiKhoanService
{
    private readonly IConfiguration _configuration;
    private readonly SignInManager<NguoiDung> _signInManager;
    private readonly UserManager<NguoiDung> _userManager;

    public TaiKhoanService(
        IConfiguration configuration, UserManager<NguoiDung> userManager, SignInManager<NguoiDung> signInManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> DangKi(ModelDangKi model)
    {
        var nguoiDung = new NguoiDung() 
        {
            TenNguoiDung = model.TenNguoiDung,
            MatKhau = model.MatKhau,
            TenHienThi = model.TenHienThi
        };
        var result = await _userManager.CreateAsync(nguoiDung, nguoiDung.MatKhau);
        if (!result.Succeeded)
        {
            return "";
        }
        // Thuật toán config ở Program.cs ?
        var tokenBytes = await _userManager.CreateSecurityTokenAsync(nguoiDung);
        var token = Convert.ToBase64String(tokenBytes);
        return token;
    }

    public async Task<ModelTraVe> DangNhap(ModelDangNhap model)
    {
        var nguoiDung = new NguoiDung()
        {
            TenNguoiDung = model.TenNguoiDung,
            MatKhau = model.MatKhau
        };
        var result = await _signInManager.PasswordSignInAsync(nguoiDung, nguoiDung.MatKhau, false, false);
        if (!result.Succeeded)
        {
            return new ModelTraVe() 
            {
                ThanhCong = false,
                Data = "Sai tài khoản hoặc mật khẩu"
            };
        }
        var token = Convert.ToBase64String(await _userManager.CreateSecurityTokenAsync(nguoiDung)); 
        return new ModelTraVe() 
        {
            ThanhCong = true,
            Data = token
        };
    }

    public async Task DangXuat(string token)
    {
        await _signInManager.SignOutAsync();
    }
}