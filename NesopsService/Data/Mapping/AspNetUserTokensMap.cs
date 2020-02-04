using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class AspNetUserTokensMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.AspNetUserTokens>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.AspNetUserTokens> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("AspNetUserTokens");

            // key
            builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            // properties
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int(11)");

            builder.Property(t => t.LoginProvider)
                .IsRequired()
                .HasColumnName("LoginProvider")
                .HasColumnType("varchar(85)")
                .HasMaxLength(85);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(85)")
                .HasMaxLength(85);

            builder.Property(t => t.Value)
                .HasColumnName("Value")
                .HasColumnType("longtext");

            // relationships
            builder.HasOne(t => t.UserAspNetUsers)
                .WithMany(t => t.UserAspNetUserTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");

            #endregion
        }

        #region Generated Constants
        public const string TableSchema = "";
        public const string TableName = "AspNetUserTokens";

        public const string ColumnUserId = "UserId";
        public const string ColumnLoginProvider = "LoginProvider";
        public const string ColumnName = "Name";
        public const string ColumnValue = "Value";
        #endregion
    }
}
