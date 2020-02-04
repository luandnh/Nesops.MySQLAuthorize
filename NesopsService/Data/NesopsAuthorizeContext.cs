using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NesopsService.Data
{
    public partial class NesopsAuthorizeContext : DbContext
    {
        public NesopsAuthorizeContext(DbContextOptions<NesopsAuthorizeContext> options)
            : base(options)
        {
        }

        #region Generated Properties
        public virtual DbSet<NesopsService.Data.Entities.Application> Applications { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.AspNetRoleClaims> AspNetRoleClaims { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.AspNetRoles> AspNetRoles { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.AspNetUserClaims> AspNetUserClaims { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.AspNetUserLogins> AspNetUserLogins { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.AspNetUserRoles> AspNetUserRoles { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.AspNetUsers> AspNetUsers { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.AspNetUserTokens> AspNetUserTokens { get; set; }

        public virtual DbSet<NesopsService.Data.Entities.EFMigrationsHistory> EFMigrationsHistories { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.ApplicationMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.AspNetRoleClaimsMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.AspNetRolesMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.AspNetUserClaimsMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.AspNetUserLoginsMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.AspNetUserRolesMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.AspNetUsersMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.AspNetUserTokensMap());
            modelBuilder.ApplyConfiguration(new NesopsService.Data.Mapping.EFMigrationsHistoryMap());
            #endregion
        }
    }
}
