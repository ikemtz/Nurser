﻿using IkeMtz.NRSRx.Core.WebApi;
using IkeMtz.NRSRx.HealthItems.Models;
using IkeMtz.NRSRx.HealthItems.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IkeMtz.NRSRx.HealthItems.WebApi
{
  public class Startup : CoreWebApiStartup
  {
    public override string MicroServiceTitle => $"NRSRx {nameof(HealthItem)} API Microservice";
    public override Assembly StartupAssembly => typeof(Startup).Assembly;

    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    public override void SetupDatabase(IServiceCollection services, string connectionString)
    {
      services
      .AddDbContext<HealthItemsContext>(x => x.UseSqlServer(connectionString))
      .AddEntityFrameworkSqlServer();
    }

    public override void SetupMiscDependencies(IServiceCollection services)
    {
      services.AddScoped<IHealthItemsContext, HealthItemsContext>();
    }

    public override void SetupPublishers(IServiceCollection services)
    {
      services.AddServiceBusQueuePublishers<HealthItem>();
    }
  }
}
