using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using qlsinhvien.Context;
using qlsinhvien.Entities;
using qlsinhvien.Entities.SecurityModels;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Services.Impl;

public class TaiKhoanService : ITaiKhoanService
{
    private readonly ApplicationContext _context;
    private readonly IConfiguration _configuration;

    public TaiKhoanService(ApplicationContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task TaoTaiKhoanTrong(ModelDangKi model)
    {
        var tonTaiTenTk = await _context.NguoiDungs.AnyAsync(nd => nd.TenNguoiDung == model.TenNguoiDung);
        if (tonTaiTenTk) 
        {
            throw new ServiceException(400, "Username đã tồn tại");
        }
        
        var nguoiDung = new NguoiDung() 
        {
            TenNguoiDung = model.TenNguoiDung,
            MatKhau = model.MatKhau,
            TenHienThi = model.TenHienThi
        };

        await _context.NguoiDungs.AddAsync(nguoiDung);
        await _context.SaveChangesAsync();   
    }

    public async Task<ModelTraVe> DangNhap(ModelDangNhap model)
    {
        var nguoiDung = _context.NguoiDungs
                    .Where(nd => nd.TenNguoiDung == model.TenNguoiDung && nd.MatKhau == model.MatKhau)
                    .FirstOrDefault();
        if (nguoiDung == null)
        {
            return new ModelTraVe() 
            {
                ThanhCong = false,
                Data = "Sai tài khoản hoặc mật khẩu"
            };
        }
        
        if (nguoiDung.MaGiangVien == null && nguoiDung.MaSinhVien != null) 
        {
            return await Task.FromResult(new ModelTraVe()
            {
                ThanhCong = true,
                Data = GetToken((int) nguoiDung.MaSinhVien, nguoiDung.TenVaiTro!)
            });
        }
        else if (nguoiDung.MaSinhVien == null && nguoiDung.MaGiangVien != null)
        {
            return new ModelTraVe()
            {
                ThanhCong = true,
                Data = GetToken((int) nguoiDung.MaGiangVien, nguoiDung.TenVaiTro!)
            };
        } else 
        {
            throw new ServiceException(400, "Tài khoản chưa được cấp quyền");
        }

    }

    public Task DangXuat(string token)
    {
        return Task.Delay(10);
    }

    private string GetToken(int maNguoiDung, string vaiTro) 
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var claims = new ClaimsIdentity(
            new Claim[]
            {
                new("manguoidung", maNguoiDung.ToString(), ClaimValueTypes.Integer),
                new("vaitro", vaiTro, ClaimValueTypes.String),
                new(ClaimTypes.Sid, Guid.NewGuid().ToString())
            }
        );
        var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!);
        var tokenDesriptions = new SecurityTokenDescriptor()
        {   
            Issuer = _configuration["JWT:Issuer"],
            Subject = claims,
            Expires = DateTime.UtcNow.AddMinutes(20),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ),
        };
        var token = tokenHandler.CreateJwtSecurityToken(tokenDesriptions);
        return tokenHandler.WriteToken(token);
    }

    public async Task PhanVaiTro(string TenNguoiDung, string TenVaiTro)
    {
        var nguoiDung = await _context.NguoiDungs.FindAsync(TenNguoiDung) 
            ?? throw new ServiceException(404, "Người dùng không tồn tại");
        if (nguoiDung.TenVaiTro == null || string.IsNullOrEmpty(nguoiDung.TenVaiTro))
        {
            var vaiTro = await _context.VaiTros.FindAsync(TenVaiTro)
                ?? throw new ServiceException(404, "Vai trò không hợp lệ");
            nguoiDung.TenVaiTro = vaiTro.TenVaiTro;
            await _context.SaveChangesAsync();             
        }
    }

    public Task DangXuat()
    {
        throw new NotImplementedException();
    }
}