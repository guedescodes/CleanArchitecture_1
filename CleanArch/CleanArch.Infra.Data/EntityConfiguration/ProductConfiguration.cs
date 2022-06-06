using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10,2);

            builder.HasData(
                    new Product { 
                        Id = 1,                        
                        Name = "Caderno",
                        Description = "Caderno espiral 100 folhas",
                        Price = 9.15m
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Borrachinhas",
                        Description = "Borracha apaga tudo",
                        Price = 1.50m
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Caneta",
                        Description = "Caneta azul, azul caneta",
                        Price = 0.50m
                    }
                );
        }
    }
}
