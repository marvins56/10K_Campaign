using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class CreateCampaignStudentCommandHandler : IRequestHandler<CreateCampaignStudentCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCampaignStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCampaignStudentCommand request, CancellationToken cancellationToken)
    {
        // Check if the campaign exists
        var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.CampaignId == request.CampaignId);
        if (campaign == null)
        {
            throw new NotFoundException(nameof(Campaign));
        }

        // Check if the student exists
        var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == request.StudentId);
        if (student == null)
        {
            throw new NotFoundException(nameof(Student));
        }

        // Create CampaignStudent entity
        var campaignStudent = new CampaignStudent
        {
            CampaignId = request.CampaignId,
            StudentId = request.StudentId
        };

        _context.CampaignStudents.Add(campaignStudent);
        await _context.SaveChangesAsync(cancellationToken);

        return campaignStudent.CampaignId; // Return the CampaignId as confirmation
    }
}
