using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Common.Interfaces;
public interface IApplicationDbContext
{
   
    DbSet<Campaign> Campaigns { get; set; }
    DbSet<Donation> Donations { get; set; }
    DbSet<Student> Students { get; set; }
    DbSet<CampaignStudent> CampaignStudents { get; set; }
    DbSet<DonationStudent> DonationStudents { get; set; }
    DbSet<Fundraiser> Fundraisers { get; set; }
    DbSet<Account> Accounts { get; set; }
    DbSet<Configurations> Configurations { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}