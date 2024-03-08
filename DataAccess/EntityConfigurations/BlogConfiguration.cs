﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Title).HasColumnName("Title").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
            builder.Property(b => b.ReleaseDate).HasColumnName("ReleaseDate").IsRequired();
            builder.Property(b => b.ThumbnailPath).HasColumnName("ThumbnailPath").IsRequired();


            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
