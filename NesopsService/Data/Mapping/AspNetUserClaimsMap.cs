using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class AspNetUserClaimsMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.AspNetUserClaims>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.AspNetUserClaims> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("AspNetUserClaims");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int(11)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int(11)");

            builder.Property(t => t.ClaimType)
                .HasColumnName("ClaimType")
                .HasColumnType("longtext");

            builder.Property(t => t.ClaimValue)
                .HasColumnName("ClaimValue")
                .HasColumnType("longtext");

            // relationships
            builder.HasOne(t => t.UserAspNetUsers)
                .WithMany(t => t.UserAspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");

            #endregion
        }

        #region Generated Constants
        public const string TableSchema = "";
        public const string TableName = "AspNetUserClaims";

        public const string ColumnId = "Id";
        public const string ColumnUserId = "UserId";
        public const string ColumnClaimType = "ClaimType";
        public const string ColumnClaimValue = "ClaimValue";
        #endregion
    }
}
