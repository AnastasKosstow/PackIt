using Microsoft.AspNetCore.Mvc;
using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.Commands;
using PackIt.Application.PackingList.Queries;
using PackIt.Application.PackingList.Shared.DTOs;

namespace PackIt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PackingListsController : ControllerBase
{
    private readonly ICommandDispatcher commandDispatcher;
    private readonly IQueryDispatcher queryDispatcher;

    public PackingListsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        this.commandDispatcher = commandDispatcher;
        this.queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePackingList command, CancellationToken cancellationToken)
    {
        await commandDispatcher.DispatchAsync(command, cancellationToken);
        return CreatedAtAction("POST", new { id = command.Id }, null);
    }

    [HttpPut("{packingListId}/items")]
    public async Task<IActionResult> Put([FromBody] AddPackingListItem command, CancellationToken cancellationToken)
    {
        await commandDispatcher.DispatchAsync(command, cancellationToken);
        return Ok();
    }

    [HttpPut("{packingListId:guid}/items/{name}/pack")]
    public async Task<IActionResult> Put([FromBody] PackItem command, CancellationToken cancellationToken)
    {
        await commandDispatcher.DispatchAsync(command, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<PackingListDto>> Get(GetPackingList query, CancellationToken cancellationToken)
    {
        var result = await queryDispatcher.DispatchAsync(query, cancellationToken);
        return result is null 
            ? NotFound() 
            : Ok(result);
    }
}
