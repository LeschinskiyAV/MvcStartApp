using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.IO;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogRepository _repo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, ILogRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            Request req = new Request { Url = context.Request.Path };
            await _repo.AddLog(req);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
