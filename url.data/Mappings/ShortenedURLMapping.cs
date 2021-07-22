using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using url.business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace url.data.Mappings
{
	public class ShortenedURLMapping : IEntityTypeConfiguration<ShortenedURLModel>
	{
		public void Configure(EntityTypeBuilder<ShortenedURLModel> builder)
		{
			builder.ToTable("ShortenedUrls");
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id)
				.HasColumnType("int")
				.IsRequired();
			builder.Property(p => p.OriginSiteId)
				.IsRequired();
			builder.Property(p => p.Link)
				.HasColumnType("varchar(150)")
				.HasMaxLength(150)
				.IsRequired();
			builder.Property(p => p.InitialDate)
				.HasDefaultValue(DateTime.Now)
				.IsRequired();
			builder.Property(p => p.ExpiredDate)
				.HasDefaultValue(DateTime.Now)
				.IsRequired();
		}
	}
}

