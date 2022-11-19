using Microsoft.AspNetCore.Mvc;
using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.Commands;

namespace PackIt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PackingListsController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public PackingListsController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePackingList command, CancellationToken cancellationToken)
    {
        await _commandDispatcher.DispatchAsync(command, cancellationToken);
        return CreatedAtAction("POST", new { id = command.Id }, null);
    }

    [HttpPut("{packingListId}/items")]
    public async Task<IActionResult> Put([FromBody] AddPackingListItem command, CancellationToken cancellationToken)
    {
        await _commandDispatcher.DispatchAsync(command, cancellationToken);
        return Ok();
    }

    [HttpPut("{packingListId:guid}/items/{name}/pack")]
    public async Task<IActionResult> Put([FromBody] PackItem command, CancellationToken cancellationToken)
    {
        await _commandDispatcher.DispatchAsync(command, cancellationToken);
        return Ok();
    }
}
