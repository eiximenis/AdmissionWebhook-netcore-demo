using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionWebhook
{
    public class Webhook
    {
        private readonly Func<dynamic, HttpContext, Task> _action;
        public Webhook(Func<dynamic, HttpContext, Task> action)
        {
            _action = action;
        }

        public async Task CheckAndRun(HttpContext ctx)
        {
            var ctype = ctx.Request.ContentType.ToLowerInvariant();
            if (ctype != "application/json")
            {
                Console.WriteLine($"Error. Invalid ContentType: {ctype}");
                return;
            }

            using (var reader = new StreamReader(ctx.Request.Body, Encoding.UTF8))
            {
                var json = await reader.ReadToEndAsync();
                dynamic data = JObject.Parse(json);
                await _action(data, ctx);
            }
        }
    }
}
