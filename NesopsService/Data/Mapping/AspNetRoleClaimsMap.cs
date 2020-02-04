using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class AspNetRoleClaimsMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.AspNetRoleClaims>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.AspNetRoleClaims> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("AspNetRoleClaims");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int(11)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.RoleId)
                .IsRequired()
                .HasColumnName("RoleId")
                .HasColumnType("int(11)");

            builder.Property(t => t.ClaimType)
                .HasColumnName("ClaimType")
                .HasColumnType("longtext");

            builder.Property(t => t.ClaimValue)
                .HasColumnName("ClaimValue")
                .HasColumnType("longtext");

            // relationships
            builder.HasOne(t => t.RoleAspNetRoles)
                .WithMany(t => t.RoleAspNetRoleClaims)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");

            #endregion
        }

        #region Generated Constants
        public const string TableSchema = "";
        public const string TableName = "AspNetRoleClaims";

        public const string ColumnId = "Id";
        public const string ColumnRoleId = "RoleId";
        public const string ColumnClaimType = "ClaimType";
        public const string ColumnClaimValue = "ClaimValue";
        #endregion
    }
}
