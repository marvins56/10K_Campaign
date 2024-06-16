using DocumentFormat.OpenXml.InkML;
using Finbuckle.MultiTenant;
using FSH.Starter.Application.Common.Events;
using FSH.Starter.Application.Common.Interfaces;
using FSH.Starter.Domain.Catalog;
using FSH.Starter.Domain.Fundraising.Entities;
using FSH.Starter.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FSH.Starter.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(currentTenant, options, currentUser, serializer, dbSettings, events)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<CampaignStudent> CampaignStudents { get; set; }
    public DbSet<DonationStudent> DonationStudents { get; set; }
    public DbSet<Fundraiser> Fundraisers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Configurations> Configurations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);

        // Configure CampaignStudent entity
        modelBuilder.Entity<CampaignStudent>()
            .HasKey(cs => new { cs.CampaignId, cs.StudentId });

        modelBuilder.Entity<CampaignStudent>()
            .HasOne(cs => cs.Campaign)
            .WithMany(c => c.CampaignStudents)
            .HasForeignKey(cs => cs.CampaignId);

        modelBuilder.Entity<CampaignStudent>()
            .HasOne(cs => cs.Student)
            .WithMany(s => s.CampaignStudents)
            .HasForeignKey(cs => cs.StudentId);

        // Configure DonationStudent entity
        modelBuilder.Entity<DonationStudent>()
            .HasKey(ds => new { ds.DonationId, ds.StudentId });

        modelBuilder.Entity<DonationStudent>()
            .HasOne(ds => ds.Donation)
            .WithMany(d => d.DonationStudents)
            .HasForeignKey(ds => ds.DonationId);

        modelBuilder.Entity<DonationStudent>()
            .HasOne(ds => ds.Student)
            .WithMany(s => s.DonationStudents)
            .HasForeignKey(ds => ds.StudentId);

        // Configure Configurations entity
        modelBuilder.Entity<Configurations>(entity =>
        {
            entity.HasKey(e => e.ConfigurationsId);

            entity.HasOne(e => e.Campaign)
                  .WithMany(c => c.Configurations)
                  .HasForeignKey(e => e.CampaignId)
                  .OnDelete(DeleteBehavior.Cascade); // or .OnDelete(DeleteBehavior.SetNull)

            entity.HasOne(e => e.Donation)
                  .WithMany(d => d.Configurations)
                  .HasForeignKey(e => e.DonationId)
                  .OnDelete(DeleteBehavior.Cascade); // or .OnDelete(DeleteBehavior.SetNull)
        });

        // Configure Donation entity
        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationId);

            entity.HasOne(e => e.Campaign)
                  .WithMany(c => c.Donations)
                  .HasForeignKey(e => e.CampaignId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Donor)
                  .WithMany(d => d.Donations)
                  .HasForeignKey(e => e.DonorId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure Campaign entity
        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.HasKey(e => e.CampaignId);
        });

        // Configure Fundraiser entity
        modelBuilder.Entity<Fundraiser>(entity =>
        {
            entity.HasKey(e => e.FundraiserId);

            entity.HasOne(e => e.Account)
                  .WithMany(a => a.Fundraisers)
                  .HasForeignKey(e => e.AccountId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure Account entity
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId);
        });

        // Configure Student entity
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId);
        });

        // Validate the model
        var model = modelBuilder.Model;
        foreach (var entityType in model.GetEntityTypes())
        {
            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                if (!foreignKey.PrincipalKey.IsPrimaryKey())
                {
                    throw new InvalidOperationException($"Entity type '{entityType.DisplayName()}' has a foreign key defined on '{foreignKey.Properties.Format()}' with a principal key that does not match the principal entity type '{foreignKey.PrincipalEntityType.DisplayName()}' primary key '{foreignKey.PrincipalKey.Properties.Format()}'.");
                }
            }
        }


    }
}
