﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendService.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Net;


namespace BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePublicInternetController : ControllerBase
    {

        [HttpGet]
        public async Task<string> Get()
        {

            string str = await MakeWebRequest();

            //if a volume is mounted, then save the result to a file
            new PVCController().SaveToFile(str);

            return str;
        }


        // POST: api/ServicePublicInternet
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ServicePublicInternet/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private static async Task<string> MakeWebRequest()
        {
            //https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient

            string value = "";

            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            };

            handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            try
            {
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                    string str = BackendService.Startup.BackendServiceURLPublicInternet + BackendService.Startup.BackendRequestedServicePublicInternet;

                    var stringTask = client.GetStringAsync(str);

                    var msg = await stringTask;
                    value = msg;
                }
            }
            catch (Exception exception)
            {
                value = exception.Message;
            }

            return value;
        }
    }
}
