using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraxedesAPI.Services.BasicAuth
{
    public class BasicAuthHandler
    {
        private readonly RequestDelegate _next;
        private readonly string _relm;
        public BasicAuthHandler(RequestDelegate next, string relm) 
        {
            _next = next;
            _relm = relm;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
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
            if (uid != "prxTest" || pwd != "prxTestpwd")
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("Unauthorized");
                return;
            }
            await _next(httpContext);
        }
    }
}
