﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MyBusiness.Models.Customer
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerModel>
    {
        public void Configure(EntityTypeBuilder<CustomerModel> builder)
        {
            builder
                .HasMany(c => c.Carts)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}
