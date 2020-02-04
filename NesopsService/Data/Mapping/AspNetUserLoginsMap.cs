using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class AspNetUserLoginsMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.AspNetUserLogins>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.AspNetUserLogins> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("AspNetUserLogins");

            // key
            builder.HasKey(t => new { t.LoginProvider, t.ProviderKey });

            // properties
            builder.Property(t => t.LoginProvider)
                .IsRequired()
                .HasColumnName("LoginProvider")
                .HasColumnType("varchar(85)")
                .HasMaxLength(85);

            builder.Property(t => t.ProviderKey)
                .IsRequired()
                .HasColumnName("ProviderKey")
                .HasColumnType("varchar(85)")
                .HasMaxLength(85);

            builder.Property(t => t.ProviderDisplayName)
                .HasColumnName("ProviderDisplayName")
                .HasColumnType("longtext");

            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int(11)");

            // relationships
            builder.HasOne(t => t.UserAspNetUsers)
                .WithMany(t => t.UserAspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");

            #endregion
        }

        #region Generated Constants
        public const string TableSchema = "";
        public const string TableName = "AspNetUserLogins";

        public const string ColumnLoginProvider = "LoginProvider";
        public const string ColumnProviderKey = "ProviderKey";
        public const string ColumnProviderDisplayName = "ProviderDisplayName";
        public const string ColumnUserId = "UserId";
        #endregion
    }
}
