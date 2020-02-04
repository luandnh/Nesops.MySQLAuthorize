using System;
using AutoMapper;
using NesopsService.Data.Entities;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Mapping
{
    public partial class ApplicationProfile
        : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<NesopsService.Data.Entities.Application, NesopsService.Domain.Models.ApplicationReadModel>();
            CreateMap<NesopsService.Domain.Models.ApplicationCreateModel, NesopsService.Data.Entities.Application>();
            CreateMap<NesopsService.Data.Entities.Application, NesopsService.Domain.Models.ApplicationUpdateModel>();
            CreateMap<NesopsService.Domain.Models.ApplicationUpdateModel, NesopsService.Data.Entities.Application>();
        }

    }
}
