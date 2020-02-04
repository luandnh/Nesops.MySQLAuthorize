using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NesopsService.Data;
using NesopsService.Domain.Mapping;
using NesopsService.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NesopsService
{
    public static class ServiceRootConfig
    {
        public static void Entry(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(DbContext), typeof(NesopsAuthorizeContext));
            #region Auto Mapper Config
            services.AddAutoMapper(typeof(BaseMappingProfile).GetTypeInfo().Assembly);
            #endregion
            #region Config Validator
            // FluentValidation read on class extend AbstractValidator
            var types = typeof(BaseCreateModelValidator).Assembly.GetTypes();
            new AssemblyScanner(types).ForEach(pair => {
                services.Add(ServiceDescriptor.Transient(pair.InterfaceType, pair.ValidatorType));
            });
            #endregion
            //services.AddTransient<IValidator<VoucherGenerateModel>, VoucherGenerateModelValidator>();
        }
    }
}
