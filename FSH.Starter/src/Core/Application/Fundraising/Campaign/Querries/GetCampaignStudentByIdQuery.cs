using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.Application.Fundraising.Campaign.Querries;
public class GetCampaignStudentByIdQuery : IRequest<CampaignStudentDto>
{
    public Guid Id { get; set; }
    public  Guid CampaignId { get; set; }

    public GetCampaignStudentByIdQuery(Guid id, Guid studentId)
    {
       CampaignId  = id;
        studentId = studentId;
    }
}