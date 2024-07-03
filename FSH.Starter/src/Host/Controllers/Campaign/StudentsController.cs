using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FSH.Starter.Host.Controllers.Campaign;
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Students)]
    [OpenApiOperation("create Students")]
    public async Task<ActionResult<Guid>> Create(CreateStudentCommand command)
    {
        await _mediator.Send(command);
        return Ok(new {message = "Student Created Sucessfully"});
    }


    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Students)]
    [OpenApiOperation("get all Students")]
    public async Task<ActionResult<List<StudentDto>>> GetAll()
    {
        return await _mediator.Send(new GetAllStudentsQuery());
    }


    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StudentDto>> GetById(Guid id)
    {
        return await _mediator.Send(new GetStudentByIdQuery { StudentId = id });
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Students)]
    [OpenApiOperation("Update Students")]

    public async Task<IActionResult> Update(Guid id, UpdateStudentCommand command)
    {
        if (id != command.StudentId)
        {
            return BadRequest("Student ID mismatch.");
        }

        await _mediator.Send(command);

        return Ok(new { message = "StudentDetails Updated Sucessfully" });
    }
}