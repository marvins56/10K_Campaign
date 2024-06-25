using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using System.ComponentModel.DataAnnotations;

namespace FSH.Starter.Host.Controllers.Campaign;
[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { Message = "Account Created successfully." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateAccountCommand command)
    {
        if (id != command.AccountId)
        {
            return BadRequest(new { Message = "The provided ID does not match the command's AccountId." });
        }

        try
        {
            await _mediator.Send(command);
            return Ok(new { Message = "Account details updated successfully." });
        }
       
        catch (Exception ex)
        {
            // Log the exception details
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An unexpected error occurred. Please try again later." });
        }
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<AccountDto>> GetById(Guid id)
    {
        var account = await _mediator.Send(new GetAccountByIdQuery { AccountId = id });
        return Ok(account);
    }

    [HttpGet]
    public async Task<ActionResult<List<AccountDto>>> GetAll()
    {
        var accounts = await _mediator.Send(new GetAllAccountsQuery());
        return Ok(accounts);
    }
}
