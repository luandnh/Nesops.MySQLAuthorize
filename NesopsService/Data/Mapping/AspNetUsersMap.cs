using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class AspNetUsersMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.AspNetUsers>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.AspNetUsers> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("AspNetUsers");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int(11)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.UserName)
                .HasColumnName("UserName")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.NormalizedUserName)
                .HasColumnName("NormalizedUserName")
                .HasColumnType("varchar(85)")
                .HasMaxLength(85);

            builder.Property(t => t.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.NormalizedEmail)
                .HasColumnName("NormalizedEmail")
                .HasColumnType("varchar(85)")
                .HasMaxLength(85);

            builder.Property(t => t.EmailConfirmed)
                .IsRequired()
                .HasColumnName("EmailConfirmed")
                .HasColumnType("tinyint(1)");

            builder.Property(t => t.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("longtext");

            builder.Property(t => t.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasColumnType("longtext");

            builder.Property(t => t.ConcurrencyStamp)
                .HasColumnName("ConcurrencyStamp")
                .HasColumnType("longtext");

            builder.Property(t => t.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("longtext");

            builder.Property(t => t.PhoneNumberConfirmed)
                .IsRequired()
                .HasColumnName("PhoneNumberConfirmed")
                .HasColumnType("tinyint(1)");

            builder.Property(t => t.TwoFactorEnabled)
                .IsRequired()
                .HasColumnName("TwoFactorEnabled")
                .HasColumnType("tinyint(1)");

            builder.Property(t => t.LockoutEnd)
                .HasColumnName("LockoutEnd")
                .HasColumnType("datetime(6)");

            builder.Property(t => t.LockoutEnabled)
                .IsRequired()
                .HasColumnName("LockoutEnabled")
                .HasColumnType("tinyint(1)");

            builder.Property(t => t.AccessFailedCount)
                .IsRequired()
                .HasColumnName("AccessFailedCount")
                .HasColumnType("int(11)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public const string TableSchema = "";
        public const string TableName = "AspNetUsers";

        public const string ColumnId = "Id";
        public const string ColumnUserName = "UserName";
        public const string ColumnNormalizedUserName = "NormalizedUserName";
        public const string ColumnEmail = "Email";
        public const string ColumnNormalizedEmail = "NormalizedEmail";
        public const string ColumnEmailConfirmed = "EmailConfirmed";
        public const string ColumnPasswordHash = "PasswordHash";
        public const string ColumnSecurityStamp = "SecurityStamp";
        public const string ColumnConcurrencyStamp = "ConcurrencyStamp";
        public const string ColumnPhoneNumber = "PhoneNumber";
        public const string ColumnPhoneNumberConfirmed = "PhoneNumberConfirmed";
        public const string ColumnTwoFactorEnabled = "TwoFactorEnabled";
        public const string ColumnLockoutEnd = "LockoutEnd";
        public const string ColumnLockoutEnabled = "LockoutEnabled";
        public const string ColumnAccessFailedCount = "AccessFailedCount";
        #endregion
    }
}
