using System;
using AutoMapper;
using NesopsService.Data.Entities;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Mapping
{
    public partial class EFMigrationsHistoryProfile
        : AutoMapper.Profile
    {
        public EFMigrationsHistoryProfile()
        {
            CreateMap<NesopsService.Data.Entities.EFMigrationsHistory, NesopsService.Domain.Models.EFMigrationsHistoryReadModel>();
            CreateMap<NesopsService.Domain.Models.EFMigrationsHistoryCreateModel, NesopsService.Data.Entities.EFMigrationsHistory>();
            CreateMap<NesopsService.Data.Entities.EFMigrationsHistory, NesopsService.Domain.Models.EFMigrationsHistoryUpdateModel>();
            CreateMap<NesopsService.Domain.Models.EFMigrationsHistoryUpdateModel, NesopsService.Data.Entities.EFMigrationsHistory>();
        }

    }
}
