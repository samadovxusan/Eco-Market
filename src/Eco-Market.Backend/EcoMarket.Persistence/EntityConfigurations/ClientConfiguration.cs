using EcoMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoMarket.Persistencee.EntityConfigurations;

public class ClientConfiguration:IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(client =>  client.FirstName).HasMaxLength(64).IsRequired();
        builder.Property(client => client.LastName).HasMaxLength(64).IsRequired();
        
        builder
            .Property(client => client.Role)
            .HasConversion<string>()
            .HasMaxLength(64)
            .IsRequired();
    }
}