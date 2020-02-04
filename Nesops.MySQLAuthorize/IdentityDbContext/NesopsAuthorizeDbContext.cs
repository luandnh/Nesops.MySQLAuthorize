using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Nesops.MySQLAuthorize.Configs;
using Nesops.MySQLAuthorize.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nesops.MySQLAuthorize.IdentityDbContext
{
    public class NesopsAuthorizeDbContext : IdentityDbContext<NesopsUser, NesopsRole, int>
    {
        public NesopsAuthorizeDbContext(DbContextOptions<NesopsAuthorizeDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<NesopsUser>(entity => entity.Property(m => m.Id).HasMaxLength(12));
            builder.Entity<NesopsUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(85));
            builder.Entity<NesopsUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(85));

            builder.Entity<NesopsRole>(entity => entity.Property(m => m.Id).HasMaxLength(12));
            builder.Entity<NesopsRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(85));

            builder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(12));
            builder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(12));

            builder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(12));

            builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(12));
            builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

            builder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(12));
            builder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(12));
            builder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(12));
            builder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(12));
        }
        public virtual DbSet<NesopsApplication> Application { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
    public class NesopsIdentityDbContextFactory : IDesignTimeDbContextFactory<NesopsAuthorizeDbContext>
    {

        public NesopsAuthorizeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NesopsAuthorizeDbContext>();
            optionsBuilder.UseMySql(NesopsMySqlServerConnection.GetConnectionString());
            return new NesopsAuthorizeDbContext(optionsBuilder.Options);
        }
    }
}
