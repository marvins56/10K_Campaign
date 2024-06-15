using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSH.Starter.Domain.Fundraising.Entities;

namespace FSH.Starter.Infrastructure.CampaignConfiguration;
public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.HasKey(c => c.CampaignId);
        builder.Property(c => c.CampaignName).IsRequired().HasMaxLength(100);
        builder.HasOne(c => c.Configurations)
               .WithMany()
               .HasForeignKey(c => c.ConfigurationsId);
        // Configure other properties and relationships
    }
}
