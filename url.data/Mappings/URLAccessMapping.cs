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
	public class URLAccessMapping : IEntityTypeConfiguration<URLAccessModel>
	{
		public void Configure(EntityTypeBuilder<URLAccessModel> builder)
		{
			builder.ToTable("URLAccesses");
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id)
				.HasColumnType("int")
				.IsRequired();
			builder.Property(p => p.ShortenedURLId)
				.IsRequired();
			builder.Property(p => p.DateAccess)
				.HasDefaultValue(DateTime.Now)
				.IsRequired();
			builder.Property(p => p.Source)
				.HasColumnType("varchar(150)")
				.HasMaxLength(150)
				.IsRequired();
		}
	}
}

