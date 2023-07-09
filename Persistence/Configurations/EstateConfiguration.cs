using BlazorServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorServer.Persistence.Configurations;

public class EstateConfiguration : IEntityTypeConfiguration<Estate>
{
    public void Configure(EntityTypeBuilder<Estate> builder)
    {
        //configure properties
        
        //configure relationships
        builder.HasOne(e => e.User).WithMany(u => u.Estates);
    }
}