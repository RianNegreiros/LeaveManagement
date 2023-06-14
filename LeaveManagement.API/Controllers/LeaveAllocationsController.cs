using LeaveManagement.Application.DTOs.LeaveAllocation;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using LeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class LeaveAllocationsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public LeaveAllocationsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    // GET: api/<LeaveAllocationsController>
    [HttpGet]
    public async Task<ActionResult<List<LeaveAllocationDto>>> Get(bool isLoggedInUser = false)
    {
      var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest() { IsLoggedInUser = isLoggedInUser });
      return Ok(leaveAllocations);
    }

    // GET api/<LeaveAllocationsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
      var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
      return Ok(leaveAllocation);
    }

    // POST api/<LeaveAllocationsController>
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
    {
      var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation };
      var repsonse = await _mediator.Send(command);
      return Ok(repsonse);
    }

    // PUT api/<LeaveAllocationsController>/5
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocation)
    {
      var command = new UpdateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation };
      await _mediator.Send(command);
      return NoContent();
    }

    // DELETE api/<LeaveAllocationsController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var command = new DeleteLeaveAllocationCommand { Id = id };
      await _mediator.Send(command);
      return NoContent();
    }
  }
}