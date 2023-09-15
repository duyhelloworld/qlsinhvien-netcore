using System.IdentityModel.Tokens.Jwt;
using System.Text;
using EnumStringValues;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using qlsinhvien.Context;
using qlsinhvien.Entities;
using qlsinhvien.Entities.SecurityModels;

namespace qlsinhvien.Atributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class PhanQuyen : Attribute, IAsyncAuthorizationFilter
    {
        public readonly EQuyen[] TenQuyen;
        public int MaNguoiDung  { get; private set; }
        public string TenVaiTro { get; private set; } = null!;
        public PhanQuyen(params EQuyen[] TenQuyen)
        {
            this.TenQuyen = TenQuyen;
        }
        
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var authInfo = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrWhiteSpace(authInfo) || !authInfo.StartsWith("Bearer"))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }
            string jwtToken = authInfo[7..];
            var handler = new JwtSecurityTokenHandler();
            var config = context.HttpContext.RequestServices.GetService<IConfiguration>()!;
            var validateResult = await handler.ValidateTokenAsync(jwtToken, new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = config["JWT:Issuer"]!,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["JWT:SecretKey"]!)),
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
                int.TryParse(jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "manguoidung")!.Value, out int maNguoiDung);
                var tenVaiTro = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "vaitro")!.Value;
                var dbcontext = context.HttpContext.RequestServices.GetService<ApplicationContext>()!;
                var nguoiDung = await dbcontext.NguoiDungs.FirstAsync(nd => (nd.TenVaiTro == tenVaiTro) && (nd.MaGiangVien == maNguoiDung || nd.MaSinhVien == maNguoiDung));
                if (nguoiDung is null)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                    return;
                }
                string tokenid = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "id")!.Value;
                var daDangXuat = await dbcontext.TokenHetHans.AnyAsync(dx => dx.MaToken == tokenid); 
                if (daDangXuat)
                {
                    context.Result = new ObjectResult(new ModelTraVe() {ThanhCong = false, Data = "Phiên đăng nhập đã hết hạn"});
                    return;
                }
                foreach (var quyen in TenQuyen)
                {
                    var duocPhep = await dbcontext.QuyenVaiTros.AnyAsync(qvt => 
                                    qvt.TenVaiTro == nguoiDung.TenVaiTro &&
                                    qvt.TenQuyen == quyen.GetStringValue());
                    if (duocPhep)
                    {
                        MaNguoiDung = maNguoiDung;
                        TenVaiTro = tenVaiTro;
                        context.HttpContext.Items.Add("PhanQuyen", this);
                        context.Result = null;
                        return;
                    }
                }
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }
}