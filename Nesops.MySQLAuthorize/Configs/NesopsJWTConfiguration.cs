﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesops.MySQLAuthorize.Configs
{
    public static class NesopsJWTConfiguration
    {
        public static string SECRETKEY = "NesopsPrivateKey";
        public static string ISSUER = "http://api.nesops.xyz";
        public static string AUDIENCE = "http://api.nesops.xyz";
        //public static string ExpireDays = "5";
    }
    public static class NesopsMySqlServerConnection
    {
        public static string GetConnectionString()
        {
            const string databaseServer = "192.168.233.132,3306";
            const string databaseName = "NesopsAuthorize";
            const string databaseUser = "root";
            const string databasePass = "zaQ@1234";

            return $"Server={databaseServer};" +
                   $"database={databaseName};" +
                   $"uid={databaseUser};" +
                   $"pwd={databasePass};" +
                   $"pooling=true;";
        }
    }
    public static class JWTBuilder
    {
        public static void BuildJWTService(IServiceCollection services)
        {
            //Authentication Schema
            const string scheme = JwtBearerDefaults.AuthenticationScheme;
            // Add authentication
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = scheme;
                    options.DefaultChallengeScheme = scheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(NesopsJWTConfiguration.SECRETKEY))
                    };
                });
        }

    }
}
