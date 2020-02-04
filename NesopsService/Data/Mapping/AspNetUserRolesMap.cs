using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class AspNetUserRolesMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.AspNetUserRoles>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.AspNetUserRoles> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("AspNetUserRoles");

            // key
            builder.HasKey(t => new { t.UserId, t.RoleId });

            // properties
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int(11)");

            builder.Property(t => t.RoleId)
                .IsRequired()
                .HasColumnName("RoleId")
                .HasColumnType("int(11)");

            // relationships
            builder.HasOne(t => t.RoleAspNetRoles)
                .WithMany(t => t.RoleAspNetUserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

            builder.HasOne(t => t.UserAspNetUsers)
                .WithMany(t => t.UserAspNetUserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");

            #endregion
        }

        #region Generated Constants
        public const string TableSchema = "";
        public const string TableName = "AspNetUserRoles";

        public const string ColumnUserId = "UserId";
        public const string ColumnRoleId = "RoleId";
        #endregion
    }
}
