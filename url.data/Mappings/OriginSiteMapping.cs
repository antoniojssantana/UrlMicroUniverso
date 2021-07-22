using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using url.business.Models;
using url.Enums;
namespace url.data.Mappings
{
	public class OriginSiteMapping : IEntityTypeConfiguration<OriginSiteModel>
	{
		public void Configure(EntityTypeBuilder<OriginSiteModel> builder)
		{
			builder.ToTable("OriginSites");
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id)
				.HasColumnType("int")
				.IsRequired();
			builder.Property(p => p.Description)
				.HasColumnType("varchar(150)")
				.HasMaxLength(150)
				.IsRequired();
			builder.Property(p => p.URL)
				.HasColumnType("varchar(150)")
				.HasMaxLength(150)
				.IsRequired();
			builder.Property(p => p.UserBaseId)
				.IsRequired();
			builder.Property(p => p.State)
				.HasColumnType("int")
				.HasConversion<int>()
				.IsRequired();
		}
	}
}

