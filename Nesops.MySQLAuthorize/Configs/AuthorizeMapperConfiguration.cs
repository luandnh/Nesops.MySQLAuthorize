using AutoMapper;
using Nesops.MySQLAuthorize.Models;
using Nesops.MySQLAuthorize.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nesops.MySQLAuthorize.Configs
{
    /// <summary>
    /// AuthorizationMapperConfiguration ( AMC )
    /// </summary>
    public static partial class AMC
    {
        public  static IMapper _mapper { get; set; }
        private static void ConfigureAutoMapper()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<NesopsRole, NesopsRoleViewModel>().ReverseMap();
            });
            AMC._mapper = mapperConfig.CreateMapper();
        }
        public static void Configure()
        {
            ConfigureAutoMapper();
        }
    }
}
