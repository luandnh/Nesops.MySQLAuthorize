using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class ApplicationMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.Application>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.Application> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Application");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int(11)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasColumnType("longtext");

            builder.Property(t => t.DisplayName)
                .HasColumnName("DisplayName")
                .HasColumnType("longtext");

            builder.Property(t => t.RedirectUrl)
                .HasColumnName("RedirectUrl")
                .HasColumnType("longtext");

            builder.Property(t => t.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("tinyint(1)");

            builder.Property(t => t.CreateAt)
                .IsRequired()
                .HasColumnName("createAt")
                .HasColumnType("datetime(6)");

            builder.Property(t => t.UpdateAt)
                .IsRequired()
                .HasColumnName("updateAt")
                .HasColumnType("datetime(6)");

            builder.Property(t => t.OwnerId)
                .HasColumnName("OwnerId")
                .HasColumnType("int(11)");

            // relationships
            builder.HasOne(t => t.OwnerAspNetUsers)
                .WithMany(t => t.OwnerApplications)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Application_AspNetUsers_OwnerId");

            #endregion
        }

        #region Generated Constants
        public const string TableSchema = "";
        public const string TableName = "Application";

        public const string ColumnId = "Id";
        public const string ColumnName = "Name";
        public const string ColumnDisplayName = "DisplayName";
        public const string ColumnRedirectUrl = "RedirectUrl";
        public const string ColumnActive = "Active";
        public const string ColumnCreateAt = "createAt";
        public const string ColumnUpdateAt = "updateAt";
        public const string ColumnOwnerId = "OwnerId";
        #endregion
    }
}
