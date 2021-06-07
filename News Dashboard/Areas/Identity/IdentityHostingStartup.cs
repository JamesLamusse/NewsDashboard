﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News_Dashboard.Areas.Identity.Data;
using News_Dashboard.Data;

[assembly: HostingStartup(typeof(News_Dashboard.Areas.Identity.IdentityHostingStartup))]
namespace News_Dashboard.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<News_DashboardContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("News_DashboardContextConnection")));

                //Code below was generated by already being handled in Startup.cs thus it is commented out

                //services.AddDefaultIdentity<News_DashboardUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<News_DashboardContext>();
            });
        }
    }
}