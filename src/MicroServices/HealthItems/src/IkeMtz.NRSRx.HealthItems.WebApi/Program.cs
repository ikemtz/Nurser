﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace IkeMtz.NRSRx.HealthItems.WebApi
{
  [ExcludeFromCodeCoverage] //This is part of the asp dotnet core and (TYPICALLY) should not be unit tested 
  public static class Program
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
