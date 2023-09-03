using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace qlsinhvien.Atributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class PhanQuyen : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string[]? TenQuyens;
        public PhanQuyen(params string[] TenQuyens)
        {
            this.TenQuyens = TenQuyens;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var config = context.HttpContext.RequestServices.GetService<IConfiguration>()!;
            var authorizationMethod = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrWhiteSpace(authorizationMethod) || !authorizationMethod.StartsWith("Bearer"))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }
            string jwtToken = authorizationMethod[7..];

            var handler = new JwtSecurityTokenHandler();
            var tokenParameters = new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidIssuer = config["JWT:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["JWT:SecretKey"]!)),
                ValidateLifetime = false
            };
            var validatedResult = await handler.ValidateTokenAsync(jwtToken, tokenParameters);
            if (!validatedResult.IsValid)
            {
                Console.WriteLine(validatedResult.Exception.Message);
            }
            else {
                Console.WriteLine(JsonSerializer.Serialize(validatedResult.ClaimsIdentity.FindAll(c => true)));
            }

            // if (validatedResult.IsValid)
            // {
            // Console.WriteLine("Valid");
            // if (validatedResult.Issuer != config["JWT:Issuer"])
            //     {
            //         context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            //         return;
            //     }
            //     var maNguoiDung = validatedResult.Claims.FirstOrDefault(c => c.Key == "manguoidung").Value;
            //     var vaiTro = validatedResult.Claims.FirstOrDefault(c => c.Key == "vaitro").Value;
            //     if (maNguoiDung != null && vaiTro != null && vaiTro.GetType() == typeof(int))
            //     {
            //         // Allowed
            //         context.Result = null; 
            //     }
            // }
        }
    }
}