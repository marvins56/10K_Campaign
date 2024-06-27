using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FSH.Starter.Domain.Fundraising.Entities;
public class Account
{
    public Guid AccountId { get; set; }
    public string AccountName { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedDate { get; set; }

    public ICollection<Fundraiser> Fundraisers { get; set; }
    public ICollection<Campaign> Campaigns { get; set; }  // Add this line

}