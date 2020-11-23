using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// https://docs.microsoft.com/en-us/aspnet/core/blazor/security/server/?view=aspnetcore-3.1&tabs=visual-studio
// https://docs.microsoft.com/en-us/aspnet/core/security/authentication/add-user-data?view=aspnetcore-3.1&tabs=visual-studio
// http://blazorhelpwebsite.com/Blog/tabid/61/EntryId/4354/A-Simple-Blazor-User-and-Role-Manager.aspx
// http://blog.medhat.ca/2019/07/blazor-server-side-app-with-crud.html

namespace BlazorApp4s
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
