using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Configurations
{
    public class AspNetUserConfiguration : IEntityTypeConfiguration<AspNetUser>
    {
        public void Configure(EntityTypeBuilder<AspNetUser> builder)
        {
            builder.ToTable("AspNetUser");

            builder.HasKey(nx => nx.Id);

            builder.Property(nx => nx.Email)
                 .IsRequired();

            builder.Property(nx => nx.PhoneNumber)
                 .IsRequired();
        }
    }
}
