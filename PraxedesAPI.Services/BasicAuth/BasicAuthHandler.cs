using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace PraxedesAPI.Services.BasicAuth
{
    public class BasicAuthHandler
    {
        private readonly RequestDelegate _next;
        private readonly string _relm;
        private readonly IConfiguration _configuration;
        public BasicAuthHandler(RequestDelegate next, string relm, IConfiguration configuration) 
        {
            _next = next;
            _relm = relm;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            string? user = _configuration.GetSection("BasicAuth").GetSection("Username").Value;
            string? pass = _configuration.GetSection("BasicAuth").GetSection("Password").Value;
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("Unauthorized");
                return;
            }
            //BasicAuth userid:password
            var header = httpContext.Request.Headers["Authorization"];
            var encondedCredentials = header.ToString().Substring(6);
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encondedCredentials));
            string[] uidpwd = credentials.Split(':');
            var uid = uidpwd[0].Trim();
            var pwd = uidpwd[1].Trim();
            if (uid != user || pwd != pass)
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("Unauthorized");
                return;
            }
            await _next(httpContext);
        }
    }
}
