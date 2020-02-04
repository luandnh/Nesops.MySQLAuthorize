using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Mapping
{
    public partial class EFMigrationsHistoryMap
        : IEntityTypeConfiguration<NesopsService.Data.Entities.EFMigrationsHistory>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NesopsService.Data.Entities.EFMigrationsHistory> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("__EFMigrationsHistory");

            // key
            builder.HasKey(t => t.MigrationId);

            // properties
            builder.Property(t => t.MigrationId)
                .IsRequired()
                .HasColumnName("MigrationId")
                .HasColumnType("varchar(95)")
                .HasMaxLength(95);

            builder.Property(t => t.ProductVersion)
                .IsRequired()
                .HasColumnName("ProductVersion")
                .HasColumnType("varchar(32)")
                .HasMaxLength(32);

            // relationships
            #endregion
        }

        #region Generated Constants
        public const string TableSchema = "";
        public const string TableName = "__EFMigrationsHistory";

        public const string ColumnMigrationId = "MigrationId";
        public const string ColumnProductVersion = "ProductVersion";
        #endregion
    }
}
