using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionWebhook
{
    static class HttpResponseExtensions
    {
        public static async Task GenerateResponse(this HttpResponse response, string uid, bool allowed)
        {
            response.ContentType = "application/json";
            var content = new
            {
                apiVersion = "admission.k8s.io/v1beta1",
                kind = "AdmissionReview",
                response = new
                {
                    uid = uid,
                    allowed = allowed
                }
            };
            await response.WriteAsync(JsonConvert.SerializeObject(content));
        }
    }
}
