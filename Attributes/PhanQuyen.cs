using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using qlsinhvien.Context;

namespace qlsinhvien.Atributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class PhanQuyen : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string[] VaiTros;
        public PhanQuyen(params string[] VaiTros)
        {
            this.VaiTros = VaiTros;
        }

        private DateTime GetExp(JwtSecurityToken jwtToken)
        {
            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(jwtToken.Claims.FirstOrDefault(claim => claim.Type == "exp")!.Value)).UtcDateTime;
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
                ValidateLifetime = false
            });
            if (validateResult.Exception is not null)
            {
                throw validateResult.Exception;
            }
            if (validateResult.SecurityToken is JwtSecurityToken jwtSecurityToken)
            {
                int.TryParse(jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "manguoidung")!.Value, out int maNguoiDung);
                var vaiTro = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "vaitro")!.Value;
                var dbcontext = context.HttpContext.RequestServices.GetService<ApplicationContext>()!;
                if (!dbcontext.NguoiDungs.Any(nd => (nd.TenVaiTro == vaiTro) && (nd.MaGiangVien == maNguoiDung || nd.MaSinhVien == maNguoiDung)))
                {
                    Console.WriteLine("No user");
                    context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                    return;
                }
                context.Result = null;
                await Task.CompletedTask;
            }
        }
    }
}