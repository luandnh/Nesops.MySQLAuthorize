using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nesops.MySQLAuthorize.Configs;
using Nesops.MySQLAuthorize.IdentityDbContext;
using Nesops.MySQLAuthorize.Models;
using Nesops.MySQLAuthorize.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nesops.MySQLAuthorize
{
    public static class NesopsAuthorizationConfig
    {
        public static void Entry(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NesopsAuthorizeDbContext>(options => options.UseMySql(configuration.GetConnectionString("NesopsAuthorizeDB")));
            services.AddScoped(typeof(DbContext),typeof(NesopsAuthorizeDbContext));
            services.AddScoped(typeof(NesopsUserManager));
            services.AddIdentity<NesopsUser, NesopsRole>()
                .AddEntityFrameworkStores<NesopsAuthorizeDbContext>();
            services.AddHttpContextAccessor();
            services.AddScoped(typeof(SignInManager<NesopsUser>));
            JWTBuilder.BuildJWTService(services);
            AMC.Configure();
            services.AddScoped(typeof(AuthorizeService));
        }
    }
}
