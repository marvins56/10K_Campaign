using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FSH.Starter.Application.Fundraising.Campaign.Commands;
using FSH.Starter.Application.Fundraising.Campaign.Querries;
using System.ComponentModel.DataAnnotations;

namespace FSH.Starter.Host.Controllers.Campaign;
[ApiController]
[Route("api/[controller]")]
public class AccountsController : VersionedApiController
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Accounts)]
    [OpenApiOperation("Create Account.", "allows user to create Transactional account")]
    public async Task<IActionResult> Create(CreateAccountCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { Message = "Account Created successfully." });
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Accounts)]
    [OpenApiOperation("Update Transaction Account.", "allows user to Update Transactional account")]
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
    [MustHavePermission(FSHAction.Update, FSHResource.Accounts)]
    [OpenApiOperation("retireave Transaction Account.", "allows user to retireave Transactional account")]

    public async Task<ActionResult<AccountDto>> GetById(Guid id)
    {
        var account = await _mediator.Send(new GetAccountByIdQuery { AccountId = id });
        return Ok(account);
    }

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Accounts)]
    [OpenApiOperation("retireave Transaction Account.", "allows user to retireave Transactional account")]

    public async Task<ActionResult<List<AccountDto>>> GetAll()
    {
        var accounts = await _mediator.Send(new GetAllAccountsQuery());
        return Ok(accounts);
    }
}
