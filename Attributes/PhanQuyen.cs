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
        private readonly string[] VaiTros;
        public PhanQuyen(params string[] VaiTros)
        {
            this.VaiTros = VaiTros;
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
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidIssuer = config["JWT:Issuer"],
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256Signature },
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["JWT:SecretKey"]!)),
            };

            var validateResult = await handler.ValidateTokenAsync(jwtToken, tokenParameters);

            if (!validateResult.IsValid)
            {
                context.Result = new JsonResult(new 
                    { message = "Unauthorized",
                     reason = validateResult.Exception.Message })
                { StatusCode = StatusCodes.Status500InternalServerError };
                return;
            }
            else {
                Console.WriteLine("OK. Cac claim : " + JsonSerializer.Serialize(validateResult.ClaimsIdentity));
            }

            // if (validatedResult.IsValid)
            // {
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