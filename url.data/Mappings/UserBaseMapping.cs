using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using url.business.Models;

namespace url.data.Mappings
{
    public class UserBaseMapping : IEntityTypeConfiguration<UserBaseModel>
    {
        public void Configure(EntityTypeBuilder<UserBaseModel> builder)
        {
            builder.ToTable("UsersBase");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Cpf)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(75)")
                .HasMaxLength(75)
                .IsRequired();

            builder.Property(p => p.FirstAccess)
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.Photograph)
            .HasColumnType("varchar(2500)")
            .HasMaxLength(2500)
            .IsRequired();

            builder.Property(p => p.Telephone)
            .HasColumnType("varchar(15)")
            .HasMaxLength(15)
            .IsRequired();

            builder.Property(p => p.Address)
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();

            builder.Property(p => p.Complement)
            .HasColumnType("varchar(75)")
            .HasMaxLength(75)
            .IsRequired();

            builder.Property(p => p.ZipCode)
            .HasColumnType("varchar(8)")
            .HasMaxLength(8)
            .IsRequired();

            builder.Property(p => p.CreateDate)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnType("int")
                .HasConversion<int>()
                .IsRequired();
        }
    }
}