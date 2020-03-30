using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

//How to create template https://habr.com/en/company/microsoft/blog/449772/
//Clone solution https://www.youtube.com/watch?v=uqXYK4q54XE
//https://www.ecanarys.com/Blogs/ArticleID/180/Create-custom-project-templates-in-Visual-Studiohttps://www.ecanarys.com/Blogs/ArticleID/180/Create-custom-project-templates-in-Visual-Studio
namespace GlobalTeamNetwork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
