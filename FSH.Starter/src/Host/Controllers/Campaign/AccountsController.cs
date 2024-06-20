using FSH.Starter.Application.Fundraising.Campaign.DTOS;
using FSH.Starter.Application.Fundraising.Campaign.Handlers.Querries;
using FSH.Starter.Application.Fundraising.Campaign.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateAccountCommand command)
    {
        if (id != command.AccountId)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
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
