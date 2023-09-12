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
        var nguoiDung = await _context.NguoiDungs
                    .Where(nd => nd.TenNguoiDung == model.TenNguoiDung && nd.MatKhau == model.MatKhau)
                    .FirstOrDefaultAsync();
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

    public async Task DangXuat(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validateResult = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = _configuration["JWT:Issuer"]!,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!)),
            ValidateAudience = false,
            ValidateLifetime = true,
            RequireSignedTokens = true,
            RequireExpirationTime = true,
            RequireAudience = false,
        });
        if (validateResult.Exception is not null)
        {
            throw validateResult.Exception;   
        }
        if (validateResult.SecurityToken is JwtSecurityToken jwtSecurityToken)
        {
            try
            {
                var tenVaiTro = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "vaitro")!.Value;
                var maNguoiDung = int.Parse(jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "manguoidung")!.Value);
                var nguoiDung = await _context.NguoiDungs.FirstAsync(nd => (nd.TenVaiTro == tenVaiTro) && (nd.MaGiangVien == maNguoiDung || nd.MaSinhVien == maNguoiDung));
                if (nguoiDung is not null)
                {
                    var tokenHetHan = new TokenHetHan() 
                    {
                        MaToken = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "id")!.Value,
                        HetHanKhi = jwtSecurityToken.ValidTo
                    };
                    await _context.TokenHetHans.AddAsync(tokenHetHan);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }
    }

    private string GetToken(int maNguoiDung, string vaiTro) 
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!);
        var tokenDesriptions = new SecurityTokenDescriptor()
        {   
            Issuer = _configuration["JWT:Issuer"],
            Subject = new ClaimsIdentity( new Claim[]
            {
                new("manguoidung", maNguoiDung.ToString(), ClaimValueTypes.Integer),
                new("vaitro", vaiTro, ClaimValueTypes.String),
                new("id", Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("JWT:ExpireDays")),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ),
        };
        var token = tokenHandler.CreateJwtSecurityToken(tokenDesriptions);
        return tokenHandler.WriteToken(token);
    }

    
}