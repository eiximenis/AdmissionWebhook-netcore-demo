using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionWebhook
{
    public static class Validate
    {
        public static async Task Run(dynamic data, HttpContext ctx)
        {
            dynamic pod = data.request["object"];
            string uid = data.request.uid.ToString();
            string image = pod.spec.containers[0].image.ToString();
            var name = pod.metadata.name.ToString();
            Console.WriteLine($"Pod {name} has image {image}");
            var tokens = image.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 2 || tokens[1] == "latest")
            {
                Console.WriteLine("latest images are not allowed.");
                await ctx.Response.GenerateResponse(uid, allowed: false);
                return;
            }

            await ctx.Response.GenerateResponse(uid, allowed: true);
        }
    }
}
