using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AdmissionWebhook
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            var validatorWebhook = new Webhook(Validate.Run);
            app.MapPost("/validate", validatorWebhook.CheckAndRun);
            app.MapFallback(async ctx => {
                Console.WriteLine("Called url: " + ctx.Request.Path);
            });
            await app.RunAsync();
        }
    }
}
