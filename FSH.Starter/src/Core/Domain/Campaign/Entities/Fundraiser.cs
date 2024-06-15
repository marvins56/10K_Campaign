using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Domain.Fundraising.Entities;
public class Fundraiser
{
    public Guid FundraiserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid AccountId { get; set; }

    public Account Account { get; set; }
    public ICollection<Donation> Donations { get; set; }
}