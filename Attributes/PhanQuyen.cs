using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Atributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class PhanQuyen : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string[] TenQuyen;
        public PhanQuyen(params string[] TenQuyen)
        {
            this.TenQuyen = TenQuyen;
        }
        
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var config = context.HttpContext.RequestServices.GetService<IConfiguration>()!;
            var authInfo = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrWhiteSpace(authInfo) || !authInfo.StartsWith("Bearer"))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }
            string jwtToken = authInfo[7..];
            var handler = new JwtSecurityTokenHandler();
            var validateResult = await handler.ValidateTokenAsync(jwtToken, new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = config["JWT:Issuer"]!,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]!)),
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256Signature },
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["JWT:SecretKey"]!)),
            };

            var validateResult = await handler.ValidateTokenAsync(jwtToken, tokenParameters);

            if (!validateResult.IsValid)
            {
                throw validateResult.Exception;
            }
            if (validateResult.SecurityToken is JwtSecurityToken jwtSecurityToken)
            {
                int.TryParse(jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "manguoidung")!.Value, out int maNguoiDung);
                var vaiTro = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "vaitro")!.Value;
                var dbcontext = context.HttpContext.RequestServices.GetService<ApplicationContext>()!;
                var nguoiDung = await dbcontext.NguoiDungs.FirstAsync(nd => (nd.TenVaiTro == vaiTro) && (nd.MaGiangVien == maNguoiDung || nd.MaSinhVien == maNguoiDung));
                if (nguoiDung is null)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                    return;
                }
                foreach (var tq in TenQuyen)
                {
                    var quyenDuocGan = await dbcontext.Quyens.FindAsync(tq);
                    if (quyenDuocGan is not null)
                    {
                        var duocPhep = from qvt in dbcontext.QuyenVaiTros 
                                where qvt.TenVaiTro == nguoiDung.TenVaiTro 
                                    && qvt.TenQuyen == quyenDuocGan.TenQuyen
                                select qvt;
                        if (duocPhep != null)
                        {
                            context.Result = null;
                            await Task.CompletedTask;
                            return;
                        }
                    }
                }
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }
}