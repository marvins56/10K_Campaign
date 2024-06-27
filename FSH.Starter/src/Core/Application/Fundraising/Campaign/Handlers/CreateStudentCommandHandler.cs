using AutoMapper;
using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Domain.Fundraising.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FSH.Starter.Application.Common.Exceptions.NotFoundException;

namespace FSH.Starter.Application.Fundraising.Campaign.Handlers;
public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateStudentCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var studentExists = await _context.Students.AnyAsync(s => s.Email == request.Email, cancellationToken);

        if (studentExists)
        {
            throw new DuplicateAccountException(request.Email);
        }


        var student = _mapper.Map<Student>(request);
        _context.Students.Add(student);
        await _context.SaveChangesAsync(cancellationToken);
        return student.StudentId;
    }
}
