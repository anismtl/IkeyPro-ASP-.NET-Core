using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IkeyPro.ADO;
using IkeyPro.Helpers;
using IkeyPro.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;

namespace IkeyPro
{
    public class Program
      

    {
        public static void Main(string[] args)
        {
            
            CreateWebHostBuilder(args).Build().Run();
          
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
