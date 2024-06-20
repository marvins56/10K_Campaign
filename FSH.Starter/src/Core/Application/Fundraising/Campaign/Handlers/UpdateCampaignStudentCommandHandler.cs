using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class UpdateCampaignStudentCommandHandler : IRequestHandler<UpdateCampaignStudentCommand, Unit>
{
    private readonly IApplicationDbContext _context;


    public UpdateCampaignStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCampaignStudentCommand request, CancellationToken cancellationToken)
    {
        var campaignStudent = await _context.CampaignStudents
            .FirstOrDefaultAsync(cs => cs.CampaignId == request.Id, cancellationToken);

        if (campaignStudent == null)
        {
            throw new NotFoundException(nameof(CampaignStudent));
        }

        campaignStudent.CampaignId = request.CampaignId;
        campaignStudent.StudentId = request.StudentId;

        _context.CampaignStudents.Update(campaignStudent);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}