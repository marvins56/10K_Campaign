using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Infrastructure.Persistence.Configuration;
public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.HasKey(c => c.CampaignId);
        builder.Property(c => c.CampaignName).IsRequired().HasMaxLength(200);
        builder.Property(c => c.StartDate).IsRequired();
        builder.Property(c => c.EndDate).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(1000);

        builder.HasMany(c => c.Donations)
            .WithOne(d => d.Campaign)
            .HasForeignKey(d => d.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.CampaignStudents)
            .WithOne(cs => cs.Campaign)
            .HasForeignKey(cs => cs.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Configurations)
            .WithOne()
            .HasForeignKey(cfg => cfg.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
