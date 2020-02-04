using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class AspNetRolesMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.AspNetRoles>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.AspNetRoles> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("AspNetRoles");

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
                .HasColumnType("varchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.NormalizedName)
                .HasColumnName("NormalizedName")
                .HasColumnType("varchar(85)")
                .HasMaxLength(85);

            builder.Property(t => t.ConcurrencyStamp)
                .HasColumnName("ConcurrencyStamp")
                .HasColumnType("longtext");

            builder.Property(t => t.DisplayName)
                .HasColumnName("DisplayName")
                .HasColumnType("longtext");

            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("longtext");

            // relationships
            #endregion
        }

        #region Generated Constants
        public const string TableSchema = "";
        public const string TableName = "AspNetRoles";

        public const string ColumnId = "Id";
        public const string ColumnName = "Name";
        public const string ColumnNormalizedName = "NormalizedName";
        public const string ColumnConcurrencyStamp = "ConcurrencyStamp";
        public const string ColumnDisplayName = "DisplayName";
        public const string ColumnDescription = "Description";
        #endregion
    }
}
