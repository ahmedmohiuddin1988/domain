using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;

namespace Domain.IntegrationTest
{
    public class DomainBase
    {
        private const string ApiUrlBase = "api";

        public TestServer CreateServer()
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder();
            webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory() + "\\");
            webHostBuilder.UseStartup<DomainStartup>();
            webHostBuilder.UseSetting(WebHostDefaults.ApplicationKey, typeof(DomainStartup).Assembly.FullName);
            return new TestServer(webHostBuilder);
        }

        public static class Post
        {
            public static string Domain = $"{ApiUrlBase}/Domain";
            
        }
    }
}
