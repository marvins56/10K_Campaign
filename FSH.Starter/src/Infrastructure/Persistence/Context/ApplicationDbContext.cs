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

      // Define DbSets for your entities
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

      
        modelBuilder.ApplyMultiTenant();

    }
}